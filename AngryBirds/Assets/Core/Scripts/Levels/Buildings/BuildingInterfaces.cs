using System;
using UnityEngine;

namespace Core.Scripts.Levels.Buildings
{
    public interface IFallingBuilding
    {
        public float CheckFallDamage(Rigidbody2D rigidbody);
    }
    
    public interface ITakingDamage
    {
        public Action OnDeath { get; set; }
        public void TakeDamage(float damage);
    }
}
