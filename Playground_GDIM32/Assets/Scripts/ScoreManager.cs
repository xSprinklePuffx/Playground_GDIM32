using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public ScoreManager Instance { get; private set; }

    public int score { get; private set; }

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

    public void IncrementScore(int increment = 1)
    {
        score += increment;
    }
}
