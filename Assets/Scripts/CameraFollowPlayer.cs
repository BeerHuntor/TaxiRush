using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    private Vector3 cameraOffset; 
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = new Vector3(0,0,-10f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position + cameraOffset; 
    }
}
