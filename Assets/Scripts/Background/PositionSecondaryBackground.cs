using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Background
{
    public class PositionSecondaryBackground : MonoBehaviour
    {
        private void Start()
        {
            gameObject.transform.position = new Vector3(CameraUtils.OrthographicBounds.max.x + CameraUtils.OrthographicBounds.extents.x, 0, 0);
        }
    }
}
