using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public Animator animator;

    Vector2 GenerateDirection()
    {
        return new Vector2(Random.value * 2 - 1, Random.value * 2 - 1);
    }

    void FixedUpdate()
    {
        rigidbody2d.AddForce(GenerateDirection());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Flame") {
            animator.SetBool("IsBurning", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2d.velocity.x < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
