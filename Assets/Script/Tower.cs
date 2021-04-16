using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public double Damage;
    public double FireSpeed;

    private double timeToShoot;

    private Transform FirePoint;

    private List<GameObject> EnemiesList = new List<GameObject>();


    void Start()
    {
        Damage = StaticGameManager.TowerDamage;
        FireSpeed = StaticGameManager.TowerFireSpeed;

        timeToShoot = 0;
        FirePoint = gameObject.transform.Find("Icosphere");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeToShoot -= Time.deltaTime;
        if (EnemiesList.Count != 0 && !EnemiesList[0].activeSelf)
        {
            EnemiesList.Remove(EnemiesList[0]);
        }
        if (EnemiesList.Count != 0 && timeToShoot <= 0)
        {
            Debug.Log("Shoot");
            timeToShoot = 60 / FireSpeed;
            GameObject bullet = Instantiate(StaticGameManager.GameManager.Bullet, FirePoint.position, new Quaternion(0, 0, 0, 0), StaticGameManager.GameManager.transform);
            bullet.AddComponent<Bullet>().Target = EnemiesList[0];
            bullet.GetComponent<Bullet>().Damage = Damage;
            bullet.GetComponent<Bullet>().MovementSpeed = StaticGameManager.BulletSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesList.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesList.Remove(other.gameObject);
        }
    }
}
