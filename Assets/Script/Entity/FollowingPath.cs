using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPath : MonoBehaviour
{
    public float MovementSpeed;

    private int currentPathPoint;


    void Start()
    {
        currentPathPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, StaticGameManager.VectorPath[currentPathPoint], Time.deltaTime * MovementSpeed * 0.5f);
        float remainDistance = (StaticGameManager.VectorPath[currentPathPoint] - transform.position).magnitude;
        if(remainDistance <=0.05f)
        {
            currentPathPoint++;
        }
        transform.rotation = Quaternion.LookRotation(StaticGameManager.VectorPath[currentPathPoint] - transform.position);   
    }

    

}
