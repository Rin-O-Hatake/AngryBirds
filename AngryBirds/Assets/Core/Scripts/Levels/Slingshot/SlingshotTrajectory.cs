using System;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Core.Scripts.Levels.Slingshot
{
    [Serializable]
    public class SlingshotTrajectory : MonoBehaviour, IStatesTrajectorySlingshot
    {
        #region Fields

        [SerializeField] private GameObject trajectoryPointPrefab;
        [SerializeField] private int numberOfTrajectoryPoints = 20;
        [SerializeField] private float timeBetweenPoints = 0.1f;
        [SerializeField] private LineRenderer _lineRenderer;
        
        private GameObject[] trajectoryPoints;
        private ICalculateSlingshotTrajectory _calculateTrajectory;
        private Action _onUpdate;
        private Action _onHide;
        private Action _onShow;
        
        #endregion


        [Inject]
        public void Construct(ICalculateSlingshotTrajectory calculateTrajectory)
        {
            _calculateTrajectory = calculateTrajectory;
        }

        private void Start()
        {
            trajectoryPoints = new GameObject[numberOfTrajectoryPoints];
            for (int i = 0; i < numberOfTrajectoryPoints; i++)
            {
                trajectoryPoints[i] = Instantiate(trajectoryPointPrefab, transform.position, Quaternion.identity);
                trajectoryPoints[i].SetActive(false);
            }

            if (_lineRenderer == null)
            {
                _lineRenderer.positionCount = 0;
                _lineRenderer.startWidth = 0.1f;
                _lineRenderer.endWidth = 0.1f;
                _lineRenderer.useWorldSpace = true;
                _lineRenderer.startColor = Color.white;
                _lineRenderer.endColor = Color.white;
            }
        }


        private void UpdateTrajectory()
        {
            Vector2 velocity = _calculateTrajectory.CalculateLaunchVelocity();

            for (int i = 0; i < numberOfTrajectoryPoints; i++)
            {
                float time = i * timeBetweenPoints;
                Vector2 position = _calculateTrajectory.CalculatePositionAtTime(velocity, time);
                trajectoryPoints[i].transform.position = position;
            }
        }
    

        private void UpdateLineRenderer()
        {
            Vector2 velocity = _calculateTrajectory.CalculateLaunchVelocity();
            _lineRenderer.positionCount = numberOfTrajectoryPoints;

            for (int i = 0; i < numberOfTrajectoryPoints; i++)
            {
                float time = i * timeBetweenPoints;
                Vector2 position = _calculateTrajectory.CalculatePositionAtTime(velocity, time);
                _lineRenderer.SetPosition(i, position);
            }
        }

        public void UpdateTrajectorySlingshot()
        {
            UpdateTrajectory();
            UpdateLineRenderer();
        }

        public void HideTrajectorySlingshot()
        {
            for (int i = 0; i < numberOfTrajectoryPoints; i++)
            {
                trajectoryPoints[i].SetActive(false);
            }
        }

        public void ShowTrajectorySlingshot()
        {
            for (int i = 0; i < numberOfTrajectoryPoints; i++)
            {
                trajectoryPoints[i].SetActive(true);
            }
        }

        public void ClearLineTrajectory()
        {
            _lineRenderer.positionCount = 0;
        }
    }
}
