using Units;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class UnitBehaviour : ScriptableObject
    {
        public virtual void Initialize(){} 
        public abstract void Act(Unit unit);
    }
}