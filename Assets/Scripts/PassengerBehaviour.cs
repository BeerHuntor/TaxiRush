using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerBehaviour : MonoBehaviour
{
    private SpawnManager spawnManager;
    private Collider2D col; 
    private float timeBeforeDestroy; 
    void Start()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        col = gameObject.GetComponentInChildren<BoxCollider2D>();
        col.isTrigger = true;
        this.gameObject.SetActive(true);
        timeBeforeDestroy = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.HasPassenger == false)
        {
            this.gameObject.SetActive(true);
        }
        if (GameManager.instance.HasPassenger && !GameManager.instance.PassengerWaiting)
        {
            WhenPickedUp();
        }

    }
    private void WhenAtDestination()
    {
        Debug.Log("Passenger Delivered!");
        this.transform.position = spawnManager.CurrentDestination;
    }
    private void WhenPickedUp()
    {
        Debug.Log("Picked up passenger");
        spawnManager.currentPassenger.gameObject.SetActive(false);
        spawnManager.currentPassenger.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnManager.currentPassenger.gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        col.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Destination"))
        {
            StartCoroutine("DestroyPassenger");
            WhenAtDestination();
        }
    }
    IEnumerator DestroyPassenger()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(spawnManager.currentPassenger.gameObject);

    }
}
