using UnityEngine;

public class PlayerWall : MonoBehaviour {
    [SerializeField] Paddle associatedPaddle;

    private void OnCollisionEnter2D(Collision2D collision) {
        EventController.Instance.BroadcastScoreChange(associatedPaddle.ThePlayer, 1);
    }
}
