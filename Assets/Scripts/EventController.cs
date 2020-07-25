using System;
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

    public delegate void OnWallHitHandler();
    public event OnWallHitHandler OnWallHit;

    public delegate void OnPlayerPaddleHitHandler(Player hitPlayerPaddle);
    public event OnPlayerPaddleHitHandler OnPlayerPaddleHit;

    public delegate void OnPlayerWallHitHandler(Player hitPlayerWall);
    public event OnPlayerWallHitHandler OnPlayerWallHit;

    public delegate void OnPauseHandler();
    public event OnPauseHandler OnPause;

    public delegate void OnResumeHandler();
    public event OnResumeHandler OnResume;
    #endregion

    #region Class Methods

    public void BroadcastReset() {
        OnReset?.Invoke();
    }

    public void BroadcastScoreChange(Player changedPlayer, int changeBy) {
        OnScoreChange?.Invoke(changedPlayer, changeBy);
    }

    public void BroadcastPlayerWallHit(Player playerWallHit) {
        OnPlayerWallHit?.Invoke(playerWallHit);
    }

    public void BroadcastPaddleHit(Player hitPaddle) {
        OnPlayerPaddleHit?.Invoke(hitPaddle);
    }

    public void BroadcastWallHit() {
        OnWallHit?.Invoke();
    }

    public void BroadcastPause() {
        OnPause?.Invoke();
    }

    public void BroadcastResume() {
        OnResume?.Invoke();
    }
    #endregion
}
