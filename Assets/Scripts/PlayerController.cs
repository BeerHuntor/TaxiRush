using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BUGGY AS HELL.... PASSENGER DELIVERY DOESN'T WORK AS INTENDED. 
public class PlayerController : MonoBehaviour
{
    private SpawnManager spawnManager;
    private GameObject passengerScript;
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public float turnRate;

    void Start()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            transform.Rotate(0, 0, -horizontalInput * turnRate * Time.deltaTime);
        }
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PickupTrigger")
        {
            GameManager.instance.HasPassenger = true;
            GameManager.instance.PassengerWaiting = false;
            spawnManager.currentPassenger.gameObject.SetActive(false);
            spawnManager.GetDestination();

        }

        if (other.gameObject.CompareTag("Destination"))
        {
            GameManager.instance.HasPassenger = false;
            spawnManager.currentPassenger.gameObject.SetActive(true);
            spawnManager.currentPassenger.gameObject.transform.position = this.transform.position; 
            spawnManager.CurrentDestination = Vector3.zero;
        }
    }

}
