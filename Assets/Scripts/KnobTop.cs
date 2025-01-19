using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobTop : MonoBehaviour
{
    public Knob myKnob;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.y > transform.position.y + 0.1f) 
        {
            Hat thisHat = collision.gameObject.GetComponent<Hat>();
            if (thisHat != null)
            {
                if (thisHat.myKnob == null)
                {
                    myKnob.AddHat(thisHat);
                }
                else if (thisHat.myKnob.myPlayer != myKnob.myPlayer)
                {
                    myKnob.AddHat(thisHat);
                }
            }
        }
    }
}
