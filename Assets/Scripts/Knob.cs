using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public Player myPlayer;
    [SerializeField]
    List<Hat> hats;
    public Transform topPos;
    public GameObject KnobTop;

    public float offTimer;

    void Start()
    {
        if (myPlayer == null) 
        {
            myPlayer = transform.parent.gameObject.GetComponent<Player>();
        }
        HatUpdate();
    }

    void FixedUpdate()
    {
        HatUpdate();
        KnobTop.transform.transform.position = topPos.position;
    }

    private void LateUpdate()
    {
        transform.up = Vector3.up;

        if (offTimer > 0)
        {
            offTimer -= Time.deltaTime;
        }
        else if (KnobTop.GetComponent<CircleCollider2D>().enabled == false)
        {
            KnobTop.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void HatUpdate() 
    {
        hats.Clear();
        if (transform.childCount > 1)
        {
            AddHatRecursive(transform.GetChild(1).GetComponent<Hat>());
        }


        if (hats.Count == 0)
        {
            topPos = this.transform;
        }
        else
        {
            topPos = hats[hats.Count - 1].transform;
        }
    }

    public void AddHat(Hat addedHat)
    {

        if (myPlayer.Scooping(this))
        {
            AddHatRecursive(addedHat);

            addedHat.gameObject.transform.parent = topPos;
            addedHat.gameObject.transform.localPosition = new Vector3(0, 1, -0.1f);
            addedHat.gameObject.transform.localEulerAngles = Vector3.zero;

            if (addedHat.myKnob != null && addedHat.myKnob.myPlayer != myPlayer) 
            {
                addedHat.myKnob.loseHat(addedHat);
            }
            addedHat.changeKnob(this);
        }

        pauseCollision(0.05f);
    }

    public void AddHatRecursive(Hat addedHat) 
    {
        hats.Add(addedHat);
        if (addedHat.transform.childCount > 0)
        {
            AddHatRecursive(addedHat.transform.GetChild(0).GetComponent<Hat>());
        }
    }

    public void loseHat(Hat bottomHatLost) 
    {
        for (int i = 0; i < hats.Count; i++) 
        {
            if (hats[i] == bottomHatLost) 
            {
                hats.RemoveRange(i, hats.Count - i);
                Debug.Log(i + " and above has been removed from " + myPlayer.gameObject.name);
                i = hats.Count;
                pauseCollision(0.2f);
            }
        }
    }

    public void DestroyMyHats() 
    {
        if (hats.Count > 0) 
        {
            Destroy((hats[0].gameObject));
            hats.Clear();
        }
    }

    public int ScoreReport() 
    {
        int Score = hats.Count;
        DestroyMyHats();
        return Score;
    }

    public void pauseCollision(float time) 
    {
        KnobTop.GetComponent<CircleCollider2D>().enabled = false;
        offTimer = time;
    }
}
