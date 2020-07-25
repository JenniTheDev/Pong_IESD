using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int id;
    [SerializeField] private Paddle paddle;
    [SerializeField] private PlayerWall wall;
    [SerializeField] private TMP_Text scoreUI;

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
    private void Start() {
        wall.AssociatedPlayer = this;
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion

    #region Class Methods
    private void IncreaseScore() {
        Score++;
        scoreUI.text = score.ToString();
    }

    public void UpdateScore(Player thePlayer) {
        if(thePlayer == this) {
            IncreaseScore();
        }
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnPlayerWallHit += UpdateScore;
    }

    private void Unsubscribe() {
        EventController.Instance.OnPlayerWallHit -= UpdateScore;
    }
    #endregion
}
