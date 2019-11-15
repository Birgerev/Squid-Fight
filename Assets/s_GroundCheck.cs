using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class s_GroundCheck : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_GroundCheck groundCheck, Transform transform) =>
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll((Vector2)transform.position, Vector2.down, groundCheck.GroundDistance);

            foreach(RaycastHit2D hit in hits)
            {
                if (hit.transform != transform)
                {
                    groundCheck.Grounded = true;
                    return;
                }
            }

            groundCheck.Grounded = false;
        });
    }
}
