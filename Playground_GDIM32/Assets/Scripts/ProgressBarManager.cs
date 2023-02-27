using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBarManager : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Here we are creating a singleton for our ProgressBarManager
    static public ProgressBarManager Instance { get; private set; }

    public int progress { get; private set; }

    public TextMeshProUGUI text;


    //Setting the inital value of our score
    //We use DontDestroyOnLoad to save our score from one scene to another
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeProgress(int progressValue)
    {
        progress += progressValue;
        text.text = "Lvl Progress:"  + progress.ToString();
    }
}
