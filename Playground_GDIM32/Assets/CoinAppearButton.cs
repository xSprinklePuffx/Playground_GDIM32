using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAppearButton : MonoBehaviour
{
    public List<GameObject> appearables;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetBool("On", true);
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        foreach (GameObject obj in appearables)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(15);

        foreach (GameObject obj in appearables)
        {
            Destroy(obj);
        }
        anim.SetBool("On", false);
    }
}
