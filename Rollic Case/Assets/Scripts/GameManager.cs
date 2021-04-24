using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    GameObject[] Balls;
    Transform EndTransform;
    string LevelSt;

    public GameObject DestroyParticle;
    public Slider ProgressBar;
    public GameObject Player;
    public GameObject WinPanel;
    public GameObject FailPanel;

    public static GameManager instance;
    private void Awake()
    {
        print(PlayerPrefs.GetInt("Level"));
        instance = this;
        if(!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.GetInt("Level", 0);
        }
        LevelSt = PlayerPrefs.GetInt("Level").ToString();
        Instantiate(Resources.Load(LevelSt) as GameObject);
    }
    void Start()
    {
        StartCoroutine(setBalls());
        EndTransform = GameObject.FindGameObjectWithTag("LevelEnd").transform;
        ProgressBar.maxValue =  EndTransform.position.z - Player.transform.position.z;
    }
    IEnumerator setBalls()
    {
        yield return new WaitForSeconds(1f);
        Balls = GameObject.FindGameObjectsWithTag("Ball");
    }
    void Update()
    {
        ProgressBar.value = ProgressBar.maxValue - (EndTransform.position.z - Player.transform.position.z);
    }
    
    public void FinishDistanceBall(GameObject finishposition)
    {
        for (int i = 0; i < Balls.Length; i++)
        {
            if (Mathf.Abs(Balls[i].transform.position.z - finishposition.transform.position.z)<6f)
            {
                Balls[i].GetComponent<Rigidbody>().AddForce(Vector3.forward * 350);
            }
        }
    }

    public void LevelStart()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene("SampleScene");
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
