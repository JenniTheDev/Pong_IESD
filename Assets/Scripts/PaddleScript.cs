using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    [SerializeField] bool isPlayerTwo;
    [SerializeField] float speed = 0.2f;
    Transform myTransform;
    private int direction = 0; // 0 = still, 1 = up, -1 = down
    private float previousPositionY;
    private int adjustForce = 5;
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
            if (Input.GetKey("o"))
                MoveUp();
            else if (Input.GetKey("l"))
                MoveDown();
        } else {
            if (Input.GetKey("q"))
                MoveUp();
            else if (Input.GetKey("a"))
                MoveDown();
        }

        Vector2 pos = myTransform.position;
        pos.y = Mathf.Clamp(myTransform.position.y, minY, maxY);
        myTransform.position = pos;

    }

    void MoveUp() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
    }

    void MoveDown() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
    }

    private void LateUpdate() {
        previousPositionY = myTransform.position.y;

        if (previousPositionY > myTransform.position.y)
            direction = -1;
        else if (previousPositionY < myTransform.position.y)
            direction = 1;
        else
            direction = 0;


    }

    private void OnCollisionExit2D(Collision2D collision) {
        float adjust = adjustForce * direction;
        collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, collision.rigidbody.velocity.y + adjust);
    }




}
