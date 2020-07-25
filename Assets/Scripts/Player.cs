using System;
using UnityEngine;

[System.Serializable]
public class Player {
    [SerializeField] private int playerNum;
    [SerializeField] private int score;

    #region Properties
    public int Score {
        get { return score; }
        set { score = Math.Max(0, value); }
    }
    #endregion

    #region Constructors
    public Player(int playerNum = -1, int score = 0) {
        this.playerNum = playerNum;
        Score = score;
    }
    #endregion

    #region Class Methods
    public void ChangeScoreBy(int changeBy) {
        Score += changeBy;
        EventController.Instance.BroadcastScoreChange(this, score);
    }
    #endregion
}
