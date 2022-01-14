using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Units;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using Unit = Units.Unit;

namespace UnitBehaviours.Move
{
    [CreateAssetMenu(fileName = "MeleeSoldierMovement",
        menuName = "ScriptableObjects/Behaviour/UnitMeleeSoldierMovement", order = 1)]
    public class MeleeSoldierMovement : UnitMoveBehaviour
    {
        [SerializeField] private float enemySearchRadius = 20f;
        [SerializeField] private float searchIntervall = 5f;
        [SerializeField] private bool searchForEnemy = true;
        [SerializeField] private ContactFilter2D searchFilter;

        // private UnitMovement _unitMovement;
        private Vector3 _moveTarget;
        private float _nextActionIn = 0f;

        public override void Act(Unit unit)
        {
            if (searchForEnemy)
            {
                _nextActionIn += Time.deltaTime;
                if (_nextActionIn >= searchIntervall)
                {
                    _nextActionIn = 0f;
                    SearchForEnemies(unit);
                }
            }

            unit.UnitMovement.AlignDirection((_moveTarget - unit.transform.position)
                .normalized);
        }

        private void MoveToTarget(Vector3 targetPosition)
        {
            _moveTarget = targetPosition;
        }

        private void SearchForEnemies(Unit unit)
        {
            List<Collider2D> results = new();
            unit.GetComponent<Collider2D>().enabled = false;

            Physics2D.OverlapCircle(new Vector2(unit.transform.position.x, unit.transform.position.y),
                enemySearchRadius, searchFilter, results);

            unit.GetComponent<Collider2D>().enabled = true;

            _moveTarget = results
                .Where(collider2D =>
                    Vector3.Distance(collider2D.transform.position, unit.transform.position) <=
                    enemySearchRadius)
                .OrderBy(collider2D => Vector3.Distance(collider2D.transform.position, unit.transform.position)).First()
                .transform.position;

            // _moveTarget = results
            //     .Where(collider2D => Vector3.Distance(collider2D.transform.position, unit.transform.position) <=
            //                          enemySearchRadius)
            //     .OrderBy(collider2D => Vector3.Distance(collider2D.transform.position, unit.transform.position)).First()
            //     .GetComponent<Unit>();
        }
    }
}