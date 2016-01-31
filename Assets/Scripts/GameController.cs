using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject _uiStart;
    private GameObject _uiIngame;
    public DeathMsg _deathMsg;

    void Start()
    {
        _uiStart = GameObject.Find("CanvasStartScreen");
        _uiIngame = GameObject.Find("CanvasInGame");
        //_deathMsg = GameObject.Find("DeathMsg").GetComponent<DeathMsg>();
    }

    public void Update()
    {
        if (Config.GetGameState("_NEWSTATE"))
        {
            if (Config.GetGameState("GameRunning"))
            {
                _uiIngame.SetActive(true);
                _uiStart.SetActive(false);
            }
            else
            {
                _uiIngame.SetActive(false);
                _uiStart.SetActive(true);
            }

            Config.ResetNewState();
        }
    }

    public void StartGame()
    {
        Config.SetGameState("GameRunning", true);
    }

    public void EndGame()
    {
        Config.SetGameState("GameRunning", false);
        _deathMsg.StartTimer();
    }
}
