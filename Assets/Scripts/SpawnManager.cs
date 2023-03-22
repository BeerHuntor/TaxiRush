using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    //References
    [SerializeField] private List<GameObject> passengers;
    [SerializeField] private Player player; 


    //Local Variables
    private bool passengerWaiting;
    
    //Global Variables
    private GameObject currentPassenger;
   


    // Start is called before the first frame update
    void Start()
    {
        player.OnPassengerDisembark += Player_OnPassengerDisembark;
    }

    private void Player_OnPassengerDisembark(object sender, EventArgs e) {
        float timeToDelayBeforeSpawn = 10f;
        StartCoroutine(StartSpawnDelay(timeToDelayBeforeSpawn));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsStartOfGame()) {
            SpawnRandomPassenger();
        }
    }
    
    private void SpawnRandomPassenger()
    {
        int randomPassengerIndex = Random.Range(0, passengers.Count);
        currentPassenger = Instantiate(passengers[randomPassengerIndex], GameManager.instance.SetRandomPickupPointTransform().position, passengers[randomPassengerIndex].transform.rotation);
        currentPassenger.TryGetComponent(out Passenger passenger);
        passenger.SetParent(GameManager.instance.GetCurrentPickupPoint().gameObject);
        passenger.Show();
    }

    public GameObject GetCurrentPassenger() {
        return currentPassenger;
    }

    private IEnumerator StartSpawnDelay(float delay) {
        yield return new WaitForSeconds(delay);
        SpawnRandomPassenger();
        Debug.Log("Spawning New Passenger!");
    }
    
}
