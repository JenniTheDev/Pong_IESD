using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] TMP_Text player1ScoreUI;
    [SerializeField] TMP_Text player2ScoreUI;
    private int player1Score = 0;
    private int player2Score = 0; 

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void AddToPlayerScore(int playerNumber) {
        if (playerNumber == 1) {
            player1Score++;
            player1ScoreUI.text = $"{player1Score}";
        }
        if (playerNumber == 2) {
            player2Score++;
            player2ScoreUI.text = $"{player2Score}";
        }
    }

}
