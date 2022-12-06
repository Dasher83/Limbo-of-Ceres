using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Shared.Enums;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.FloorAndCeiling
{
    public class FitMainFloor : MonoBehaviour
    {
        private void Start()
        {
            Vector3 floorNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, offsetWidth: Constants.FloorAndCeiling.OffsetWidth, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            floorNewPosition.y = CameraUtils.OrthographicBounds.min.y + (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            gameObject.transform.position = floorNewPosition;
        }
    }
}
