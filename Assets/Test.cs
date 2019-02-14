using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eGameState
{
    gameing,
    pause
}

public class Test : MonoBehaviour
{
    public eGameState gameState;

    void Start()
    {
        gameState = eGameState.gameing;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && gameState == eGameState.gameing)
        {
            gameState = eGameState.pause;
        }
        else if (Input.GetKeyDown(KeyCode.W) && gameState == eGameState.pause)
        {
            gameState = eGameState.gameing;
        }
        GameStateFSM();
    }

    public void GameStateFSM()
    {
        switch (gameState)
        {
            case eGameState.gameing:
                Time.timeScale = 1;
                break;
            case eGameState.pause:
                Time.timeScale = 0;
                break;
        }
    }
}
