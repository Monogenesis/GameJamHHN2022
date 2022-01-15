using System.Collections.Generic;
using UnitBehaviours.Attack;
using UnitBehaviours.Move;
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
        [SerializeField] private Race ownRace = Race.Human;
        [SerializeField] private List<Race> enemyRace;
        
        public UnitMovement UnitMovement => unitMovement;

        public Race OwnRace => ownRace;
        public List<Race> EnemyRace => enemyRace;

        public enum Race
        {
            Human,
            Alien,
            Natives,
            Neutral
        }
        
        private void Awake()
        {
            unitMoveBehaviour.Initialize();
            unitAttackBehaviour.Initialize();
            healthComponent.OnPlayerDroppedBelowZeroHp += Destroy;
        }

        private void Destroy()
        {
            Destroy(gameObject);
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