using System;
using Core.Scripts.Menu;
using UnityEngine;

namespace Core.Scripts.Levels
{
    public class LevelsController : MonoBehaviour, IChoiceLevel
    {
        #region Feilds

        private int _currentLevel = 1;
        private Action _levelChanged;

        #region Properties

        public int CurrentLevel => _currentLevel;

        #endregion

        #endregion

        public void Initialize(Action levelChanged)
        {
            _levelChanged = levelChanged;
        }

        public void SetLevel(int level)
        {
            _currentLevel = level;
            _levelChanged?.Invoke();
        }
    }
}
