using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_SquidJumping : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_Squid squid, Rigidbody2D rigidbody, c_Input input, c_GroundCheck groundCheck) =>
        {
            Vector2 velocity = rigidbody.velocity;

            //Jumping
            if (groundCheck.Grounded && input.Jump && velocity.y == 0)
            {
                velocity.y += squid.JumpHeight;
            }

            rigidbody.velocity = velocity;
        });
    }
}
