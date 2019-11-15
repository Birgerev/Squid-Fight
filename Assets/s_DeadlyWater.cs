using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_DeadlyWater : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_Water water, Transform water_transform) =>
        {
            Entities.ForEach((c_Health health, Transform transform) =>
            {
                if (transform.position.y < water_transform.position.y)
                {
                    health.health = 0;
                }
            });
        });
    }
}

