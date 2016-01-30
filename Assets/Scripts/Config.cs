using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Config
{
    private static Dictionary<string, bool> GameStates;

    static Config()
    {
        GameStates = new Dictionary<string, bool>();
        GameStates["_NEWSTATE"] = true;
        GameStates["GameRunning"] = false;
    }

    public static bool GetGameState(string state)
    {
        return GameStates[state];
    }

    public static void SetGameState(string state, bool b)
    {
        GameStates["_NEWSTATE"] = true;
        GameStates[state] = b;
    }

    public static void ResetNewState()
    {
        GameStates["_NEWSTATE"] = false;
    }

}

