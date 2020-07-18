using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    [SerializeField] bool isPlayerTwo;
    [SerializeField] float speed = 0.2f;
    Transform myTransform;



    // Start is called before the first frame update
    void Start() {
        myTransform = transform;
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

    }

    void MoveUp() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
    }

    void MoveDown() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
    }




}
