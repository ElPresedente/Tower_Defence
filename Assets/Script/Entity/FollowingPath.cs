using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPath : MonoBehaviour
{
    public float MovementSpeed;


    private GameManager gameManager;
    private int currentPathPoint;

    void Awake()
    {
        gameManager = transform.parent.GetComponent<GameManager>();
    }
    void Start()
    {
        currentPathPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, gameManager.PathArray[currentPathPoint].position, Time.deltaTime * MovementSpeed);
        float remainDistance = (gameManager.PathArray[currentPathPoint].position - transform.position).magnitude;
        if(remainDistance <=0.05f)
        {
            currentPathPoint++;
        }
        transform.rotation = Quaternion.Euler((gameManager.PathArray[currentPathPoint].position - transform.position).normalized);    
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ttwrresdf");
    }

}
