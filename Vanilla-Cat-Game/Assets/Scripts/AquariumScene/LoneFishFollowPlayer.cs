using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoneFishFollowPlayer : MonoBehaviour
{
 public Transform loneFish;
    public Rigidbody2D rb;
    private float moveSpeed = 5f;
    private Vector3 mainPos;
    public Animator animator;
    public float dist;
    private Transform player;

    // Start is called before the first frame update
    void Update()
    {   
        //defining variables
       loneFish = GameObject.FindWithTag("Pet").transform;
       player = GameObject.FindWithTag("Player").transform;

        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        dist = Vector3.Distance(loneFish.position, player.transform.position);

        float direction = Mathf.Sign(loneFish.transform.position.x);
        transform.localScale(direction, 1, 1);

        //<summary>
        //fish following player only on the x axis
        //stopping on when on the same point on the x-axis
        if (loneFish.transform.position.x != player.transform.position.x)
        {
            mainPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, mainPos, moveSpeed * Time.deltaTime);

            animator.Play("Moving");
        }
  if (dist < 5.0f)
        {
            animator.Play("Close Distance");

        }

        else
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            animator.Play("Idle");
        }

        // //<summary>
        // //if fish is on the left side of player, then dog animations walks right
        // //if fish is on the right side of player, then dog animations walks left
        // //when fish doesn't move
        // if (loneFish.position.x < player.position.x)
        // {
        //     animator.Play("Right");
        // }
        // else if (loneFish.position.x > player.position.x)
        // {
        //     animator.Play("Left");
        // }
        // else
        // {
        //     animator.Play("Idle");
        // }
    }

}
