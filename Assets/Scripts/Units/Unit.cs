using System.Collections.Generic;
using UnitBehaviours.Attack;
using UnitBehaviours.Move;
using UnityEngine;
using UnityEngine.UIElements;
using Untility;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitMovement unitMovement;
        [SerializeField] private UnitHealth unitHealth;
        [SerializeField] private UnitMoveBehaviour unitMoveBehaviour;
        [SerializeField] private UnitAttackBehaviour unitAttackBehaviour;
        [SerializeField] private Faction ownFaction = Faction.Human;
        [SerializeField] private List<Faction> enemyRace;
        [SerializeField] private HealthComponent healthComponent;

        public UnitMovement UnitMovement => unitMovement;

        public Faction OwnFaction => ownFaction;
        public List<Faction> EnemyRace => enemyRace;

        public enum Faction
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

            unitHealth.HealthBar.style.width = (healthComponent.CurrentHealth / healthComponent.MaxHealth) * UnitHealth.MaxWidth;
        }

        private void Update()
        {
            unitMoveBehaviour.Act(this);
            unitAttackBehaviour.Act(this);
        }
    }
}