using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
    [SerializeField] private float startForce = 10.0f;
    [SerializeField] private float maxStartAngle = 0.8f;
    [SerializeField] private float maxMagnitude;

    private Rigidbody2D rbody;
    #region Properties

    #endregion

    #region MonoBehaviour
    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        EventController.Instance.OnReset += Reset;
    }

    private void FixedUpdate() {
        AdjustMagnitude(); 
    }
    #endregion

    #region Methods
    public void Reset() {
        Reset(Vector2.zero);
    }

    public void Reset(Vector2 pos) {
        // Determines random right or left target & the angle to start
        float startDir = (UnityEngine.Random.value >= 0.5f) ? 1f : -1f;
        float startAngle = UnityEngine.Random.Range(-maxStartAngle, maxStartAngle);

        Vector2 dir = new Vector2(startDir, startAngle);
        rbody.velocity = Vector2.zero;
        transform.position = pos;
        rbody.velocity = dir * startForce;
    }

    private void AdjustMagnitude() {
        if(rbody.velocity.magnitude > maxMagnitude) {
            rbody.velocity = Vector2.ClampMagnitude(rbody.velocity, maxMagnitude);
        }
    }
    #endregion
}
