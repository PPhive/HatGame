using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : MonoBehaviour
{
    [SerializeField]
    Player myPlayer;

    [SerializeField]
    KeyCode turnClockwise;
    [SerializeField]
    KeyCode turnCounterClockwise;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(turnClockwise))
        {
            myPlayer.SwitchKnob(true);
        }
        else if (Input.GetKeyDown(turnCounterClockwise))
        {
            myPlayer.SwitchKnob(false);
        }
    }
}
