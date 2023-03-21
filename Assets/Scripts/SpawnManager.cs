using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> pickupPoints;
    [SerializeField] private List<GameObject> passengers;
    [SerializeField] private List<GameObject> destinations;
    private Vector3 currentPickUpPoint;
    private Vector3 currentDestination;
    public GameObject currentPassenger;
    private float delaySpawnTime; // Dynamic variable that is used to count down in code
    private float delayBetweenDropOffAndSpawnTime; // Static variable to hold the time delay between spawns

    // Start is called before the first frame update
    void Start()
    {
        delayBetweenDropOffAndSpawnTime = 10.0f;
        delaySpawnTime = delayBetweenDropOffAndSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.HasPassenger && !GameManager.instance.PassengerWaiting)
        {
            if (GameManager.instance.StartOfGame)
            {
                SpawnPassenger();
                GameManager.instance.StartOfGame = false;
            }
            else
            {
                if (delaySpawnTime >= 0)
                {
                    delaySpawnTime -= Time.deltaTime;
                    if (delaySpawnTime <= 0)
                    {
                        SpawnPassenger();
                        delaySpawnTime = delayBetweenDropOffAndSpawnTime; 
                    }
                }
            }

        }
    }
    private void SpawnPassenger()
    {
        int randomPassenger = Random.Range(0, passengers.Count);
        currentPassenger  = Instantiate(passengers[randomPassenger], ChoosePickupPoint(), passengers[randomPassenger].transform.rotation);
        GameManager.instance.PassengerWaiting = true;
    }
    private Vector3 ChoosePickupPoint()
    {
        int randomPickupPoint = Random.Range(0, pickupPoints.Count);
        CurrentPickUpPoint = pickupPoints[randomPickupPoint].transform.position;
        return CurrentPickUpPoint;
    }
    public Vector3 GetDestination()
    {
        int randomDestination = Random.Range(0, destinations.Count);
        GameObject chosenDestination = destinations[randomDestination];
        currentDestination = chosenDestination.transform.position;
        foreach (GameObject destination in destinations)
        {
            if (destination != chosenDestination)
            {
                destination.gameObject.SetActive(false);
            }
        }
        return currentDestination;
    }

    public Vector3 CurrentDestination
    {
        get
        {
            return currentDestination;
        }
        set
        {
            currentDestination = value;
        }
    }
    public Vector3 CurrentPickUpPoint
    {
        get
        {
            return currentPickUpPoint;
        }
        set
        {
            currentPickUpPoint = value;
        }
    }
}
