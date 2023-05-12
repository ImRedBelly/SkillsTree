using UnityEngine;

namespace Tools
{
    [ExecuteAlways]
    public class UpdateLinesController : MonoBehaviour
    {
        private PathLineActivator[] lines;

        private void OnValidate()
        {
            lines = FindObjectsOfType<PathLineActivator>();
        }

        private void Update()
        {
            foreach (var line in lines)
                line.UpdateLine();
        }
    }
}