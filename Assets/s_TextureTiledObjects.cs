using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class s_TextureTiledObjects : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_TiledObject tiledObject, SpriteRenderer renderer, Transform transform) =>
        {
            bool left = checkTiledObjects(transform, new Vector2(-1, 0));
            bool right = checkTiledObjects(transform, new Vector2(1, 0));

            Sprite sprite = tiledObject.lonely;

            if (left)
                sprite = tiledObject.right;
            if (right)
                sprite = tiledObject.left;
            if (left && right)
                sprite = tiledObject.middle;

            renderer.sprite = sprite;
        });
    }

    private bool checkTiledObjects(Transform transform, Vector2 relativePos)
    {
        RaycastHit2D[] leftHits = Physics2D.BoxCastAll((Vector2)transform.position + relativePos, new Vector2(0.7f, 0.7f), 0, new Vector2(0, 0));
        foreach (RaycastHit2D hit in leftHits)
        {
            if (hit.transform.GetComponent<c_TiledObject>() != null && hit.transform != transform)
            {
                return true;
            }
        }

        return false;
    }
}

