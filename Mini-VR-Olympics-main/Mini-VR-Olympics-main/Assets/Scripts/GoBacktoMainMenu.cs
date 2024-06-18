using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBacktoMainMenu : MonoBehaviour
{
    public void loadBackMainMenu()
    {
        SceneManager.LoadScene("Teleport");
        Debug.Log("Clicked");
    }
}
