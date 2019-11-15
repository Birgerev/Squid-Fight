using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_SquidMovement : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_Squid squid, Rigidbody2D rigidbody, c_Input input, c_GroundCheck groundCheck) =>
        {
            Vector2 velocity = rigidbody.velocity;


            if (groundCheck.Grounded)
                squid.HasDoubleJumped = false;


            //Accelerating & Deaccelerating
            if (input.Horizontal != 0 && !input.Duck)
            {
                float acceleration = (groundCheck.Grounded) ? squid.Acceleration : squid.AirAcceleration;

                if ((velocity.x > 0 && input.Horizontal < 0) || (velocity.x < 0 && input.Horizontal > 0))
                    acceleration = squid.FlipAcceleration;
                                
                velocity.x += input.Horizontal * acceleration * Time.deltaTime;
            }
            else
            {
                float deacceleration = (groundCheck.Grounded) ? squid.Deacceleration : squid.AirDeacceleration;

                velocity.x *= deacceleration;
            }

            velocity.x = math.clamp(velocity.x, -squid.MaxSpeed, squid.MaxSpeed);
            
            rigidbody.velocity = velocity;
        });
    }
}
