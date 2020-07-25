﻿using System;
using UnityEngine;

public class EventController {
    #region Singleton
    private static bool isQuitting = false;
    private static EventController instance = null;
    public static EventController Instance {
        get {
            if(instance == null && !isQuitting) {
                instance = new EventController();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private EventController() { }
    #endregion

    #region Events & Delegates
    public delegate void OnResetHandler();
    public event OnResetHandler OnReset;

    public delegate void OnScoreChangeHandler(Player changedPlayer, int changeBy);
    public event OnScoreChangeHandler OnScoreChange;

    public delegate void OnPlayerWallHitHandler(Player hitPlayerWall);
    public event OnPlayerWallHitHandler OnPlayerWallHit;
    #endregion

    #region Class Methods

    public void BroadcastReset() {
        OnReset?.Invoke();
    }

    internal void BroadcastPlayerWallHit(Player playerWallHit) {
        OnPlayerWallHit?.Invoke(playerWallHit);
    }

    public void BroadcastScoreChange(Player changedPlayer, int changeBy) {
        OnScoreChange?.Invoke(changedPlayer, changeBy);
    }
    #endregion
}
