using QuarkAcademyJam1Team1.Scripts.Utils;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Background
{
    public class ResizeBackgroundPanel : MonoBehaviour
    {
        void Start()
        {
            SpriteUtils.ResizeSpriteToScreen(target: gameObject);
        }
    }
}

