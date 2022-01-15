using DefaultNamespace;
using Units;
using UnityEngine;

namespace UnitBehaviours.Attack
{
    [CreateAssetMenu(fileName = "PeacefulAttackBehaviour", menuName = "ScriptableObjects/Behaviour/UnitPeacefulAttackBehaviour", order = 2)]

    public class PeacefulAttackBehaviour : UnitAttackBehaviour
    {
        public override void Act(Unit unit)
        {
        }
    }
}