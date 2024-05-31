using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//with the help of chatGPt for the search of the child renderer 
public class BurgerProjectile : MonoBehaviour
{
    public GameObject cube ;
    public Pointcompteur point;

    void Start()
    {
        point =  cube.GetComponent<Pointcompteur>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            Renderer targetRenderer = GetRendererInChildren(collision.gameObject);
            if (targetRenderer != null)
            {
                targetRenderer.material.color = Color.red;
                point.Addpoint();
            }
        }
    }
     private Renderer GetRendererInChildren(GameObject obj)
    {
        // Try to get the Renderer component directly from the object
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer;
        }

        // Try to get the SkinnedMeshRenderer component directly from the object
        SkinnedMeshRenderer skinnedRenderer = obj.GetComponent<SkinnedMeshRenderer>();
        if (skinnedRenderer != null)
        {
            return skinnedRenderer;
        }

        // If not found, search in the children
        renderer = obj.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            return renderer;
        }

        // Search for SkinnedMeshRenderer in the children
        skinnedRenderer = obj.GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedRenderer != null)
        {
            return skinnedRenderer;
        }

        // Return null if no renderer found
        return null;
    }
}
