using Units;
using UnityEngine;

namespace UnitBehaviours.Move
{
    [CreateAssetMenu(fileName = "IdleMovement", menuName = "ScriptableObjects/Behaviour/Movement/UnitIdleMovement", order = 1)]

    public class IdleMovement : UnitMoveBehaviour
    {
        public override void Act(Unit unit)
        {
        }
    }
}