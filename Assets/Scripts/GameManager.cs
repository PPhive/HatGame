using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State {Start, Game, P1Won, P2Won}
    public State gameState;
    public static GameManager instance;

    public Player Player1;
    public Player Player2;

    public int Player1Score;
    public int Player2Score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (gameState == State.Start) 
        {
        
        }
        if (gameState == State.Game) 
        {
            
        }
    }

    public void GameStart() 
    {
        Player1Score = 0;
        Player2Score = 0;
    }
}
