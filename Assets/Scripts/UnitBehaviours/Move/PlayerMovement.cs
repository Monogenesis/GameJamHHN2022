using Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnitBehaviours.Move
{
    [CreateAssetMenu(fileName = "PlayerMovement", menuName = "ScriptableObjects/Behaviour/Movement/PlayerMovement", order = 1)]
    public class PlayerMovement : UnitMoveBehaviour
    {
        [SerializeField] private InputActionReference playerMovementAction;
        [SerializeField] private InputActionReference speedBonusAction;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float speedFactor = 1.5f;

        public override void Initialize()
        {
            playerMovementAction.action.Enable();
            speedBonusAction.action.Enable();
        }
        
        public override void Act(Unit unit)
        {
            var direction = playerMovementAction.action.ReadValue<Vector2>() * speed *
                            (1 + speedFactor * speedBonusAction.action.ReadValue<float>());
            unit.UnitMovement.AlignDirection(direction);
        }
    }
}