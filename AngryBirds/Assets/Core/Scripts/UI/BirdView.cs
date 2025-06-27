using System;
using Core.Scripts.Levels.Birds;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.UI
{
    public class BirdView : MonoBehaviour, ISetterRemainderBirds
    {
        #region Fields

        [Title("UI Properties")]
        [SerializeField] private Image _birdImage;
        [SerializeField] private TMP_Text _birdText;
        [SerializeField] private Button _chooserBirdButton;
        
        private Action _onBirds;

        public BirdsType BirdsType { get; private set; }
        
        #endregion

        #region MonoBehavior

        private void OnDestroy()
        {
            _chooserBirdButton.onClick.RemoveListener(ChooseBirdButton);
        }

        #endregion
        
        public void Initialize(Sprite birdSprite, int birdText, BirdsType birdsType, Action clickAction)
        {
            BirdsType = birdsType;
            _birdImage.sprite = birdSprite;
            _birdText.text = $"{birdText}X";
            
            _onBirds = clickAction;
            
            _chooserBirdButton.onClick.AddListener(ChooseBirdButton);
        }

        private void ChooseBirdButton()
        {
            _onBirds?.Invoke();
        }
        
        public void SetRemainderBirds(int birds)
        {
            if (birds == 0)
            {
                Destroy(gameObject);
            }
            
            _birdText.text = $"{birds}X";
        }
    }
}
