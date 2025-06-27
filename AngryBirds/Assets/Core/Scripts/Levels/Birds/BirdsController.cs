using System;
using System.Collections.Generic;
using Core.Scripts.Levels.Slingshot;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Levels.Birds
{
    public class BirdsController : MonoBehaviour, IChoiceBird
    {
        #region Fields

        private LevelBirdsData _levelBirdsData;
        private List<BaseBird> _currentBirds = new List<BaseBird>();
        private IAddingBirdSlingshot _addingBirdSlingshot;
        
        public ISetterRemainderBirds SetterRemainderBirds { get; set; }

        #endregion

        [Inject]
        public void Construct(LevelInfoData levelInfoData, ICreatingBirdSlingshot creatingBirdSlingshot,
            IAddingBirdSlingshot addingBirdSlingshot)
        {
            _levelBirdsData = new LevelBirdsData(levelInfoData.LevelData.LevelCountBirdsData,
                levelInfoData.StartCountBirdConfig);
            _addingBirdSlingshot = addingBirdSlingshot;
            
            foreach (var bird in _levelBirdsData.LevelCountBirds)
            {
                for (int index = 0; index < bird.CountBirds; index++)
                {
                    BaseBird baseBird = creatingBirdSlingshot.CreateBirdSlingshot(_levelBirdsData.StartCountBirdConfig
                        .BirdData.Find(birdData => birdData.BirdType == bird.BirdsType).BirdPrefab);
                    baseBird.OnStartFlying += ClearBird;
                    _currentBirds.Add(baseBird);
                }
            }
            
            _addingBirdSlingshot.SetStartPosition(creatingBirdSlingshot.GetStartPosition());
        }

        private void ClearBird(BaseBird baseBird)
        {
            baseBird.OnStartFlying -= ClearBird;
            _currentBirds.Remove(baseBird);
            
            var birds = _currentBirds.FindAll(birdData => birdData.CurrentBirdsType == baseBird.CurrentBirdsType);
            SetterRemainderBirds.SetRemainderBirds(birds.Count);
        }

        public void ChooseBird(BirdsType birdType)
        {
            var bird = _currentBirds.Find(birdData => birdData.CurrentBirdsType == birdType);
            
            if (!bird)
            {
                Debug.LogError("Bird is not find");
                return;
            }
                
            bird.gameObject.SetActive(true);
            _addingBirdSlingshot.AddBirdSlingshot(bird);
        }
    }
}
