using System;
using Core.Scripts.Levels.Birds;
using UnityEngine;

namespace Core.Scripts.Levels.Slingshot
{
    public interface IAddingBirdSlingshot
    {
        public void AddBirdSlingshot(BaseBird bird);
        public void SetStartPosition(Vector3 startPosition);
    }
    
    public interface IChoiceBird
    {
        public ISetterRemainderBirds SetterRemainderBirds { get; set; }
        public void ChooseBird(BirdsType bird);
    }

    public interface ICreatingBirdSlingshot
    {
        public BaseBird CreateBirdSlingshot(BaseBird birdPrefab);
        public Vector3 GetStartPosition();
    }

    public interface ICalculateSlingshotTrajectory
    {
        public Vector2 CalculatePositionAtTime(Vector2 velocity, float time);
        public Vector2 CalculateLaunchVelocity();
    }

    public interface IStatesTrajectorySlingshot
    {
        public void UpdateTrajectorySlingshot();
        public void HideTrajectorySlingshot();
        public void ShowTrajectorySlingshot();
        public void ClearLineTrajectory();
    }
}
