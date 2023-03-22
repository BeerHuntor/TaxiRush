using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    [SerializeField] private Transform destinationVisual;

    private void Start() {
        HideVisuals();
    }
    private void Update() {
        if (GameManager.instance.GetCurrentDestination() == this.transform) {
            ShowVisuals();
        } else {
            HideVisuals();
        }
    }
    private void HideVisuals() {
        destinationVisual.gameObject.SetActive(false);
    }

    private void ShowVisuals() {
        destinationVisual.gameObject.SetActive(true);
    }
}
