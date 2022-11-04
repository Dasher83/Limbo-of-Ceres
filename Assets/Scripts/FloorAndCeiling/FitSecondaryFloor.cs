using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using QuarkJam1Team1.Shared.Enums;
using QuarkJam1Team1.Utils;
using UnityEngine;

namespace QuarkJam1Team1
{
    public class FitSecondaryFloor : MonoBehaviour
    {
        private void Start()
        {
            Vector3 floorNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            floorNewPosition.y = CameraUtils.LowerEdgeInRealWorldUnits + (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            floorNewPosition.x = CameraUtils.RightEdgeInRealWorldUnits;
            gameObject.transform.position = floorNewPosition;
        }
    }
}
