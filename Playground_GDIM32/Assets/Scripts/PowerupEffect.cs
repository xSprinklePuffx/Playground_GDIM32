using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    //Script by: Jacqueline Hernandez

    //In this scriptable object we are making two abstract methods\
    //The Apply method will apply the effect to our player
    //The Revert method will revert the power up conditions given to our player
    public abstract void Apply(GameObject target);
    public abstract void Revert(GameObject target);
}
