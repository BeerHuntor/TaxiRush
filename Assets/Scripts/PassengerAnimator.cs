using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerAnimator : MonoBehaviour {

    [SerializeField] private Passenger passenger;

    private const string IS_WAITING = "isWaiting";

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>(); 
    }

    private void Update() {
        animator.SetBool(IS_WAITING, passenger.IsPassengerWaiting());
    }
}
