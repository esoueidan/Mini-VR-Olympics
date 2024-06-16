using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointcompteur : MonoBehaviour
{
    public int point = 0 ; 

    public void Addpoint(){
        point+=1;
        Debug.Log(point);
    }
}
