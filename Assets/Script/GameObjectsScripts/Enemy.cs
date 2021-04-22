using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData;
    public HealthComponent HealthComp;
    public double Damage;
    private FollowingPath MovingComp;
    void Start()
    {
        HealthComp = gameObject.AddComponent<HealthComponent>();
        HealthComp.onZeroHealth = OnZeroHealth;
        HealthComp.HealthPoints = EnemyData.EnemyHealth;

        MovingComp = gameObject.AddComponent<FollowingPath>();
        MovingComp.MovementSpeed = EnemyData.EnemyMovementSpeed;


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