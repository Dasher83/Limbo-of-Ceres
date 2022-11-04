using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using QuarkJam1Team1.Shared.Enums;
using UnityEngine;

namespace QuarkJam1Team1.Scripts.FloorAndCeiling
{
    public class FitCeiling : MonoBehaviour
    {
        private void Start()
        {
            float upperEdge;
            Vector3 ceilingNewPosition = Vector3.zero;
            SpriteUtils.ResizeSpriteToScreen(target: gameObject, fitToScreenHeight: Constants.FloorAndCeiling.HeightProportion, mode: SpriteResizeMode.TILED);
            upperEdge = Camera.main.orthographicSize - (gameObject.GetComponent<SpriteRenderer>().size.y / 2);
            ceilingNewPosition.y = upperEdge;
            gameObject.transform.position = ceilingNewPosition;
        }
    }
}
