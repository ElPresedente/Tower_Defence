using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData;
    public HealthComponent Health;
    public double Damage;
    private FollowingPath MovingComp;
    void Start()
    {
        Health = gameObject.AddComponent<HealthComponent>();
        Health.onZeroHealth = OnZeroHealth;

        MovingComp = gameObject.AddComponent<FollowingPath>();
        MovingComp.MovementSpeed = StaticGameManager.EnemyMovementSpeed;

        Damage = StaticGameManager.EnemyDamage;
    }

    void OnZeroHealth()
    {
        gameObject.SetActive(false);
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    
    //}
}
