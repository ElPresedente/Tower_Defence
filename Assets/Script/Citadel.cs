using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citadel : MonoBehaviour
{
    private HealthComponent Health;
    private SphereCollider Collider;
    void Start()
    {
        Health = gameObject.AddComponent<HealthComponent>();
        Health.onZeroHealth = OnZeroHealth;

        Collider = gameObject.AddComponent<SphereCollider>();
        Collider.radius = 0.6f;
        Collider.isTrigger = true;

        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Enemy"))
        {
            Health.HealthPoints -= other.GetComponent<Enemy>().Damage;
            
        }
    }
    void OnZeroHealth()
    {
        Debug.Log("Loose");
    }
}
