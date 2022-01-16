using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnitBehaviours.Attack
{
    [CreateAssetMenu(fileName = "SingleHealBehaviour",
        menuName = "ScriptableObjects/Behaviour/Offensive/SingleHealBehaviour",
        order = 2)]
    public class SingleHealBehaviour : UnitAttackBehaviour
    {
        [SerializeField] private float healPower = 30f;
        [SerializeField] private float healRange = 10f;
        [SerializeField] private float healRadius = 3f;
        [SerializeField] private float healCooldown = 1f;
        [SerializeField] private LayerMask healLayer;
        [SerializeField] private InputActionReference mousePosition;
        [SerializeField] private InputActionReference mouseClick;

        private ContactFilter2D _searchFilter = default;
        private Camera _camera;
        private bool _canHeal;
        private float _nextActionIn = default;

        private void Awake()
        {
            mouseClick.action.Enable();
        }

        public override void Initialize()
        {
            base.Initialize();
            _searchFilter = new ContactFilter2D();
            _searchFilter.useLayerMask = true;
            _searchFilter.layerMask = healLayer;

            _camera = Camera.main;
            mousePosition.action.Enable();
            mouseClick.action.performed += (ctx) => { HealUnit(); };
        }

        private void HealUnit()
        {
            List<Collider2D> results;
            if (_canHeal)
            {
                var mousepos = _camera.ScreenToWorldPoint(mousePosition.action.ReadValue<Vector2>());

                results = new();
                _canHeal = false;

                Physics2D.OverlapCircle(mousepos,
                    healRadius, _searchFilter, results);

                foreach (var col in results)
                {
                    Unit unit = col.GetComponent<Unit>();
                    unit.ChangeHealth(healPower);
                }

                // Debug.Log($"Healed {results.Count} Units!");
            }
        }

        public override void Act(Unit unit)
        {
            if (!_canHeal)
            {
                _nextActionIn += Time.deltaTime;
                if (_nextActionIn >= healCooldown)
                {
                    _nextActionIn = 0f;

                    _canHeal = true;
                }
            }
        }
    }
}