using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Here we are creating a singleton for our ScoreManager
    static public ScoreManager Instance { get; private set; }

    public int score { get; private set; }

    public TextMeshProUGUI text;


    //Setting the inital value of our score
    //We use DontDestroyOnLoad to save our score from one scene to another
    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "Coins Collected: " + score.ToString();
    }
}
