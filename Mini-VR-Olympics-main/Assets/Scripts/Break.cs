using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breakable"))
        {

            Destroy(other.gameObject);
            audio.Play();
        }
    }
}

