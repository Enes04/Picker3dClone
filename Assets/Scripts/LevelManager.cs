using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string LevelSt;
    public Text Leveltxt;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.GetInt("Level", 0);
        }
        if (PlayerPrefs.GetInt("Level") < 10)
        {
            LevelSt = PlayerPrefs.GetInt("Level").ToString();
            Instantiate(Resources.Load(LevelSt) as GameObject);
            Leveltxt.text = "Level: " + LevelSt.ToString();
        }else if(PlayerPrefs.GetInt("Level")>=10)
        {
            int rand = Random.Range(4, 9);
            LevelSt = PlayerPrefs.GetInt("Level").ToString();
            Instantiate(Resources.Load(rand.ToString()) as GameObject);
            Leveltxt.text = "Level: " + LevelSt.ToString();
        }
    }
    void Start()
    {
        Time.timeScale = 0;
    }
    public void StartButton()
    {
        Time.timeScale = 1;
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
