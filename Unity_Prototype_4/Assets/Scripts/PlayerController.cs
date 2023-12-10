using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

       // playerRb.AddForce(Vector3.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
