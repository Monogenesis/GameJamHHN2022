using System;
using System.Collections.Generic;
using UnitBehaviours.Attack;
using UnitBehaviours.Move;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Untility;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitMovement unitMovement;
        [SerializeField] private UnitMoveBehaviour unitMoveBehaviour;
        [SerializeField] private UnitAttackBehaviour unitAttackBehaviour;
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private Fraction fraction = Fraction.Human;
        [SerializeField] private List<Fraction> enemyFractions;
        
        public UnitMovement UnitMovement => unitMovement;

        public enum Fraction
        {
            Human,
            Alien
        }
        
        private void Awake()
        {
            unitMoveBehaviour.Initialize();
            unitAttackBehaviour.Initialize();
            healthComponent.OnPlayerDroppedBelowZeroHp += Destroy;
        }

        private void Destroy()
        {
            
        }

        public void ChangeHealth(float delta)
        {
            healthComponent.UpdateHealth(delta);
        }

        private void Update()
        {
            unitMoveBehaviour.Act(this);
            unitAttackBehaviour.Act(this);
        }
    }
}