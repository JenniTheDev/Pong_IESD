using System;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour {
    [SerializeField] private int id;
    [SerializeField] private Paddle paddle;
    [SerializeField] private PlayerWall wall;

    private int score;

    #region Properties
    public int Score {
        get { return score; }
        set { score = Math.Max(0, value); }
    }

    public int Id {
        get { return this.id; }
    }
    #endregion

    #region MonoBehaviour

    #endregion

    #region Class Methods
    public void ChangeScoreBy(int changeBy) {
        Score += changeBy;
        EventController.Instance.BroadcastScoreChange(this, score);
    }
    #endregion
}
