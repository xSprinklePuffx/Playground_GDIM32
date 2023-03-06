using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarTwo : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Making the progressBarOne active in the inspector
    [SerializeField] private Image progressBarTwo;

    //Our Progress Bar will be hiden unless we collide with the checkpoint
    void Start()
    {
        progressBarTwo.enabled = false;
    }

    //When our player collides with the first checkpoint, the 50% progress bar will appear
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            progressBarTwo.enabled = true;
        }
    }
}
