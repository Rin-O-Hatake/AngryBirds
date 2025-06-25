using Core.Scripts.Birds;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Slingshot
{
    public class SlingshotController : MonoBehaviour, IAddingBirdSlingshot
    {
        #region Fields
        
        [Title("Slingshot Properties")]
        [SerializeField] private float _launchPower = 500f;
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private SlingshotTrajectory _slingshotTrajectory;
        
        private Rigidbody2D _currentBirdRigidbody;
        
        private Vector2 _currentStartPosition;
        private bool _currentIsDragging;
        private Camera _camera;

        #endregion

        #region MonoBehavior

        void Start()
        {
            _camera = Camera.main;
            _currentStartPosition = transform.position;
        }
            
        void Update()
        {
            if (_currentIsDragging)
            {
                Vector2 currentMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _slingshotTrajectory.DrawTrajectory(currentMousePosition, _currentStartPosition, _launchPower);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (!TryGetBird())
                {
                    return;
                }
                
                _currentIsDragging = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!TryGetBird())
                {
                    return;
                }
                
                _currentIsDragging = false;
                Vector2 endPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = _currentStartPosition - endPosition;
                    
                _currentBirdRigidbody.isKinematic = false;
                _currentBirdRigidbody.AddForce(direction * _launchPower);
                Destroy(this);
            }
        }

        #endregion

        private BaseBird TryGetBird()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _targetLayer))
            {
                if (hit.collider.TryGetComponent(out BaseBird bird))
                {
                    return bird;
                }
            }
            
            return null;
        }

        public void AddBirdSlingshot(BaseBird bird)
        {
            _currentBirdRigidbody = bird._birdRigidbody;
        }
    }
}
