using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public double HealthPoints;
    public onZeroHealth zeroFunction;

    public void GetDamage(double dmg)
    {
        HealthPoints -= dmg;
        if(HealthPoints <= 0)
        {
            zeroFunction();
        }
    }
}
public delegate void onZeroHealth();
