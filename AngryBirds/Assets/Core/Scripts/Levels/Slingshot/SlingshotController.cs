using Core.Scripts.Levels.Birds;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Levels.Slingshot
{
    public class SlingshotController : MonoBehaviour, IAddingBirdSlingshot, ICalculateSlingshotTrajectory
    {
        #region Fields

        [Title("Slingshot Properties")]
        [SerializeField] private float _launchForce = 1000f;
        [SerializeField] private float _maxDragDistance = 3f;
        [SerializeField] private Rigidbody2D _rigidbodySlingshot2D;
        [SerializeField] private LayerMask _targetLayer ;

        private Rigidbody2D _currentBirdRigidbody;
        private BaseBird _currentBird;
        private SpringJoint2D _currentSpringJoint;
        private IStatesTrajectorySlingshot _currentStatesTrajectorySlingshot;
        
        private bool _isDragging = false;
        private Vector2 _currentStartPosition;

        #endregion

        [Inject]
        public void Construct(IStatesTrajectorySlingshot statesTrajectorySlingshot)
        {
            _currentStatesTrajectorySlingshot = statesTrajectorySlingshot;
        }

        void MouseDown()
        {
            _isDragging = true;
            _currentBirdRigidbody.isKinematic = true;
            _currentStatesTrajectorySlingshot.ShowTrajectorySlingshot();
        }

        void MouseUp()
        {
            if (!_isDragging)
            {
                return;
            }

            _isDragging = false;
            _currentBirdRigidbody.isKinematic = false;
            _currentBirdRigidbody.velocity = Vector2.zero;

            Vector2 currentPosition = _currentBirdRigidbody.position;
            Vector2 direction = _currentStartPosition - currentPosition;
            direction.Normalize();

            _currentBirdRigidbody.AddForce(direction * _launchForce);

            _currentSpringJoint.enabled = false;
            _currentStatesTrajectorySlingshot.HideTrajectorySlingshot();
            _currentStatesTrajectorySlingshot.ClearLineTrajectory();
        }

        void Update()
        {
            if (_isDragging)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - _currentStartPosition;

                if (direction.sqrMagnitude > _maxDragDistance * _maxDragDistance)
                {
                    direction = direction.normalized * _maxDragDistance;
                }

                _currentBirdRigidbody.position = _currentStartPosition + direction;
                _currentStatesTrajectorySlingshot.UpdateTrajectorySlingshot();
            }
        
            if (Input.GetMouseButtonDown(0))
            {
                if (!TryGetBird())
                {
                    return;
                }

                MouseDown();
            }
        
            if (Input.GetMouseButtonUp(0))
            {
                if (!_isDragging)
                {
                    return;
                }
            
                MouseUp();
            }
        }
        
        public Vector2 CalculatePositionAtTime(Vector2 velocity, float time)
        {
            return _currentBirdRigidbody.position + velocity * time + 0.5f * Physics2D.gravity * time * time;
        }
        
        public Vector2 CalculateLaunchVelocity()
        {
            Vector2 currentPosition = _currentBirdRigidbody.position;
            Vector2 direction = _currentStartPosition - currentPosition;
            direction.Normalize();
            return direction * _launchForce * Time.fixedDeltaTime / _currentBirdRigidbody.mass;
        }
    
        private BaseBird TryGetBird()
        {
            Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, int.MaxValue, _targetLayer);
            if (hit.collider && hit.collider.TryGetComponent(out BaseBird bird))
            {
                return bird;
            }
        
            return null;
        }
        
        public void ResetBird()
        {
            _currentBirdRigidbody.position = _currentStartPosition;
            _currentBirdRigidbody.velocity = Vector2.zero;
            _currentBirdRigidbody.angularVelocity = 0f;
            _currentBirdRigidbody.isKinematic = true;
            _currentSpringJoint.enabled = true;
            transform.rotation = Quaternion.identity;
            _currentStatesTrajectorySlingshot.HideTrajectorySlingshot();
            _currentStatesTrajectorySlingshot.ClearLineTrajectory();
        }

        public void AddBirdSlingshot(BaseBird bird)
        {
            _currentBirdRigidbody = bird.GetComponent<Rigidbody2D>();
            _currentSpringJoint = bird.GetComponent<SpringJoint2D>();
            _currentSpringJoint.connectedBody = _rigidbodySlingshot2D;
            _currentBird = bird;
        }
        
        public void SetStartPosition(Vector3 startPosition)
        {
            _currentStartPosition = startPosition;
        }
    }
}
