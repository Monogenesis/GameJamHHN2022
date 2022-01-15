using DefaultNamespace;
#if UNITY_EDITOR
using EditorScripts;
#endif
using UnityEngine;

namespace UnitBehaviours.Attack
{
    public abstract class UnitAttackBehaviour : UnitBehaviour
    {
        [SerializeField]
#if UNITY_EDITOR
        [ReadOnly]
#endif
        private float damagePerSecond;

        [SerializeField] protected float attackDamage = 20f;
        [SerializeField] protected float attackCooldown = 1f;
        [SerializeField] protected float attackRange = 1f;
        [SerializeField] protected LayerMask attackTargetLayer = default;
#if UNITY_EDITOR
#endif

        private void OnValidate()
        {
            damagePerSecond = attackDamage / attackCooldown;
        }
    }
}