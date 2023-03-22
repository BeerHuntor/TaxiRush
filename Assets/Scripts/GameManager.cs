using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    
    
    //Static instances
    public static GameManager instance;

    //References
    [SerializeField] private List<Transform> pickupPoints;
    [SerializeField] private List<Transform> destinations;

    [SerializeField] private Player player; 

    //Local Variables
    [SerializeField] private bool hasPassenger;

    private Transform currentPickupPoint;
    private Transform currentDestination;

    private bool startOfGame;
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        InitGame();

        player.OnPassengerEmbark += Player_OnPassengerEmbarkEvent;
        player.OnPassengerDisembark += Player_OnPassengerDisembarkEvent;
    }

    private void Player_OnPassengerDisembarkEvent(object sender, EventArgs e) {
        ClearCurrentDestination();
    }

    private void Player_OnPassengerEmbarkEvent(object sender, EventArgs e) {
        SetRandomDestinationTransform();
    }


    // Update is called once per frame
    void Update() {
    }

    public Transform SetRandomPickupPointTransform() {
        if (currentPickupPoint != null) {
            ClearCurrentPickupPoint();
        }

        if (startOfGame) {
            startOfGame = false;
        }
        
        int index = Random.Range(0, pickupPoints.Count);
        currentPickupPoint = pickupPoints[index].transform;
        return GetCurrentPickupPoint();
    }

    private void ClearCurrentPickupPoint() {
        currentPickupPoint = null; 
    }
    public Transform GetCurrentPickupPoint() {
        return currentPickupPoint;
    }

    private void SetRandomDestinationTransform() {
        if (currentDestination != null) {
            currentDestination = null; 
        }
        int index = Random.Range(0, destinations.Count);
        currentDestination = destinations[index].transform;
    }

    public Transform GetCurrentDestination() {
        return currentDestination;
    }

    private void ClearCurrentDestination() {
        currentDestination = null;
    }

    public void InitGame()
    {
        startOfGame = true;
    }

    public bool HasPassenger() {
        return hasPassenger != player.HasPassenger();
    }

    public bool IsStartOfGame() {
        return startOfGame; 
    }


}
