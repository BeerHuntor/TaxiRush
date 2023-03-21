using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour {
    //References
    [SerializeField] GameInputManager gameInputManager;

    //Components
    private Rigidbody2D rb2D; 

    //Local Variables
    [SerializeField] float accelerationFactor;
    [SerializeField] float turnRate;


    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        HandleCarMovement();
    }
    
    private void HandleCarMovement() {
        Vector2 inputVector = gameInputManager.GetMovementVector();

        float turnRateDeltaTime = turnRate * Time.deltaTime;

        if (inputVector.y > 0) {
            transform.Rotate(0, 0, -inputVector.x * turnRateDeltaTime);
        } else if (inputVector.y < 0) {
            transform.Rotate(0, 0, inputVector.x * turnRateDeltaTime);

        }

        transform.Translate(Vector3.up * inputVector.y * accelerationFactor * Time.deltaTime);

    }


}
