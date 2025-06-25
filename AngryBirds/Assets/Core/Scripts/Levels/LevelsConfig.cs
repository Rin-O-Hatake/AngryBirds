using System;
using System.Collections.Generic;
using Core.Scripts.Birds;
using UnityEngine;

namespace Core.Scripts.Levels
{
    [CreateAssetMenu(order = 51, fileName = "Levels Config", menuName = "AngryBirds/Level/CounterBirds")]
    public class LevelsConfig : ScriptableObject
    {
        #region Fields

        [SerializeField] private StartCountBirdConfig _startCountBirdConfig;
        [SerializeField] private List<LevelData> _levels;
        
        #region Properties

        public List<LevelData> Levels => _levels;

        #endregion

        #endregion
    }

    [Serializable]
    public class LevelData
    {
        #region Fields

        [SerializeField] private int _levelNumber;
        [SerializeField] private List<LevelCountBirdsData> _levelCountBirdsData;

        #region Properties

        public int LevelNumber => _levelNumber;
        public  List<LevelCountBirdsData> LevelCountBirdsData => _levelCountBirdsData;

        #endregion

        #endregion
    }
}


