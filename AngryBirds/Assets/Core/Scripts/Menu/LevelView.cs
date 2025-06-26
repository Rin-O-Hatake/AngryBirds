using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Scripts.Menu
{
    public class LevelView : MonoBehaviour
    {
         #region Fields

        [SerializeField] private List<Button> _levelButtons;
        
        private ILoadingLevel _loadingLevel;
        private IChoiceLevel _choiceLevel;

        #endregion

        [Inject]
        public void Construct(ILoadingLevel loadingLevel)
        {
            _loadingLevel = loadingLevel;
        }

        [Inject]
        public void Construct(IChoiceLevel choiceLevel)
        {
            _choiceLevel = choiceLevel;
        }

        #region MonoBehavior

        private void Awake()
        {
            for (int index = 0; index < _levelButtons.Count; index++)
            {
                int index1 = index;
                _levelButtons[index].onClick.AddListener(() => LevelButton(index1 + 1));
            }
        }

        private void OnDestroy()
        {
            for (int index = 0; index < _levelButtons.Count; index++)
            {
                int index1 = index;
                _levelButtons[index].onClick.RemoveListener(() => LevelButton(index1  + 1));
            }
        }

        #endregion

        private void LevelButton(int level)
        {
            _choiceLevel.SetLevel(level);
            
            _loadingLevel.LoadLevel(SceneType.Gameplay);
        }
    }
}
