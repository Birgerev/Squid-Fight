using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_SquidAnimation : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Animator animator, Rigidbody2D rigidbody, c_Input input, c_GroundCheck groundCheck) =>
        {
            Vector2 velocity = rigidbody.velocity;

            if (groundCheck.Grounded)
            {
                animator.SetBool("Jumping", false);
                animator.SetBool("Falling", false);
            }
            if (input.Jump)
                animator.SetBool("Jumping", true);
            if(velocity.y < 0)
                animator.SetBool("Falling", true);

            animator.SetBool("Duck", (input.Duck && !input.Jump));

            animator.SetFloat("AbsHorizontalInput", math.abs(input.Horizontal));
        });
    }
}
