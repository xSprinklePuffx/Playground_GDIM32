using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //I create a gameObject called firepoint on the player prefab so that I am able to instantate a bullet given the location of the firepoint\
    //I also created a bullet prefab that will be shot everytime the player shoots
    public Transform firePoint;
    public GameObject bulletPrefab;

    //Initializing an audiosource for the shooting sound effect;
    [SerializeField] private AudioSource shootSoundEffect;

    //Update is called everytime the shift key is pressed (Fire1)
    //The shoot sound effect plays
    //Shoot method is called
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shootSoundEffect.Play();
            Shoot();
        }
    }

    //The shoot method instantiates the bullet given the firepoint's position and roatation
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
