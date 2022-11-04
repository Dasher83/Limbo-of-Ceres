using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using QuarkJam1Team1.Shared.Enums;
using UnityEngine;

namespace QuarkJam1Team1.Scripts.FloorAndCeiling
{
    public class FitMainFloor : MonoBehaviour
    {
        private void Start()
        {
            float lowerEdge;
            Vector3 floorNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            lowerEdge = (Camera.main.orthographicSize * -1) + (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            floorNewPosition.y = lowerEdge;
            gameObject.transform.position = floorNewPosition;
        }
    }
}
