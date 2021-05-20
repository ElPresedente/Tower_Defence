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
        Health.onZeroHealth = StaticGameManager.GameManager.OnCitadelDie;
        Health.onDamageGet = OnDamageGet;

        Collider = gameObject.AddComponent<SphereCollider>();
        Collider.radius = 0.6f;
        Collider.isTrigger = true;

        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }
    void OnDamageGet()
    {
        StaticGameManager.GameManager.LevelUI.GetComponent<LevelUIController>().UpdateGameStat();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Enemy"))
        {
            Health.HealthPoints -= other.GetComponent<Enemy>().Damage;
            other.gameObject.SetActive(false);
            
        }
    }

}
