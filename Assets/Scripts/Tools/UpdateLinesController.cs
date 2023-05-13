using Core.Controllers;
using UnityEngine;

namespace Tools
{
    [ExecuteAlways]
    public class UpdateLinesController : MonoBehaviour
    {
        private PathLineController[] lines;

        private void OnValidate()
        {
            lines = FindObjectsOfType<PathLineController>();
        }

        private void Update()
        {
            foreach (var line in lines)
                line.UpdateLine();
        }
    }
}