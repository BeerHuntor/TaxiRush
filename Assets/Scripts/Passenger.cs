using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Passenger : MonoBehaviour {

    
    //References
    [SerializeField] private Player player;
    [SerializeField] private Transform passengerHaloVisuals; 
    
    //Local Variables
    private bool isWaiting;


    public void Update() {
        if (this.transform.parent == GameManager.instance.GetCurrentPickupPoint()) {
            isWaiting = true;
            return; 
        }

        isWaiting = false; 
        HideHaloVisuals();
    }
    
    public void Hide() {
        this.gameObject.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }

    private void HideHaloVisuals() {
        this.passengerHaloVisuals.gameObject.SetActive(false);
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
