using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;


    public NavMeshAgent nav;
    public int destPoint;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementScript.Invincible)
        {
            destPoint = 1;
            GoToNextPoint();
        }
        else
        {
            destPoint = 0;
        }

        if (!nav.pathPending && nav.remainingDistance < 0.7f)
        {
            GoToNextPoint();
        }
        

    }

    void GoToNextPoint()
    {
        
        if(points.Length == 0)
        {
            return;

        }
        
        nav.destination = points[destPoint].position;
        
        

    }

    public void RecalculateRoute()
    {
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    
}
