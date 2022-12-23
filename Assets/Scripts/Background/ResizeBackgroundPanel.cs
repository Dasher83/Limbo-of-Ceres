using LimboOfCeres.Scripts.Utils;
using UnityEngine;

namespace LimboOfCeres.Scripts.Background
{
    public class ResizeBackgroundPanel : MonoBehaviour
    {
        void Start()
        {
            SpriteUtils.ResizeSpriteToScreen(target: gameObject);
        }
    }
}

