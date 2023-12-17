using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    public bool hasPowerUp = false;
    private float powerUpStrenght = 15f;
    public GameObject powerUpIndicator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }


    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // playerRb.AddForce(Vector3.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.right * speed * horizontalInput);

        powerUpIndicator.transform.position = playerRb.transform.position + new Vector3(0,0.3f,0);

        StartCoroutine(powerUpCountRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountRoutine());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator powerUpCountRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with enemy " + collision.gameObject.name + "with power up set to " + hasPowerUp);

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);

        }
    } 
}

