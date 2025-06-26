using UnityEngine;

namespace Core.Scripts.Levels.Birds
{
    public abstract class BaseBird : MonoBehaviour
    {
        #region Fields

        private BirdsType _currentBirdsType;
        
        public Rigidbody2D _birdRigidbody;

        #region Properties

        public BirdsType CurrentBirdsType => _currentBirdsType;

        #endregion

        #endregion
        
    }
}
