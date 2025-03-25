using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Video : MonoBehaviour
{
    private Transform targetChild;
    
    private const float TOLERANCE = 0.01f; // Tolerance for float comparison

    public GameObject thumbnail;

    void Start()
    {
        if (transform.childCount >= 3)
        {
            targetChild = transform.GetChild(2); // Get the 3rd child (index 2)
        }
        else
        {
            Debug.LogError("This GameObject does not have enough children!");
        }
    }

    void Update()
    {
        if (targetChild == null) return;

        float scale = transform.localScale.x; // Assuming uniform scaling

        if (Mathf.Abs(scale - 1f) < TOLERANCE)
        {
            targetChild.gameObject.SetActive(true);
            thumbnail.SetActive(false);
        }
        else if (Mathf.Abs(scale - 0.8f) < TOLERANCE)
        {
            targetChild.gameObject.SetActive(false);
            thumbnail.SetActive(true);
        }
    }
}
