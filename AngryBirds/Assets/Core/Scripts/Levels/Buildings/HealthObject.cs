using System;

namespace Core.Scripts.Levels.Buildings
{
    public class HealthObject : ITakingDamage
    {
        #region Fields

        private float _currentHealth;

        private float currentHealth;
        
        public Action OnDeath { get; set; }
        
        #endregion

        public HealthObject(float health)
        {
            _currentHealth = health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        
            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}
