using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        // keep player inbounds on the left
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        // keep player inbounds on the right
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // get user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        // move player in the x direction based on horizontal input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
