using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.FloorAndCeiling
{
    public class FitColliderWidthToScreen : MonoBehaviour
    {

        void Start()
        {
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            Vector2 newSize = boxCollider2D.size;
            newSize.x = CameraUtils.OrthographicBounds.size.x + Constants.FloorAndCeiling.CollidersExtraWidth;
            boxCollider2D.size = newSize;
        }
    }
}
