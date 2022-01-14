using System;
using Editor;
using UnityEngine;

namespace Untility
{
    [System.Serializable]
    public class HealthComponent
    {
        [SerializeField] private float health = 0.0f;
        [SerializeField] private float maxHealth = 0.0f;
        [SerializeField, ReadOnly] private bool isDead = false;

        public event Action OnPlayerDroppedBelowZeroHP;

        public HealthComponent()
        {
            maxHealth = health = 100.0f;
        }


        public HealthComponent(float maxHealth)
        {
            this.maxHealth = this.health = maxHealth;
        }


        public void UpdateMaxHealth(int value)
        {
            maxHealth += value;
            if (maxHealth < health)
            {
                health = maxHealth;
            }
        }


        public void UpdateHealth(float value)
        {
            if (!isDead)
            {
                health += value;
                if (health <= 0.0f)
                {
                    isDead = true;
                    health = 0.0f;
                    OnPlayerDroppedBelowZeroHP?.Invoke();
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