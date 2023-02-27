using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarOne : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Making the progressBarOne active in the inspector
    [SerializeField] private Image progressBarOne;

    //Our Progress Bar will be hiden unless we collide with the checkpoint
    void Start()
    {
        progressBarOne.enabled = false;
    }

    //When our player collides with the first checkpoint, the 25% progress bar will appear
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            progressBarOne.enabled = true;
        }
    }
}
