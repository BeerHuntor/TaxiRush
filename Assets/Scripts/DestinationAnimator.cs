using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationAnimator : MonoBehaviour {

    private const string IS_ACTIVE_DESTINATION = "isCurrentDestination";
    private Animator animator;

    [SerializeField] private Transform destination; 

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_ACTIVE_DESTINATION, IsActiveDestination(GameManager.instance.GetCurrentDestination()));
    }

    private bool IsActiveDestination(Transform destination) {
        if (this.destination == destination) {
            return true;
        }
        return false;
    }
}
