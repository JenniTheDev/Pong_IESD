using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameState currentState = GameState.None;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject resumeButton;

    public GameState CurrentState {
        get { return this.currentState; }
        set { this.currentState = value; }
    }

    #region MonoBehaviour
    private void Start() {
        Subscribe();
        currentState = GameState.StartMenu;
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion

    public void StartGame() {
        currentState = GameState.Playing;
        startButton.SetActive(false);
        resumeButton.SetActive(false);
        EventController.Instance.BroadcastReset();
    }

    public void PauseGame() {
        currentState = GameState.Paused;
        startButton.SetActive(true);
        resumeButton.SetActive(true);
    }

    public void ResumeGame() {
        currentState = GameState.Playing;
        startButton.SetActive(false);
        resumeButton.SetActive(false);
        EventController.Instance.BroadcastResume();
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnPause += PauseGame;
    }

    private void Unsubscribe() {
        EventController.Instance.OnPause -= PauseGame;
    }
}
