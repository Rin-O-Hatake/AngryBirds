using System;
using System.Collections.Generic;
using Core.Scripts.Birds;
using Core.Scripts.Levels;
using Core.Scripts.Levels.Birds;
using Core.Scripts.Levels.Slingshot;
using UnityEngine;
using Zenject;

namespace Core.Scripts.UI
{
    public class ChooserBirdView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _contentBird;
        [SerializeField] private BirdView _birdViewPrefab;

        #endregion

        [Inject]
        public void Construct(LevelInfoData levelInfo, List<IAddingBirdSlingshot> addingBirdSlingshot)
        {
            Debug.Log("++");
            foreach (var countsBird in levelInfo.LevelData.LevelCountBirdsData)
            {
                var birdData = 
                    levelInfo.StartCountBirdConfig.BirdData.Find(bird => bird.BirdType == countsBird.BirdsType);
                
                CreateBirdUI(birdData ,countsBird.CountBirds, addingBirdSlingshot);
            }
        }

        private void CreateBirdUI(BirdData birdData, int countBird, List<IAddingBirdSlingshot> onCreateBirdUI)
        {
            BirdView birdView = Instantiate(_birdViewPrefab, _contentBird);
            // birdView.Initialize(birdData.BirdIcon, countBird, () => onCreateBirdUI?.Invoke(birdData.BirdPrefab));
        }
    }
}
