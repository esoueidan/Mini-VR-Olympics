using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoShooter : MonoBehaviour
{
   public void loadShooter()
    {
        SceneManager.LoadScene("map_shooting");
    }
}
