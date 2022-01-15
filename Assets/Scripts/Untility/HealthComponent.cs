using System;
using UnityEngine;

namespace Untility
{
    [System.Serializable]
    public class HealthComponent
    {
        [SerializeField] private float currentCurrentHealth = 0.0f;
        [SerializeField] private float maxHealth = 0.0f;
        [SerializeField] private bool isDead = false;

        public event Action OnPlayerDroppedBelowZeroHp;

        public HealthComponent()
        {
            maxHealth = currentCurrentHealth = 100.0f;
        }


        public HealthComponent(float maxCurrentCurrentHealth)
        {
            this.maxHealth = this.currentCurrentHealth = maxCurrentCurrentHealth;
        }


        public void UpdateMaxHealth(int delta)
        {
            maxHealth += delta;
            if (maxHealth < currentCurrentHealth)
            {
                currentCurrentHealth = maxHealth;
            }
        }

        public void UpdateHealth(float delta)
        {
            if (!isDead)
            {
                currentCurrentHealth += delta;
                if (currentCurrentHealth <= 0.0f)
                {
                    isDead = true;
                    currentCurrentHealth = 0.0f;
                    OnPlayerDroppedBelowZeroHp?.Invoke();
                }
                else if (currentCurrentHealth > maxHealth)
                {
                    currentCurrentHealth = maxHealth;
                }
            }
        }


        public float CurrentHealth
        {
            get => currentCurrentHealth;
            set => currentCurrentHealth = value;
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