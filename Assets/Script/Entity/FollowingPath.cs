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
        transform.position = Vector3.MoveTowards(transform.position, gameManager.VectorPath[currentPathPoint], Time.deltaTime * MovementSpeed * 0.5f);
        float remainDistance = (gameManager.VectorPath[currentPathPoint] - transform.position).magnitude;
        if(remainDistance <=0.05f)
        {
            currentPathPoint++;
        }
        transform.rotation = Quaternion.LookRotation(gameManager.VectorPath[currentPathPoint] - transform.position);   
    }

    

}
