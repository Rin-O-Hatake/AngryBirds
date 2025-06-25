using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.UI
{
    public class BirdView : MonoBehaviour
    {
        #region Fields

        [Title("UI Properties")]
        [SerializeField] private Image _birdImage;
        [SerializeField] private TMP_Text _birdText;
        [SerializeField] private Button _chooserBirdButton;
        
        private Action _onBird;
        
        #endregion

        #region MonoBehavior

        private void OnDestroy()
        {
            _chooserBirdButton.onClick.RemoveListener(ChooseBirdButton);
        }

        #endregion
        
        public void Initialize(Sprite birdSprite, int birdText, Action clickAction)
        {
            _birdImage.sprite = birdSprite;
            _birdText.text = $"{birdText}X";
            
            _onBird = clickAction;
            
            _chooserBirdButton.onClick.AddListener(ChooseBirdButton);
        }

        private void ChooseBirdButton()
        {
            _onBird?.Invoke();
        }
    }
}
