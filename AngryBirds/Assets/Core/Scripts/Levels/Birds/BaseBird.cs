using System;
using UnityEngine;

namespace Core.Scripts.Levels.Birds
{
    public abstract class BaseBird : MonoBehaviour
    {
        #region Fields

        private BirdsType _currentBirdsType;

        public Action<BaseBird> OnDestroy;
        public Action<BaseBird> OnStartFlying;

        #region Properties

        public BirdsType CurrentBirdsType => _currentBirdsType;

        #endregion

        #endregion

        public void StartFlying()
        {
            OnStartFlying?.Invoke(this);
            Invoke(nameof(DestroyObject), 5);
        }

        private void DestroyObject()
        {
            OnDestroy?.Invoke(this);
            Destroy(gameObject);
        }
        
    }
}
