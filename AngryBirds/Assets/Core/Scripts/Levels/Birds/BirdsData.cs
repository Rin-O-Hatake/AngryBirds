using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scripts.Levels.Birds
{
    public enum BirdsType
    {
        RED_BIRD
    }

    [Serializable]
    public class LevelCountBirdsData
    {
        #region Fields
        
        public BirdsType BirdsType;
        public int CountBirds;
        
        #endregion
    }

    public class LevelInfoData
    {
        #region Fields

        public LevelData LevelData;
        public StartCountBirdConfig StartCountBirdConfig;

        #endregion
    }

    public struct LevelBirdsData
    {
        public List<LevelCountBirdsData> LevelCountBirds;
        public StartCountBirdConfig StartCountBirdConfig;

        public LevelBirdsData(List<LevelCountBirdsData> levelCountBirds, StartCountBirdConfig startCountBirdConfig)
        {
            LevelCountBirds = levelCountBirds;
            StartCountBirdConfig = startCountBirdConfig;
        }
    }
}
