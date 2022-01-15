using Units;
using UnityEngine;

namespace UnitBehaviours.Attack
{
    [CreateAssetMenu(fileName = "SingleHealBehaviour", menuName = "ScriptableObjects/Behaviour/Offensive/SingleHealBehaviour",
        order = 2)]
    public class SingleHealBehaviour : UnitAttackBehaviour
    {
        [SerializeField] private float healPower = 30f;
        [SerializeField] private float healRange = 10f;
        [SerializeField] private float healCooldown = 1f;
        [SerializeField] private LayerMask healLayer;

        private ContactFilter2D _searchFilter = default;

        private void Awake()
        {
            _searchFilter = new();
            _searchFilter.useLayerMask = true;
            _searchFilter.layerMask = healLayer;
        }

        public override void Act(Unit unit)
        {
        }
    }
}