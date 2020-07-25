using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour, IMoveablePaddle {
    [SerializeField] private float moveForce;

    private Rigidbody2D rb;

    public Player AssociatedPlayer { get; set; }

    #region MonoBehaviour

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Methods
    public void MoveUp() {
        MovePaddle(PaddleDirection.Up);
    }

    public void MoveDown() {
        MovePaddle(PaddleDirection.Down);
    }

    private void MovePaddle(PaddleDirection dir) {
        var moveTowards = Vector2.up * ((dir == PaddleDirection.Up) ? moveForce : -moveForce);
        rb.AddForce(moveTowards);
    }
    #endregion
}
