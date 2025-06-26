using System;
using Core.Scripts.Birds;
using Core.Scripts.Levels;
using Core.Scripts.Levels.Birds;
using Core.Scripts.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Scripts.Installers
{
    public class LevelStatisticsInstaller : MonoInstaller
    {
        #region Fields
        
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private SceneConfig _mainSceneConfig;
        [SerializeField] private LevelsController _levelsController;
        

        private int _currentLevel;

        #endregion

        public override void InstallBindings()
        {
            InjectLevelStatistics();
            InjectChoiceLevel();
            CreateInjectLoadingLevel();
            InjectSceneConfig();
        }

        private void InjectLevelStatistics()
        {
            Container.Unbind<LevelInfoData>();
            
            LevelInfoData levelInfoData = new LevelInfoData
            {
                LevelData = _levelsConfig.Levels.Find(level => level.LevelNumber == _levelsController.CurrentLevel),
                StartCountBirdConfig = _levelsConfig.StartCountBirdConfig
            };

            Container.Bind<LevelInfoData>().FromInstance(levelInfoData).AsTransient();
        }

        private void InjectChoiceLevel()
        {
            Container.Bind<IChoiceLevel>().To<LevelsController>().FromInstance(_levelsController).AsSingle();
        }

        private void CreateInjectLoadingLevel()
        {
            Container.Bind<ILoadingLevel>().To<LoadingLevels>().FromNew().AsCached().NonLazy();
        }
        
        private void InjectSceneConfig()
        {
            Container.Bind<SceneConfig>().FromInstance(_mainSceneConfig).AsSingle();
        }
        
        #region Monobehaviors

        private void OnEnable()
        {
            SceneManager.sceneLoaded += ReloadNextScene;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= ReloadNextScene;
        }

        private void ReloadNextScene(Scene arg0, LoadSceneMode arg1)
        {
            InjectLevelStatistics();
        }

        #endregion
    }
}
