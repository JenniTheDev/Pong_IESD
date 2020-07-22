using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    [SerializeField] private bool isPlayerTwo;
    [SerializeField] private float speed = 0.2f;
    Transform myTransform;

    private int direction = 0; // o= still, 1 = up, -1 = down
    private float previousPositionY;

    [SerializeField] private KeyCode player1Up;
    [SerializeField] private KeyCode player1Down;
    [SerializeField] private KeyCode player2Up;
    [SerializeField] private KeyCode player2Down;

    private int maxY = 4;
    private int minY = -4;

    // Start is called before the first frame update
    void Start() {
        myTransform = transform;
        previousPositionY = myTransform.position.y;
    }

    // Update is called once per frame
    void Update() {

        if (isPlayerTwo) {
            if (Input.GetKey(player2Up))
                MoveUp();
            else if (Input.GetKey(player2Down))
                MoveDown();
        } else {
            if (Input.GetKey(player1Up))
                MoveUp();
            else if (Input.GetKey(player1Down))
                MoveDown();
        }

        Vector2 pos = myTransform.position;
        pos.y = Mathf.Clamp(myTransform.position.y, minY, maxY);
        myTransform.position = pos; 

    }


    private void MoveUp() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
    }

    private void MoveDown() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
    }


    private void LateUpdate() {
        previousPositionY = myTransform.position.y;

        if (previousPositionY > myTransform.position.y)
            direction = -1;
        else if (previousPositionY < myTransform.position.y)
            direction = 1;
        else direction = 0;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        float adjust = 5 * direction;
        collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, collision.rigidbody.velocity.y + adjust);
    }

}
