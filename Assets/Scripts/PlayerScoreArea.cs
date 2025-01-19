using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreArea : MonoBehaviour
{
    public Player myPlayer;

    public void ScorePoints(Knob thisKnob) 
    {
        GameManager.instance.PlayerScores(myPlayer, thisKnob.ScoreReport());
    }
}
