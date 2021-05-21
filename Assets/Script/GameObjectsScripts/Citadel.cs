using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citadel : MonoBehaviour
{
    public HealthComponent Health;
    public double StartHealth;
    private SphereCollider Collider;
    void Start()
    {
        Health = gameObject.AddComponent<HealthComponent>();
        Health.HealthPoints = StartHealth;
        Health.onZeroHealth = StaticGameManager.GameManager.OnCitadelDie;
        Health.onDamageGet = OnDamageGet;
        Health.traceDamage = true;

        Collider = gameObject.AddComponent<SphereCollider>();
        Collider.radius = 0.6f;
        Collider.isTrigger = true;

        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        Debug.Log("Citadel init success");
    }
    void OnDamageGet()
    {
        StaticGameManager.GameManager.LevelUI.GetComponent<LevelUIController>().UpdateGameStat();
        Debug.Log("Updated UI");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Enemy"))
        {
            Health.HealthPoints -= other.GetComponent<Enemy>().Damage;
            other.gameObject.SetActive(false);
            StaticGameManager.GameManager.NumberOfDeaths++;
        }
    }

}
