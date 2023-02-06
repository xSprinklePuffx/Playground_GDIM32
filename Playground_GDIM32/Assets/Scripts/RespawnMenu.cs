using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RespawnMenu : MonoBehaviour
{
    //Serializing respawn time
    //Serializing our countdown text
    //Serializing the respawn menu that will be displayed when our player dies
    [SerializeField] int respawnTime;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject RespawnMenuCanvas;

    //Starting our coroutine
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    //The countdown text will be the same number as our respawnTime
    //The respawnMenu will be active until the respawnTime has reached the end, then it will be set to false
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
