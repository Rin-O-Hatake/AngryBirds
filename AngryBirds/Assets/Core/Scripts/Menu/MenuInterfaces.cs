using UnityEngine;

namespace Core.Scripts.Menu
{
    public interface ILoadingLevel
    {
        public void LoadLevel(SceneType scene);
    }

    public interface IChoiceLevel
    {
        public void SetLevel(int level);
    }
}
