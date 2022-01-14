using UnitBehaviours;
using UnityEngine;
using Untility;

namespace DefaultNamespace
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitMoveBehaviour _unitMoveBehaviour;
        [SerializeField] private UnitAttackBehaviour _unitAttackBehaviour;
        [SerializeField] private HealthComponent _healthComponent;

    }
}