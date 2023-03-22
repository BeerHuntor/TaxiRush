using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour {

    public event EventHandler OnPassengerEmbark;
    public event EventHandler OnPassengerDisembark; 
    
    //References
    [SerializeField] GameInputManager gameInputManager;

    private Passenger passenger;
    private Passenger lastPassenger;
    
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

        transform.Translate(Vector3.up * (inputVector.y * accelerationFactor * Time.deltaTime));
    }

    public void ClearPassenger() {
        passenger = null;
    }

    public bool HasPassenger() {
        if (passenger != null) {
            return true; 
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.TryGetComponent(out Passenger passenger)) {
            //Check if the current triggered component is the same passenger as we had before. If it is, don't do anything. 
            if (lastPassenger == passenger) {
                return;
            }
            // We have enetered a passengers trigger. 
            passenger.SetParent(this.gameObject);
            
            this.passenger = passenger;
            lastPassenger = passenger;
            
            passenger.Hide();
            
            
            if (OnPassengerEmbark != null) {
                OnPassengerEmbark.Invoke(this, EventArgs.Empty);
            }
        }

        if (trigger.TryGetComponent(out Destination destination)) {
            //We have entered a destination trigger
            if (destination.gameObject.transform == GameManager.instance.GetCurrentDestination()) {
                //We have entered the current destination trigger.
                if (OnPassengerDisembark != null) {
                    OnPassengerDisembark.Invoke(this, EventArgs.Empty);
                } 
                this.passenger.SetParent(destination.gameObject);
                this.passenger.Show();
                ClearPassenger();
            }
        }
    }
}
