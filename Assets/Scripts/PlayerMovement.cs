using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sensivity;

    public static PlayerMovement instance;
    void Start()
    {
        instance = this; 
    }

    void Update()
    {
        transform.Translate(Vector3.forward *speed*Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            transform.Translate(new Vector3(Input.GetAxis("Mouse X") * sensivity * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            speed = 0f;
            BallsDistance.instance.FinishDistanceBall(other.gameObject);
        }
    }
    
}
