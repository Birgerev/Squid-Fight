using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LevelUp : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Level level) =>
        {
            level.level += 1f * Time.deltaTime;
        });
    }
}
