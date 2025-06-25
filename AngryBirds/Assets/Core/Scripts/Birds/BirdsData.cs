using System;
using Core.Scripts.Levels;

namespace Core.Scripts.Birds
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
}
