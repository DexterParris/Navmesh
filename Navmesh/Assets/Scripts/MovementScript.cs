using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    string lastRotation;
    public float topSpeed;

    public static bool Invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        Invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > topSpeed)
        {
            rb.velocity = rb.velocity.normalized * topSpeed;
        }

        anim.Play(lastRotation);
        if(Input.GetAxisRaw("Vertical") >=0.1)
        {
            rb.AddForce(-Vector3.forward*Time.deltaTime* 100);
            lastRotation = "Up";
        }
        else if(Input.GetAxisRaw("Vertical") <= -0.1)
        {
            rb.AddForce(Vector3.forward *Time.deltaTime * 100);
            lastRotation = "Down";
        }
        else if(Input.GetAxisRaw("Horizontal") >= 0.1)
        {
            rb.AddForce(Vector3.left * Time.deltaTime * 100);
            lastRotation = "Right";
        }
        else if (Input.GetAxisRaw("Horizontal") <= -0.1)
        {
            rb.AddForce(-Vector3.left * Time.deltaTime * 100);
            lastRotation = "Left";

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision !=null && collision.gameObject.tag == "Pellet")
        {
            Destroy(collision.gameObject);
        }

        if(collision != null && collision.gameObject.tag == "PowerUp")
        {
            StartCoroutine(InvulnTimer());
            topSpeed += 4;
            Invincible = true;
            Destroy(collision.gameObject);
            
        }

        if(collision != null && collision.gameObject.tag == "Ghost" && Invincible == true)
        {
            collision.gameObject.GetComponentInChildren<GhostScript>().Die();
        }
    }

    IEnumerator InvulnTimer()
    {
        Debug.Log("AA EE OO");
        yield return new WaitForSeconds(7);
        Debug.Log("AA EE OO");
        Invincible = false;
        topSpeed -=4;
        yield return new WaitForSeconds(0.01f);
    }

}
