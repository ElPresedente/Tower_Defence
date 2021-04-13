using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public double Damage;
    public float MovementSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position, Time.deltaTime * MovementSpeed);
    }
}
