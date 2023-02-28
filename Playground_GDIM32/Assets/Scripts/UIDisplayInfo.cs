using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplayInfo : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Making the UI text active in the inspector
    [SerializeField] private TMP_Text text;

    void Start()
    {
        text.enabled = false;
    }

    //When our player collides with the text trigger UI info will appear
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.enabled = true;
        }
    }

    //When our player leaves the text trigger UI info will dissapear
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }
}
