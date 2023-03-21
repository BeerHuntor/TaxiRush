using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] GameInputManager gameInputManager;

    [SerializeField] float moveSpeed;
    [SerializeField] float turnRate; 

    private void Update() {
        HandleMovement(); 
    }
    private void HandleMovement() {
        Vector2 inputVector = gameInputManager.GetMovementVector();

        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        
        float moveDistance = moveSpeed * Time.deltaTime;
        
        //Doest work as intended... 
        transform.Translate(moveDir * moveDistance) ;

        if (inputVector.y != 0f) {
            transform.Rotate(0, 0, -inputVector.x * turnRate * Time.deltaTime);
        }
    }

    
}
