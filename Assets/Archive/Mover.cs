using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class Mover : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeed moveSpeed) =>
        {
            translation.Value.y += moveSpeed.moveSpeed * Time.deltaTime;

            if(translation.Value.y > 5f)
            {
                moveSpeed.moveSpeed = -math.abs(moveSpeed.moveSpeed);
            }
            if (translation.Value.y < -5f)
            {
                moveSpeed.moveSpeed = +math.abs(moveSpeed.moveSpeed);
            }
        });
    }
}
