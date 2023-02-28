using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Creating a list of camera GameObjects
    public GameObject[] Cameras;

    //The camera we are currently on
    int currentCam;

    //Of course we start at camera at index level 0
    //We set the camera to our camera at index level 0
    void Start()
    {
        currentCam = 0;
        setCam(currentCam);
    }

    //We use an update method to determine whether or not the player clicked the Tab button to switch cameras
    //We call a method toggleCam which will switch between the cameras
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleCam();
        }
    }

    //Each time Tab is pressed the camera will switch to a different one so we want to be sure to disable all ofther cameras besides the one we are on
    void setCam(int idx)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == idx)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    //Each time Tab is pressed the camera will switch to the camera at the next index number
    void toggleCam()
    {
        currentCam++;
        if (currentCam > Cameras.Length - 1)
            currentCam = 0;
        setCam(currentCam);
    }
}
