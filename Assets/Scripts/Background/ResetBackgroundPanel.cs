using QuarkJam1Team1.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Background
{
    public class ResetBackgroundPanel : MonoBehaviour
    {
        private float leftEdge;
        private float rightEdge;

        private void Start()
        {
            gameObject.transform.position = Vector3.zero;
            leftEdge = CameraUtils.LeftEdgeInRealWorldUnits;
            rightEdge = CameraUtils.RightEdgeInRealWorldUnits;
        }

        private void Update()
        {
            if (gameObject.transform.position.x <= leftEdge)
            {
                gameObject.transform.position = new Vector3(rightEdge, 0, 0);
            }
        }
    }
}
