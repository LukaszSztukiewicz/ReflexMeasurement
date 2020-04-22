using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMenager
{
    public static float gameSpeed = 0.1f;

    public enum GameStates {Running, Paused, OnMenu, OnStartGame, OnEndGame};
    public static GameStates GameState;
    public static playerInfo playerInfo = new playerInfo();
}
