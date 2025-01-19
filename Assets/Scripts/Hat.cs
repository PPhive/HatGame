using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public Knob myKnob;

    public void changeKnob(Knob newKnob)
    {
        myKnob = newKnob;
        if (transform.childCount >= 1) 
        {
            transform.GetChild(0).GetComponent<Hat>().changeKnob(newKnob);
        }
    }
}
