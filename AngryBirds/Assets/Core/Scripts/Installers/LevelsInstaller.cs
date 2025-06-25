using Core.Scripts.Birds;
using Core.Scripts.Levels;
using Core.Scripts.Menu;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Installers
{
    public class LevelsInstaller : MonoInstaller, IChoiceLevel
    {
        #region Fields

        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private SceneConfig _mainSceneConfig;

        private int _currentLevel;

        #endregion

        public override void InstallBindings()
        {
            InjectLevelStatistics();
            InjectChoiceLevel();
            InjectSceneConfig();
        }

        private void InjectLevelStatistics()
        {
            LevelInfoData levelInfoData = new LevelInfoData
            {
                LevelData = _levelsConfig.Levels.Find(level => level.LevelNumber == _currentLevel),
                StartCountBirdConfig = _levelsConfig.StartCountBirdConfig
            };
            
            Container.Bind<LevelInfoData>().FromInstance(levelInfoData).AsCached();
        }

        private void InjectChoiceLevel()
        {
            Debug.Log("1");
            Container.Bind<IChoiceLevel>().To<LevelsInstaller>().FromInstance(this).AsSingle();
        }
        
        private void InjectSceneConfig()
        {
            Container.Bind<SceneConfig>().FromInstance(_mainSceneConfig).AsSingle();
        }

        public void SetLevel(int level)
        {
            _currentLevel = level;
        }
    }
}
