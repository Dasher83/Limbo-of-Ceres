using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Shared.Enums;
using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.FloorAndCeiling
{
    public class FitSecondaryCeiling : MonoBehaviour
    {
        private void Start()
        {
            Vector3 ceilingNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            ceilingNewPosition.x = CameraUtils.OrthographicBounds.max.x + (gameObject.GetComponent<SpriteRenderer>().size.x / 2);
            ceilingNewPosition.y = CameraUtils.OrthographicBounds.max.y - (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            gameObject.transform.position = ceilingNewPosition;
        }
    }
}
