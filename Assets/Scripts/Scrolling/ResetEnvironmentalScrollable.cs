using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Scrolling
{
    public class ResetEnvironmentalScrollable : MonoBehaviour
    {
        private float leftEdge;
        private float rightEdge;
        private Vector3 newPosition;

        private void Start()
        {
            leftEdge = CameraUtils.LeftEdgeInRealWorldUnits;
            rightEdge = CameraUtils.RightEdgeInRealWorldUnits;
        }

        private void Update()
        {
            if (gameObject.transform.position.x <= leftEdge)
            {
                newPosition = gameObject.transform.position;
                newPosition.x = rightEdge;
                gameObject.transform.position = newPosition;
            }
        }
    }
}
