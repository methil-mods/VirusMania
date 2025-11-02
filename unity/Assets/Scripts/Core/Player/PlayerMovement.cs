using System;
using Framework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Player
{
    [Serializable]
    public class PlayerMovement : Updatable<PlayerController>
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float acceleration = 10f;
        [SerializeField] private InputActionReference moveAction;

        private Rigidbody rb;
        private Vector3 currentVelocity;

        public override void Start(PlayerController controller)
        {
            moveAction.action.Enable();
            rb = controller.body.GetComponent<Rigidbody>();
            if (rb == null) rb = controller.body.gameObject.AddComponent<Rigidbody>();
        }

        public override void FixedUpdate(PlayerController controller)
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>();
            Vector3 targetVelocity = new Vector3(input.x, 0, input.y) * speed;
            currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            Vector3 velocityChange = currentVelocity - rb.linearVelocity;
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}