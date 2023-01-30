using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private ScoreManager scoreManager;


    void Start()
    {
        GameObject scoreManagerObject = GameObject.FindWithTag("Player");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    void Update()
    {
        scoreText.text = $"Coins Collected: {scoreManager.score}";
    }
}
