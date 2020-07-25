using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
    [SerializeField] private float startForce = 10.0f;
    [SerializeField] private float maxStartAngle = 0.8f;
    [SerializeField] private float maxMagnitude;
    [SerializeField] private float minMagnitude;

    private LayerMask playerWallLayer;
    private LayerMask playerPaddleLayer;
    private LayerMask wallLayer;
    private Rigidbody2D rbody;
    private Vector2 savedVelocity;

    #region Properties

    #endregion

    #region MonoBehaviour
    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        playerWallLayer = LayerMask.NameToLayer("PlayerWall");
        playerPaddleLayer = LayerMask.NameToLayer("PlayerPaddle");
        wallLayer = LayerMask.NameToLayer("BoundsWall");
    }

    private void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    private void FixedUpdate() {
        AdjustMagnitude();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == playerWallLayer) {
            Player hitPlayer = collision.gameObject.GetComponent<PlayerWall>().AssociatedPlayer;
            EventController.Instance.BroadcastPlayerWallHit(hitPlayer);
            ResetAndLaunch();
        }
        if(collision.gameObject.layer == playerPaddleLayer) {
            Player hitPlayer = collision.gameObject.GetComponent<Paddle>().AssociatedPlayer;
            EventController.Instance.BroadcastPaddleHit(hitPlayer);
        }

        if(collision.gameObject.layer == wallLayer) {
            EventController.Instance.BroadcastWallHit();
        }
    }
    #endregion

    #region Methods
    public void Reset() {
        transform.position = Vector2.zero;
        rbody.velocity = Vector2.zero;
    }

    public void ResetAndLaunch() {
        ResetAndLaunch(Vector3.zero);
    }

    public void ResetAndLaunch(Vector2 pos) {
        Reset();

        // Determines random right or left target & the angle to start
        float startDir = (UnityEngine.Random.value >= 0.5f) ? 1f : -1f;
        float startAngle = UnityEngine.Random.Range(-maxStartAngle, maxStartAngle);

        Vector2 dir = new Vector2(startDir, startAngle);
        transform.position = pos;
        rbody.velocity = dir * startForce;
    }

    public void Pause() {
        savedVelocity = rbody.velocity;
        rbody.velocity = Vector2.zero;
    }

    public void Resume() {
        rbody.velocity = savedVelocity;
    }

    private void AdjustMagnitude() {
        if(rbody.velocity.magnitude > maxMagnitude) {
            rbody.velocity = Vector2.ClampMagnitude(rbody.velocity, maxMagnitude);
        }
        if(rbody.velocity.magnitude < minMagnitude) {
            rbody.AddForce(rbody.velocity * 2f);
        }
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnReset += ResetAndLaunch;
        EventController.Instance.OnPause += Pause;
        EventController.Instance.OnResume += Resume;
    }

    private void Unsubscribe() {
        EventController.Instance.OnReset -= ResetAndLaunch;
        EventController.Instance.OnPause -= Pause;
        EventController.Instance.OnResume -= Resume;
    }
    #endregion
}
