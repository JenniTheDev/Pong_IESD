using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    [SerializeField] private Paddle p1Paddle;
    [SerializeField] private Paddle p2Paddle;
    [SerializeField] private Ball theBall;

    [SerializeField] private KeyCode p1UpKey = KeyCode.W;
    [SerializeField] private KeyCode p1DownKey = KeyCode.S;
    [SerializeField] private KeyCode p2UpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode p2DownKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode resetKey = KeyCode.R;

    private IMoveablePaddle p1Input;
    private IMoveablePaddle p2Input;

    #region MonoBehaviour
    private void Start() {
        p1Input = p1Paddle.GetComponent<IMoveablePaddle>();
        p2Input = p2Paddle.GetComponent<IMoveablePaddle>();
    }

    private void Update() {
        if(Input.GetKey(p1UpKey)) {
            p1Input.MoveUp();
        }
        if(Input.GetKey(p1DownKey)) {
            p1Input.MoveDown();
        }
        if(Input.GetKey(p2UpKey)) {
            p2Input.MoveUp();
        }
        if(Input.GetKey(p2DownKey)) {
            p2Input.MoveDown();
        }

        if(Input.GetKey(resetKey)) {
            EventController.Instance.BroadcastReset();
        }
    }

    #endregion
}
