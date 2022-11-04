using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using QuarkJam1Team1.Shared.Enums;
using QuarkJam1Team1.Utils;
using UnityEngine;

namespace QuarkJam1Team1
{
    public class FitSecondaryCeiling : MonoBehaviour
    {
        private void Start()
        {
            Vector3 ceilingNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            ceilingNewPosition.x = CameraUtils.RightEdgeInRealWorldUnits;
            ceilingNewPosition.y = CameraUtils.UpperEdgeInRealWorldUnits - (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            gameObject.transform.position = ceilingNewPosition;
        }
    }
}
