using UnityEngine;

namespace Core.Scripts.Levels.Birds
{
    public interface ISetterRemainderBirds
    {
        public BirdsType BirdsType { get; }
        public void SetRemainderBirds(int birds);
    }
}
