using UnityEngine;

public class PlayerWall : MonoBehaviour {
    private Paddle playerPaddle;

    public Paddle PlayerPaddle {
        set {
            this.playerPaddle = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        EventController.Instance.BroadcastScoreChange(playerPaddle.ThePlayer, 1);
    }
}
