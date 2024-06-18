using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillingTime : MonoBehaviour
{
    public int targetCount;
    public Text levelClearedText;
    
    //public GameObject Boss;
    //private int PVBoss = 2;

    void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        targetCount = targets.Length;
        levelClearedText.gameObject.SetActive(false);
        //Boss.gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            Destroy(collision.gameObject);
            targetCount--;
        }
        /*if (collision.gameObject.CompareTag("Boss"))
        {
           PVBoss--;
        }*/
        
    }
    void Update()
    {
        if (targetCount <= 0)
        {
            //Boss.gameObject.SetActive(true);
            levelClearedText.gameObject.SetActive(true);
        }
        /*if(PVBoss <= 0){
            Destroy(Boss);
            levelClearedText.gameObject.SetActive(true);
        }*/
    }
}
