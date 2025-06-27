using Core.Scripts.Levels.Slingshot;
using UnityEngine;

namespace Core.Scripts.Levels.Birds
{
    public class CreatorBirds : MonoBehaviour, ICreatingBirdSlingshot
    {
        #region Fields

        [SerializeField] private Transform _birdSpawnPoint;

        #endregion
        
        public BaseBird CreateBirdSlingshot(BaseBird Bird)
        {
            BaseBird birdObject = Instantiate(Bird, _birdSpawnPoint.position, Quaternion.identity);
            birdObject.gameObject.SetActive(false);
            return birdObject;
        }

        public Vector3 GetStartPosition()
        {
            return _birdSpawnPoint.position;
        }
    }
}
