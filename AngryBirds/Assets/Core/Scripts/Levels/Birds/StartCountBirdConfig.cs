using System;
using System.Collections.Generic;
using Core.Scripts.Levels.Birds;
using UnityEngine;

namespace Core.Scripts.Birds
{
    [CreateAssetMenu(order = 51, fileName = "Start Count Bird Config", menuName = "AngryBirds/Birds/Start Count Bird Config")]
    public class StartCountBirdConfig : ScriptableObject
    {
        #region Fields

        [SerializeField] private List<BirdData> _birdData = new List<BirdData>();

        #region Propertes

        public List<BirdData> BirdData => _birdData;

        #endregion

        #endregion
    }

    [Serializable]
    public class BirdData
    {
        #region Fields

        [SerializeField] private BirdsType _birdType;
        [SerializeField] private Sprite _birdIcon;
        [SerializeField] private BaseBird _birdPrefab;

        #region Properties

        public BirdsType BirdType =>_birdType;
        public Sprite BirdIcon => _birdIcon;
        public BaseBird BirdPrefab => _birdPrefab;

        #endregion

        #endregion
    }
}
