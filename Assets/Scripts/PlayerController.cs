using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference playerMovementAction;
    [SerializeField] private InputActionReference speedBonusAction;
    [SerializeField] private Rigidbody2D characterController;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedFactor = 1.5f;

    void Start()
    {
        playerMovementAction.action.Enable();
        speedBonusAction.action.Enable();
    }

    private void FixedUpdate()
    {
        characterController.velocity = playerMovementAction.action.ReadValue<Vector2>() * speed * (1 + speedFactor * speedBonusAction.action.ReadValue<float>());
    }
}