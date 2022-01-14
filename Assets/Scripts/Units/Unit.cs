using System;
using System.Collections.Generic;
using UnitBehaviours.Attack;
using UnitBehaviours.Move;
using UnityEngine;
using Untility;

namespace Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitMovement unitMovement;
        [SerializeField] private UnitMoveBehaviour unitMoveBehaviour;
        [SerializeField] private UnitAttackBehaviour unitAttackBehaviour;
        [SerializeField] private HealthComponent healthComponent;
        
        public UnitMovement UnitMovement => unitMovement;


        private void Awake()
        {
            unitMoveBehaviour.Initialize();
            unitAttackBehaviour.Initialize();
        }

        private void Update()
        {
            unitMoveBehaviour.Act(this);
            unitAttackBehaviour.Act(this);
        }

        // public static List<EnemyUnit> GetEnemiesInRadius(Vector2 origin, float radius)
        // {
        //     List<EnemyUnit> result = new();
        //     
        //     EnemyUnit.AliveEnemies.
        //
        //
        //     return result;
        // }
    }
}