using Core.Scripts.Levels;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Scripts.Menu
{
    public class LoadingLevels : ILoadingLevel
    {
        #region Fields

        private SceneConfig _sceneConfig;

        #endregion

        [Inject]
        public void Construct(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void LoadLevel(SceneType sceneType)
        {
            if (sceneType == SceneType.Gameplay)
            {
                SceneManager.LoadSceneAsync(_sceneConfig.Scenes.Find(scene => scene.SceneType == sceneType).NameScene);
            }
        }
    }
}
