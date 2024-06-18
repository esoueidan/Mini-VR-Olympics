using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoClimbing : MonoBehaviour
{
    public void loadClimbing()
    {
        SceneManager.LoadScene("Climbing");
    }

}
