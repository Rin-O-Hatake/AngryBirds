using Core.Scripts.Levels.Birds;
using Core.Scripts.Levels.Slingshot;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Installers
{
    public class BirdsSlingshotInstaller : MonoInstaller
    {
        #region Fields

        [SerializeField] private SlingshotController _addingBirdSlingshot;
        [SerializeField] private BirdsController _birdsController;
        [SerializeField] private CreatorBirds _creatorBirds;
        [SerializeField] private SlingshotTrajectory _slingshotTrajectory;

        #endregion

        public override void InstallBindings()
        {
            InjectAddingBirdSlingshot();
            InjectChoiceBird();
            InjectStatesTrajectorySlingshot();
            InjectCalculateSlingshotTrajectory();
            InjectCreatorBird();
        }

        private void InjectAddingBirdSlingshot()
        {
            Container.Bind<IAddingBirdSlingshot>().To<SlingshotController>().FromInstance(_addingBirdSlingshot).AsTransient();
        }
        private void InjectStatesTrajectorySlingshot()
        {
            Container.Bind<IStatesTrajectorySlingshot>().To<SlingshotTrajectory>().FromInstance(_slingshotTrajectory).AsSingle();
        }
        private void InjectCalculateSlingshotTrajectory()
        {
            Container.Bind<ICalculateSlingshotTrajectory>().To<SlingshotController>().FromInstance(_addingBirdSlingshot).AsTransient();
        }
        
        private void InjectChoiceBird()
        {
            Container.Bind<IChoiceBird>().To<BirdsController>().FromInstance(_birdsController).AsSingle();
        }
        
        private void InjectCreatorBird()
        {
            Container.Bind<ICreatingBirdSlingshot>().To<CreatorBirds>().FromInstance(_creatorBirds).AsSingle();
        }
    }
}
