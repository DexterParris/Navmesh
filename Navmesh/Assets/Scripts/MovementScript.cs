using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class MovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    string lastRotation;
    public float topSpeed;
    public NavMeshAgent agent;
    Vector3 directionToMove;
    public int playerlives = 3;

    public TextMeshProUGUI livestext;


    public GameObject upCube, downCube, leftCube, rightCube;



    public int playerspeed;

    public static bool Invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        livestext.text = "Lives: " + playerlives.ToString();
        Invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.Move(directionToMove);

        if (rb.velocity.magnitude > topSpeed)
        {
            rb.velocity = rb.velocity.normalized * topSpeed;
        }


        if (upCube.GetComponent<CubeScript>().IsTouchingGrid && lastRotation == "Up")
        {
            directionToMove = -Vector3.forward * playerspeed * Time.deltaTime;
            anim.Play(lastRotation);
        }
        else if (downCube.GetComponent<CubeScript>().IsTouchingGrid && lastRotation == "Down")
        {
            directionToMove = Vector3.forward * playerspeed * Time.deltaTime;
            anim.Play(lastRotation);
        }
        else if (leftCube.GetComponent<CubeScript>().IsTouchingGrid && lastRotation == "Left")
        {
            directionToMove = Vector3.right * playerspeed * Time.deltaTime;
            anim.Play(lastRotation);
        }
        else if (rightCube.GetComponent<CubeScript>().IsTouchingGrid && lastRotation == "Right")
        {
            directionToMove = Vector3.left * playerspeed * Time.deltaTime;
            anim.Play(lastRotation);
        }




        
        if(Input.GetAxisRaw("Vertical") >=0.1)
        {
            lastRotation = "Up";
        }
        else if(Input.GetAxisRaw("Vertical") <= -0.1)
        {
            lastRotation = "Down";
        }
        else if(Input.GetAxisRaw("Horizontal") >= 0.1)
        {
            lastRotation = "Right";
        }
        else if (Input.GetAxisRaw("Horizontal") <= -0.1)
        {
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
            playerspeed += 4;
            Invincible = true;
            Destroy(collision.gameObject);
            
        }

        if(collision != null && collision.gameObject.tag == "Ghost" && Invincible == true)
        {
            collision.gameObject.GetComponentInChildren<GhostScript>().Die();
        }
        else if(collision != null && collision.gameObject.tag == "Ghost" && Invincible != true)
        {
            playerlives -= 1;
            livestext.text = "Lives: " + playerlives.ToString();

            //kill the player
        }
    }

    IEnumerator InvulnTimer()
    {
        Debug.Log("AA EE OO");
        yield return new WaitForSeconds(7);
        Debug.Log("AA EE OO");
        Invincible = false;
        playerspeed -=4;
        yield return new WaitForSeconds(0.01f);
    }

}
