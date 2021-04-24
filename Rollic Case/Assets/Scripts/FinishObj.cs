using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FinishObj : MonoBehaviour
{
    public TextMeshProUGUI FinishValueText;
    public float finishvalue;
    public float currentvalue;
    public ObjectType myenum;
    public enum ObjectType
    {
        Checkpoint,
        Finishpoint
    }
    void Start()
    {
        FinishValueText.text = "0/" + finishvalue.ToString();
    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            currentvalue += 1;
            FinishValueText.text = currentvalue.ToString() + "/" + finishvalue.ToString();
            BallPoint(collision.gameObject);
            Invoke("CheckPoint", 2f);

        }
    }
    public void BallPoint(GameObject Ball)
    {
        Ball.transform.GetComponent<Rigidbody>().isKinematic = true;
        Ball.transform.GetComponent<Collider>().enabled = false;
        Ball.transform.GetComponent<MeshRenderer>().enabled = false;
        Ball.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(destroyobj(Ball.gameObject));
    }
    IEnumerator destroyobj(GameObject Ball)
    {
        yield return new WaitForSeconds(2f);
        Destroy(Ball.gameObject);
    }
    public void CheckPoint()
    {
        if(currentvalue >= finishvalue)
        {
            if (myenum == ObjectType.Checkpoint)
                NextCheckPoint();
            else if (myenum == ObjectType.Finishpoint)
            {
                FinishLevel();
            }
        }
        if (currentvalue < finishvalue)
        {
            RestarLevel();
        }
    }
    public void RestarLevel()
    {
        GameManager.instance.FailPanel.SetActive(true);
    }
    public void NextCheckPoint()
    {
        transform.DOLocalMove(new Vector3(transform.localPosition.x,0.3f, transform.localPosition.z), 1f).SetEase(Ease.OutQuart).OnComplete(() =>
              PlayerMovement.instance.speed = 3f
        );
    }
    public void FinishLevel()
    {
       
        GameManager.instance.WinPanel.SetActive(true);
    }
}
