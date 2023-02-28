using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFour : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Making the progressBarOne active in the inspector
    [SerializeField] private Image progressBarFour;

    //Our Progress Bar will be hiden unless we collide with the checkpoint
    void Start()
    {
        progressBarFour.enabled = false;
    }

    //When our player collides with the first checkpoint, the 100% progress bar will appear
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            progressBarFour.enabled = true;
        }
    }
}
