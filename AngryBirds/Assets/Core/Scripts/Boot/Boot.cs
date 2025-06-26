using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scripts.Boot
{
    public class Boot : MonoBehaviour
    {
        #region Fields

        [SerializeField] private string _sceneName;

        #endregion
        public void Start()
        {
            LoadStartScene();
        }

        private void LoadStartScene()
        {
            SceneManager.LoadSceneAsync(_sceneName);
        }
    }
}
