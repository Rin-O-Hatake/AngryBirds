using System;
using System.Collections.Generic;
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
        
        private List<Action> _onBirds;
        
        #endregion

        #region MonoBehavior

        private void OnDestroy()
        {
            _chooserBirdButton.onClick.RemoveListener(ChooseBirdButton);
        }

        #endregion
        
        public void Initialize(Sprite birdSprite, int birdText, List<Action> clickAction)
        {
            _birdImage.sprite = birdSprite;
            _birdText.text = $"{birdText}X";
            
            _onBirds = clickAction;
            
            _chooserBirdButton.onClick.AddListener(ChooseBirdButton);
        }

        private void ChooseBirdButton()
        {
            foreach (var onBird in _onBirds)
            {
                onBird?.Invoke();
            }
        }
    }
}
