using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraHolder : MonoBehaviour
{
    public GameObject cameraHolder;
    public Vector3 offset;

    PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void OnStartAuthority()
    {
        if (view.IsMine)
        {
            cameraHolder.SetActive(true);
        }
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            cameraHolder.transform.position = transform.position + offset;
        }
    }
}
