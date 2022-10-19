using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public Animator anim;
    NavMeshAgent agent;
    GameObject myObject;
    public Rigidbody rb;

    Quaternion oldRotation;
    Quaternion currentRotation;

    private int frames;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;

        if (frames % 10 == 0)
        {
            yRotation = (Quaternion.Inverse(oldRotation) * currentRotation).eulerAngles.y;
            oldRotation = currentRotation;
            anim.SetFloat("TurnAngle", yRotation);
        }
        anim.SetFloat("Blend", agent.velocity.magnitude);

        currentRotation = gameObject.transform.rotation;
        

        Debug.Log(yRotation);

    }

  

}
