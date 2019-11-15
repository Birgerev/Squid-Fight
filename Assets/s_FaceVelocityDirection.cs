using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_FaceVelocityDirection : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((SpriteRenderer renderer, Rigidbody2D rigidbody, c_FaceDirection faceDirection) =>
        {
            float xVelocity = rigidbody.velocity.x;

            if(xVelocity != 0)
                renderer.flipX = (xVelocity < 0);
        });
    }
}
