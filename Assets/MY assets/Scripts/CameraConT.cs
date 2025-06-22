using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConT : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float forwardInput;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);

    }
}
