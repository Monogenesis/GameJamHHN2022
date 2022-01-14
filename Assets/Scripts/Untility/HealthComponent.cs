using System;
using UnityEngine;

namespace Untility
{
    [System.Serializable]
    public class HealthComponent
    {
        [SerializeField] private float health = 0.0f;
        [SerializeField] private float maxHealth = 0.0f;
        [SerializeField] private bool isDead = false;

        public event Action OnPlayerDroppedBelowZeroHp;

        public HealthComponent()
        {
            maxHealth = health = 100.0f;
        }


        public HealthComponent(float maxHealth)
        {
            this.maxHealth = this.health = maxHealth;
        }


        public void UpdateMaxHealth(int delta)
        {
            maxHealth += delta;
            if (maxHealth < health)
            {
                health = maxHealth;
            }
        }

        public void UpdateHealth(float delta)
        {
            if (!isDead)
            {
                health += delta;
                if (health <= 0.0f)
                {
                    isDead = true;
                    health = 0.0f;
                    OnPlayerDroppedBelowZeroHp?.Invoke();
                }
                else if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
        }


        public float Health
        {
            get => health;
            set => health = value;
        }


        public float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }


        public bool IsDead
        {
            get => isDead;
            set => isDead = value;
        }
    }
}