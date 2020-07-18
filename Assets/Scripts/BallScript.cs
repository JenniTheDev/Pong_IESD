using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    [SerializeField] float forceValue = 4.5f;
    private int force = 50;
    Rigidbody2D myBody;
    


    // Start is called before the first frame update
    void Start() {

        myBody = GetComponent<Rigidbody2D>();
        myBody.AddForce(new Vector2(forceValue * force, force));

    }

    // Update is called once per frame
    void Update() {

    }
}
