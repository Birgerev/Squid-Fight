using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_SquidDoubleJumping : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_Squid squid, Rigidbody2D rigidbody, c_Input input, c_GroundCheck groundCheck) =>
        {
            Vector2 velocity = rigidbody.velocity;
            
            if (!groundCheck.Grounded && !squid.HasDoubleJumped && input.Jump && velocity.y <= 0)
            {
                velocity.y = squid.DoubleJumpHeight;
                
                squid.HasDoubleJumped = true;
            }

            rigidbody.velocity = velocity;
        });
    }
}
