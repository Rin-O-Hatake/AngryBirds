using System.Collections.Generic;
using System.Linq;
using Core.Scripts.Birds;
using Core.Scripts.Levels.Slingshot;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Levels.Birds
{
    public class BirdsController : MonoBehaviour, IAddingBirdSlingshot
    {
        #region Fields

        private LevelBirdsData _levelBirdsData;
        private List<BaseBird> _currentBirds = new List<BaseBird>();

        #endregion

        [Inject]
        public void Construct(LevelInfoData levelInfoData, ICreatingBirdSlingshot creatingBirdSlingshot)
        {
            _levelBirdsData = new LevelBirdsData(levelInfoData.LevelData.LevelCountBirdsData,
                levelInfoData.StartCountBirdConfig);

            foreach (var bird in _levelBirdsData.LevelCountBirds)
            {
                for (int index = 0; index < bird.CountBirds; index++)
                {
                    _currentBirds.Add(creatingBirdSlingshot.CreateBirdSlingshot(_levelBirdsData.StartCountBirdConfig.BirdData
                        .Find(birdData => birdData.BirdType == bird.BirdsType).BirdPrefab));
                }
            }
        }

        public void AddBirdSlingshot(BaseBird baseBird)
        {
            var bird = _currentBirds.FirstOrDefault(bird => bird.CurrentBirdsType == baseBird.CurrentBirdsType);
            if (!bird)
            {
                Debug.LogError("Bird is not find");
                return;
            }
            
            bird.gameObject.SetActive(true);
        }
    }
}
