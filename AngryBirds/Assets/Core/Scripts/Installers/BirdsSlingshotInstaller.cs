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

        #endregion

        public override void InstallBindings()
        {
            InjectAddingBirdSlingshot();
            InjectCreatorBird();
        }

        private void InjectAddingBirdSlingshot()
        {
            Container.Bind<IAddingBirdSlingshot>().To<SlingshotController>().FromInstance(_addingBirdSlingshot).AsSingle();
            Container.Bind<IAddingBirdSlingshot>().To<BirdsController>().FromInstance(_birdsController).AsSingle();
        }
        
        private void InjectCreatorBird()
        {
            Container.Bind<ICreatingBirdSlingshot>().To<CreatorBirds>().FromInstance(_creatorBirds).AsSingle();
        }
    }
}
