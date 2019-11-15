using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_SetHealthBarColor : ComponentSystem
{
    private Color[] colors = new Color[] { new Color(0.23f, 0.23f, 1f), new Color(0.9f, 0.23f, 0.23f) };

    protected override void OnUpdate()
    {
        Entities.ForEach((c_HealthBar healthBar) =>
        {
            c_Player player = healthBar.transform.GetComponentInParent<c_Player>();

            if (player == null)
            {
                Debug.LogError("c_HealthBar doesn't have a c_Player in parents");
                return;
            }

            healthBar.image.color = colors[player.id];
        });
    }
}

