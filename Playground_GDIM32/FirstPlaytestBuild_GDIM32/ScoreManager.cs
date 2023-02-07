using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Here we are creating a singleton for our ScoreManager
    static public ScoreManager Instance { get; private set; }

    public int score { get; private set; }


    //Setting the inital value of our score
    //We use DontDestroyOnLoad to save our score from one scene to another
    private void Start()
    {
        score= 0;

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //Our score will go up by one each time
    public void IncrementScore(int increment = 1)
    {
        score += increment;
    }
}
