using System;
using UnityEngine;

namespace Core.Scripts.Levels.Slingshot
{
    [Serializable]
    public class SlingshotTrajectory
    {
        [SerializeField] private LineRenderer _lineRenderer;
        
        public void DrawTrajectory(Vector2 targetPosition, Vector2 startPosition, float power)
        {
            _lineRenderer.positionCount = 20;
            Vector3[] positions = new Vector3[20];

            Vector2 launchVelocity = (startPosition - targetPosition) * power / 50;
            float timeOfFlight = (2 * launchVelocity.y) / Mathf.Abs(Physics2D.gravity.y);
            
            for (int i = 0; i < positions.Length; i++)
            {
                float t = i * timeOfFlight / (positions.Length - 1); 

                float x = launchVelocity.x * t;
                float y = launchVelocity.y * t + 0.5f * Physics2D.gravity.y * t * t;

                positions[i] = startPosition + new Vector2(x, y);
            }

            _lineRenderer.SetPositions(positions);
        }
    }
}
