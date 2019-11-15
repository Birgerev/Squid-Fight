using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_SetHealthBarProgress : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_HealthBar healthBar) =>
        {
            c_Health health = healthBar.transform.GetComponentInParent<c_Health>();

            if(health == null)
            {
                Debug.LogError("c_HealthBar doesn't have a c_Health in parents");
                return;
            }

            healthBar.image.fillAmount = health.health / health.maxHealth;
        });
    }
}

