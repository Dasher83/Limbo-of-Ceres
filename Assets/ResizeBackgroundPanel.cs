using UnityEngine;

public class ResizeBackgroundPanel : MonoBehaviour
{
    void Start()
    {
        SpriteUtils.ResizeSpriteToScreen(target: gameObject);                  
    }
}
