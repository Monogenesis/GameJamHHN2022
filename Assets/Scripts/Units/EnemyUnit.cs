using System;
using System.Collections.Generic;

namespace Units
{
    
    public class EnemyUnit : Unit
    {
        public static readonly List<EnemyUnit> AliveEnemies = new();
        
        private void Awake()
        {
            AliveEnemies.Add(this);
        }

        private void OnDestroy()
        {
            AliveEnemies.Remove(this);
        }
    }
}