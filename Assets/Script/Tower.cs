using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public double Damage;

    public double FireSpeed;
    private double timeToShoot;
    private Transform FirePoint;
    // Start is called before the first frame update
    void Start()
    {
        timeToShoot = FireSpeed / 60;

        FirePoint = gameObject.transform.Find("Icosphere");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tower detect");
    }
}
