using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class s_UsingItem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_ItemHolder holder) =>
        {
            if (holder.use)
            {
                GameObject obj = MonoBehaviour.Instantiate(holder.ItemPrefab);
                obj.transform.position = holder.usePosition.position;

                holder.use = false;
            }
        });
    }
}

