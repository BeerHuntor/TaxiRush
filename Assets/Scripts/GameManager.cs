using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Static instances
    public static GameManager instance;

    //References
    [SerializeField] private List<Transform> pickupPoints;
    [SerializeField] private List<Transform> destinations;

    //Local Variables
    [SerializeField] private bool hasPassenger;
    [SerializeField] private bool isPassengerWaiting;

    private Transform currentPickupPoint;
    private Transform currentDestination;

    private bool startOfGame;
    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        InitGame();
    }

    // Update is called once per frame
    void Update() {
    }

    public Transform GetRandomPickupPointTransform() {
        int index = Random.Range(0, pickupPoints.Count);
        currentPickupPoint = pickupPoints[index].transform;
        return currentPickupPoint;
    }

    private void ClearCurrentPickupPoint() {
        currentPickupPoint = null; 
    }
    private Transform GetCurrentPickupPoint() {
        return currentPickupPoint;
    }

    private Transform GetRandomDestinationTransform() {
        int index = Random.Range(0, destinations.Count);
        currentDestination = destinations[index].transform;
        return currentDestination;
    }

    public void InitGame()
    {
        hasPassenger = false;
        isPassengerWaiting = false;
        startOfGame = true;
    }
    public bool HasPassenger
    {
        get
        {
            return hasPassenger;
        }
        set
        {
            hasPassenger = value;
        }

    }
    public bool PassengerWaiting
    {
        get
        {
            return isPassengerWaiting;
        }
        set
        {
            isPassengerWaiting = value;
        }
    }
    public bool StartOfGame
    {
        get
        {
            return startOfGame; 
        }
        set
        {
            startOfGame = value;
        }
    }

}
