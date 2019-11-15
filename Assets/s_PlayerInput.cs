using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class s_PlayerInput : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((c_Player player, c_Input input) =>
        {
            int id = player.id;

            KeyCode left;
            KeyCode right;
            KeyCode up;
            KeyCode down;
            
            left = KeyCode.A;
            right = KeyCode.D;
            up = KeyCode.W;
            down = KeyCode.S;
            if (id == 1)
            {
                left = KeyCode.LeftArrow;
                right = KeyCode.RightArrow;
                up = KeyCode.UpArrow;
                down = KeyCode.DownArrow;
            }

            if (Input.GetKey(left) || Input.GetKey(right))
                input.Horizontal = (Input.GetKey(right)) ? 1 : -1;
            else
                input.Horizontal = 0;


            input.Jump = (Input.GetKey(up));
            input.Duck = (Input.GetKey(down));
        });
    }
}
