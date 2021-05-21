    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public double HealthPoints
    {
        get => _HealthPoints;
        set
        {
            _HealthPoints = value;
            if(_HealthPoints <= 0)
            {
                onZeroHealth();
            }
            else if(traceDamage)
            {
                onDamageGet();
            }
        }
    }
    public onZeroHealth onZeroHealth;

    public onDamageGet onDamageGet;

    public double _HealthPoints;

    public bool traceDamage = false;
}
public delegate void onZeroHealth();
public delegate void onDamageGet();
