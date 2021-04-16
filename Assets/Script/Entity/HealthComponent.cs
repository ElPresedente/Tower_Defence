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
        }
    }
    public onZeroHealth onZeroHealth;

    public double _HealthPoints;
}
public delegate void onZeroHealth();
