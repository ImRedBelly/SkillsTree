using UnityEngine;

namespace Core.Views
{
    public class PathLineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;

        public void UpdateColorPathLine(Gradient color) => _lineRenderer.colorGradient = color;

        public void UpdateLine(Transform[] points)
        {
            _lineRenderer.SetPosition(0, points[0].position);
            _lineRenderer.SetPosition(1, points[1].position);
        }
    }
}