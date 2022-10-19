using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public bool IsTouchingGrid;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.tag == "Path")
        {
            IsTouchingGrid = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject.tag == "Path")
        {
            IsTouchingGrid = false;
        }
    }

}
