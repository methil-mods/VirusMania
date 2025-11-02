using System;
using Framework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Player
{
    [Serializable]
    public class PlayerMovements : Updatable<PlayerController>
    {
        [SerializeField] private float speed;
        [SerializeField] private InputActionReference moveAction;

        public override void Start(PlayerController controller)
        {
            moveAction.action.Enable();
        }

        public override void Update(PlayerController controller)
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>();
            Vector3 move = new Vector3(input.x, 0, input.y);
            controller.transform.position += move * (speed * Time.deltaTime);
        }
    }
}