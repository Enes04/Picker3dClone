using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsDistance : MonoBehaviour
{
    public GameObject[] Balls;
    public static BallsDistance instance;

    private void Awake()
    {
        instance = this;
    }
    public void FinishDistanceBall(GameObject finishposition)
    {
        Balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < Balls.Length; i++)
        {
            if ((finishposition.transform.position.z- Balls[i].transform.position.z) < 6f && (finishposition.transform.position.z - Balls[i].transform.position.z) > 0 )
            {
                Balls[i].GetComponent<Rigidbody>().AddForce(Vector3.forward * 350);
            }
        }
    }
}
