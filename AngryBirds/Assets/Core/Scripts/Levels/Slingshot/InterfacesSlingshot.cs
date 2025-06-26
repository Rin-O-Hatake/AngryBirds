
using Core.Scripts.Birds;
using Core.Scripts.Levels.Birds;

namespace Core.Scripts.Levels.Slingshot
{
    public interface IAddingBirdSlingshot
    {
        public void AddBirdSlingshot(BaseBird bird);
    }

    public interface ICreatingBirdSlingshot
    {
        public BaseBird CreateBirdSlingshot(BaseBird birdPrefab);
    }
}
