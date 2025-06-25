using UnityEngine;
using Zenject;

namespace Core.Scripts.Slingshot
{
    public class BirdChooser : MonoBehaviour
    {

        private IAddingBirdSlingshot _addingBirdSlingshotInterface;

        [Inject]
        public void Construct(IAddingBirdSlingshot addingBirdSlingshot)
        {
            _addingBirdSlingshotInterface = addingBirdSlingshot;
        }
        
    }
}
