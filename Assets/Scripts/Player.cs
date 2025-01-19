using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [SerializeField]
    GameObject myKnob1;
    [SerializeField]
    GameObject myKnob2;
    [SerializeField]
    GameObject myStick;
    [SerializeField]
    Rigidbody2D myRb;

    //Knob currently rotating around
    [SerializeField]
    GameObject pivotKnob;
    //Current Speed
    [SerializeField]
    float currentSpeed = 90;
    [SerializeField]
    bool currentClockwise;

    [SerializeField]
    public GameObject myScoreZone;

    void Start()
    {
        if (pivotKnob == null) 
        {
            pivotKnob = myKnob1;
        }
    }

    void FixedUpdate()
    {
        rotateRigidBodyAroundPointBy(myRb, pivotKnob.transform.position, new Vector3(0, 0, 1).normalized, 
            currentSpeed *
            (Convert.ToInt32(currentClockwise) - 0.5f) * (-2f) *//Changes speed direction depending on direction; -2 is intentional
            Time.fixedDeltaTime
            );
    }

    //Steps to the other foot
    public void SwitchKnob(bool clockwise) 
    {
        if (pivotKnob == myKnob1 && Mathf.Abs(myKnob2.transform.position.x) < 15 && Mathf.Abs(myKnob2.transform.position.y) < 15)
        {
            pivotKnob = myKnob2;
            currentClockwise = clockwise;
        }
        else if (Mathf.Abs(myKnob1.transform.position.x) < 15 && Mathf.Abs(myKnob1.transform.position.y) < 15)
        {
            pivotKnob = myKnob1;
            currentClockwise = clockwise;
        }
    }


    //RotateAroundRigidbody by:
    //https://answers.unity.com/questions/10093/rigidbody-rotating-around-a-point-instead-on-self.html
    public void rotateRigidBodyAroundPointBy(Rigidbody2D rb, Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        rb.MovePosition(q * (rb.transform.position - origin) + origin);
        rb.MoveRotation(rb.transform.rotation * q);
    }

    public bool Scooping(Knob knobRequesting) //if the moving knob is scooping upward
    {
        if (knobRequesting != pivotKnob) 
        {
            float clockfactor = (Convert.ToInt32(currentClockwise) - 0.5f) * (2f);
            if (pivotKnob == myKnob1) //if we are spinning around knob1
            {
                if (clockfactor * (myKnob1.transform.position.x - myKnob2.transform.position.x) > 0) //if spinning clockwise and knob 2 is on the right therefore moving upward
                {
                    Debug.Log(name + " is Scooping upward");
                    return true;
                }
            }

            if (pivotKnob == myKnob2) //if we are spinning around knob2
            {
                if (clockfactor * (myKnob2.transform.position.x - myKnob1.transform.position.x) > 0)
                {
                    Debug.Log(name + " is Scooping upward");
                    return true;
                }
            }
        }
        return false;
    }
}
