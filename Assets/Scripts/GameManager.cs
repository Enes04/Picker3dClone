using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Transform EndTransform;

    public GameObject DestroyParticle;
    public Slider ProgressBar;
    public GameObject Player;
    public GameObject WinPanel;
    public GameObject FailPanel;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
       
    }
    void Start()
    {
        EndTransform = GameObject.FindGameObjectWithTag("LevelEnd").transform;
        ProgressBar.maxValue = EndTransform.position.z - Player.transform.position.z;
    }
   
    void Update()
    {
        ProgressBar.value = ProgressBar.maxValue - (EndTransform.position.z - Player.transform.position.z);
    }
}
