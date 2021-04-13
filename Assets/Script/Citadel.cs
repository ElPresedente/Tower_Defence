using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citadel : MonoBehaviour
{
    private HealthComponent health;
    void Start()
    {
        health = gameObject.AddComponent<HealthComponent>();
        health.HealthPoints = 100d;
        health.zeroFunction = onCitadelDie;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.CompareTag("Enemy"))
        {
            health.GetDamage(10);
            other.gameObject.SetActive(false);
        }
    }
    void onCitadelDie()
    {
        Debug.Log("Loose");
    }
}
