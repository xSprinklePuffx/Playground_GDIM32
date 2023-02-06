using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //Bool for when our menu is open
    //String name for our menus
    public string menuName;
    public bool open;

    //When our menu that we name in the inspector is called then we set the gameObject to active
    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    //When it is closed we set the menu to not active
    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}
