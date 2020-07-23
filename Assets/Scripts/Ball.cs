using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
    [SerializeField] private float startForce = 10.0f;
    [SerializeField] private float maxStartAngle = 0.8f;

    private Rigidbody2D rbody;

    #region MonoBehaviour
    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        FindObjectOfType<InputManager>().OnReset += Reset;
    }
    #endregion

    #region Methods
    public void Reset() {
        Reset(Vector2.zero);
    }

    public void Reset(Vector2 pos) {
        // Determines random right or left target.
        float startDir = (Random.value >= 0.5f) ? 1f : -1f;
        // Randomizes the angle of start
        Vector2 dir = new Vector2(startDir, Random.Range(-maxStartAngle, maxStartAngle));
        rbody.velocity = Vector2.zero;
        transform.position = pos;
        rbody.velocity = dir * startForce;
    }
    #endregion
}
