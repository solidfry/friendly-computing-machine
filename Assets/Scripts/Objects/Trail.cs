using UnityEngine;

namespace Objects
{
    public class Trail : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        public Transform ballTransform;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            DrawLine();
        }

        void DrawLine()
        {
            lineRenderer.positionCount++;

            lineRenderer.SetPosition(lineRenderer.positionCount-1, ballTransform.position);
        }

        void ResetLine()
        {
            lineRenderer.positionCount = 0;
        }
    }
}
