using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Enums;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.FloorAndCeiling
{
    public class FitMainCeiling : MonoBehaviour
    {
        private void Start()
        {
            Vector3 ceilingNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, offsetWidth: Constants.FloorAndCeiling.OffsetWidth, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            ceilingNewPosition.y = CameraUtils.OrthographicBounds.max.y - (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            gameObject.transform.position = ceilingNewPosition;
        }
    }
}
