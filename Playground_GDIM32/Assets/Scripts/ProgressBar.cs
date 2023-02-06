using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is for implementing a progress bar
public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private ParticleSystem particleSys; //adds sparkle effect to the progress bar

    public float LoadSpeed = 0.5f; 
    private float levelProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("Progress Bar Particles").GetComponent<ParticleSystem>();
    }
    void Start()
    {
        IncreaseProgress (0.50f);
    }


    void Update()
    {
        if (slider.value < levelProgress)
        {
            slider.value += LoadSpeed * Time.deltaTime; //makes sure the particle system effect plays and stops after reaching the halfway point
            if (!particleSys.isPlaying)
                particleSys.Play();
        }
        else
        {
            particleSys.Stop();
        }

    }
    public void IncreaseProgress(float newProgress)
    {
        levelProgress = slider.value + newProgress;
    }
}
