using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform destTeleport;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            Vector3 speed = collision.gameObject.GetComponent<Rigidbody>().velocity;
            collision.transform.position = destTeleport.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().velocity = speed;

            GameObject.Find("Blue Ghost").GetComponent<Pathfinding>().RecalculateRoute();
            GameObject.Find("Red Ghost").GetComponent<Pathfinding>().RecalculateRoute();
            GameObject.Find("Orange Ghost").GetComponent<Pathfinding>().RecalculateRoute();
            GameObject.Find("Pink Ghost").GetComponent<Pathfinding>().RecalculateRoute();

        }
    }
}
