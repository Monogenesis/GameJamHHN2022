using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using EditorScripts;
#endif
using Units;
using UnityEngine;

namespace UnitBehaviours.Attack
{
    [CreateAssetMenu(fileName = "MeleeSoldierAttackBehaviour",
        menuName = "ScriptableObjects/Behaviour/Offensive/MeleeSoldierAttackBehaviour", order = 2)]
    public class MeleeSoldierAttackBehaviour : UnitAttackBehaviour
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

        private ContactFilter2D _searchFilter = default;
        private Unit _attackTarget = default;
        private float _nextActionIn = default;

        private void OnValidate()
        {
            damagePerSecond = attackDamage / attackCooldown;
        }

        public override void Initialize()
        {
            base.Initialize();
            _searchFilter.layerMask = attackTargetLayer;
            _nextActionIn = attackCooldown;
        }

        public override void Act(Unit unit)
        {
            _nextActionIn += Time.deltaTime;
            if (_nextActionIn >= attackCooldown)
            {
                _nextActionIn = 0f;
                FindAttackTarget(unit);

                if (_attackTarget != null)
                {
                    Attack();
                }
            }
        }

        private void Attack()
        {
            _attackTarget.ChangeHealth(-attackDamage);
        }

        private void FindAttackTarget(Unit unit)
        {
            List<Collider2D> results = new();
            Collider2D attackTargetCollider;

            unit.GetComponent<Collider2D>().enabled = false;
            Physics2D.OverlapCircle(new Vector2(unit.transform.position.x, unit.transform.position.y),
                attackRange, _searchFilter, results);
            unit.GetComponent<Collider2D>().enabled = true;

            attackTargetCollider = results.Where(col => unit.EnemyRace.Contains(col.GetComponent<Unit>().OwnFaction))
                .OrderBy(attackUnit =>
                    Vector3.Distance(attackUnit.transform.position, unit.transform.position)).FirstOrDefault();

            if (attackTargetCollider is not null &&
                Vector3.Distance(attackTargetCollider.transform.position, unit.transform.position) <= attackRange)
            {
                _attackTarget = attackTargetCollider.GetComponent<Unit>();
            }
        }
    }
}