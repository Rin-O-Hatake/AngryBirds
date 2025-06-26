using System;
using System.Collections.Generic;
using Core.Scripts.Menu;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Levels
{
    [CreateAssetMenu(order = 51, fileName = "Levels Config", menuName = "AngryBirds/Scene")]
    public class SceneConfig : ScriptableObject
    {
        #region Fields

        [SerializeField] private List<SceneInfo> _scenes = new List<SceneInfo>();
            
        #region Properties

        public List<SceneInfo> Scenes => _scenes;

        #endregion

        #endregion
    }

    [Serializable]
    public class SceneInfo
    {
        #region Fields
        
        [SerializeField] private SceneType _sceneType;
        [SerializeField] private string _nameScene;

        #region Properties

        public SceneType SceneType => _sceneType;
        public string NameScene => _nameScene;

        #endregion

        #endregion
    }
}
