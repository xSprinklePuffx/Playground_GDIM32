using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RespawnMenu : MonoBehaviour
{
    public int respawnTime;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject RespawnMenuCanvas;

    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (respawnTime > 0)
        {
            countdownText.text = "Respawning in... " + respawnTime.ToString();

            yield return new WaitForSeconds(1f);

            respawnTime--;
        }

        yield return new WaitForSeconds(1f);

        RespawnMenuCanvas.SetActive(false);
    }
}
