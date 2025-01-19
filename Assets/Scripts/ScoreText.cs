using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    TextMeshPro myText;

    enum Player {player1, player2}
    [SerializeField]
    Player myPlayer;

    void Start()
    {
                
    }

    void Update()
    {
        if (myPlayer == Player.player1)
        {
            myText.text = GameManager.instance.Player1Score / 10 + "" + GameManager.instance.Player1Score % 10;
        }
        else 
        {
            myText.text = GameManager.instance.Player2Score / 10 + "" + GameManager.instance.Player2Score % 10;
        }
    }
}
