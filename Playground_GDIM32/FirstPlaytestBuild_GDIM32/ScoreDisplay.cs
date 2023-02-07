using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    //Script by: Markesha Cody Big

    //Score text which we can set in Unity
    //Reference to ScoreManager script
    [SerializeField] private TMP_Text scoreText;
    private ScoreManager scoreManager;

    //Wherever we find a reference to the GameObject ScoreManager we transfer teh score between scenes
    void Start()
    {
        GameObject scoreManagerObject = GameObject.FindWithTag("Player");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    //Update is called everytime we collect more fruit, our score text displays this increase
    void Update()
    {
        scoreText.text = $"Coins Collected: {scoreManager.score}";
    }
}
