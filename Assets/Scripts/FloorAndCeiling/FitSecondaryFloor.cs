using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.FloorAndCeiling
{
    public class FitSecondaryFloor : MonoBehaviour
    {
        private void Start()
        {
            Vector3 floorNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, offsetWidth: Constants.FloorAndCeiling.OffsetWidth, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            floorNewPosition.y = CameraUtils.OrthographicBounds.min.y + (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            floorNewPosition.x = CameraUtils.OrthographicBounds.max.x + (gameObject.GetComponent<SpriteRenderer>().size.x / 2);
            gameObject.transform.position = floorNewPosition;
        }
    }
}
