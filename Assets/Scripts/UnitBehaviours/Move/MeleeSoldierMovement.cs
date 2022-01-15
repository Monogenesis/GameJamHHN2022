using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unit = Units.Unit;

namespace UnitBehaviours.Move
{
    [CreateAssetMenu(fileName = "MeleeSoldierMovement",
        menuName = "ScriptableObjects/Behaviour/UnitMeleeSoldierMovement", order = 1)]
    public class MeleeSoldierMovement : UnitMoveBehaviour
    {
        [SerializeField] private float enemySearchRadius = 20f;
        [SerializeField] private float searchInterval = 5f;
        [SerializeField] private bool searchForEnemy = true;
        [SerializeField] private LayerMask searchLayer = default;
        
        private ContactFilter2D _searchFilter = default;
        private GameObject _moveTarget = default;
        private float _nextActionIn = default;
        
        public override void Initialize()
        {
            base.Initialize();
            _searchFilter = new ContactFilter2D();
            _searchFilter.useLayerMask = true;
            _searchFilter.layerMask = searchLayer;
            _nextActionIn = searchInterval;
        }

        public override void Act(Unit unit)
        {
            if (searchForEnemy)
            {
                _nextActionIn += Time.deltaTime;
                if (_nextActionIn >= searchInterval)
                {
                    _nextActionIn = 0f;
                    SearchForEnemies(unit);
                }
            }

            if (_moveTarget != null)
            {
                unit.UnitMovement.AlignDirection((_moveTarget.transform.position - unit.transform.position)
                    .normalized);
            }
        }

        private void MoveToTarget(GameObject target)
        {
            _moveTarget = target;
        }

        private void SearchForEnemies(Unit unit)
        {
            List<Collider2D> results = new();
            unit.GetComponent<Collider2D>().enabled = false;

            Physics2D.OverlapCircle(new Vector2(unit.transform.position.x, unit.transform.position.y),
                enemySearchRadius, _searchFilter, results);

            unit.GetComponent<Collider2D>().enabled = true;

            var tmp = results.OrderBy(attackUnit =>
                Vector3.Distance(attackUnit.transform.position, unit.transform.position)).FirstOrDefault();
                
            if (tmp && Vector3.Distance(tmp.transform.position, unit.transform.position) <= enemySearchRadius)
            {
                _moveTarget = tmp.gameObject;
            }
        }
    }
}