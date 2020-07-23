using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    [SerializeField] private Paddle p1Paddle;
    [SerializeField] private Paddle p2Paddle;

    [SerializeField] private KeyCode p1UpKey;
    [SerializeField] private KeyCode p1DownKey;
    [SerializeField] private KeyCode p2UpKey;
    [SerializeField] private KeyCode p2DownKey;

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
    }

    #endregion
}
