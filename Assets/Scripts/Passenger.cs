using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Passenger : MonoBehaviour {


    private Player player;
    
    //Components
    private Collider2D pickupTriggerCollider;
    

    private bool isWaiting;

    public void Start() {
        pickupTriggerCollider = GetComponent<BoxCollider2D>();
    }

    public void Update() {
        if (this.transform.parent == GameManager.instance.GetCurrentDestination()) {
            //We are at the destination point. 
            
            //Disble pickup trigger to stop the passenger re-embarking instantly. 
            pickupTriggerCollider.enabled = false;
        }
    }
    
    public void Hide() {
        this.gameObject.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void SetParent(GameObject gameObject) {
        ClearParent();

        transform.parent = gameObject.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity; 
    }

    public void ClearParent() {
        transform.parent = null; 
    }

    public bool IsPassengerWaiting() {
        return isWaiting; 
    }

    public void DestroySelf() {
        Destroy(this.gameObject);
    }
}
