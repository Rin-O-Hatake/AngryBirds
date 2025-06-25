using System;
using System.Collections.Generic;
using Core.Scripts.Menu;
using UnityEngine;

namespace Core.Scripts.Levels
{
    [CreateAssetMenu(order = 51, fileName = "Levels Config", menuName = "AngryBirds/Level/CounterBirds")]
    public class SceneConfig : ScriptableObject
    {
        #region Fields

        private List<SceneInfo> _scenes = new List<SceneInfo>();
            
        #region Properties

        public List<SceneInfo> Scenes => _scenes;

        #endregion

        #endregion
    }

    [Serializable]
    public class SceneInfo
    {
        #region Fields
        
        private SceneType _sceneType;
        private string _nameScene;

        #region Properties

        public SceneType SceneType => _sceneType;
        public string NameScene => _nameScene;

        #endregion

        #endregion
    }
}
