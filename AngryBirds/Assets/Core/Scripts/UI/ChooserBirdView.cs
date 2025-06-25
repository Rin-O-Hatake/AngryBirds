using System;
using Core.Scripts.Birds;
using Core.Scripts.Levels;
using Core.Scripts.Slingshot;
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
        public void Construct(LevelInfoData levelInfo, IAddingBirdSlingshot addingBirdSlingshot)
        {
            foreach (var countsBird in levelInfo.LevelData.LevelCountBirdsData)
            {
                var birdData = 
                    levelInfo.StartCountBirdConfig.BirdData.Find(bird => bird.BirdType == countsBird.BirdsType);
                
                CreateBirdUI(birdData ,countsBird.CountBirds, addingBirdSlingshot.AddBirdSlingshot);
            }
        }

        private void CreateBirdUI(BirdData birdData, int countBird, Action<BaseBird> onCreateBirdUI)
        {
            BirdView birdView = Instantiate(_birdViewPrefab, _contentBird);
            birdView.Initialize(birdData.BirdIcon, countBird, () => onCreateBirdUI?.Invoke(birdData.BirdPrefab));
        }
    }
}
