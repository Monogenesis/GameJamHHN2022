using Units;
using UnityEngine;

namespace UnitBehaviours.Move
{
    [CreateAssetMenu(fileName = "CircleMoveBehaviour", menuName = "ScriptableObjects/Behaviour/UnitMoveInCirclesBehaviour", order = 1)]

    public class UnitMoveInCirclesBehaviour : UnitMoveBehaviour
    {
        private UnitMovement _unitMovement;
        public override void Act(Unit unit)
        {
            _unitMovement = unit.UnitMovement;
            _unitMovement.AlignDirection(new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)));
        }
    }
}