using QuarkJam1Team1.Shared.Enums;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.Utils 
{
    public static class SpriteUtils
    {
        public static void ResizeSpriteToScreen(
            GameObject target, float offsetWidth = 0f, float fitToScreenWidth = 1f,
            float fitToScreenHeight = 1f, SpriteResizeMode mode = SpriteResizeMode.SIMPLE)
        {
            SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();

            spriteRenderer.transform.localScale = new Vector3(1, 1, 1);

            float width = spriteRenderer.sprite.bounds.size.x;
            float height = spriteRenderer.sprite.bounds.size.y;

            double worldScreenHeight = Camera.main.orthographicSize * 2.0;
            double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            if(mode == SpriteResizeMode.SIMPLE)
            {
                Vector3 newLocalScale = spriteRenderer.transform.localScale;
                if (fitToScreenWidth != 0)
                {
                    newLocalScale.x = (float)(worldScreenWidth / width / fitToScreenWidth) + offsetWidth;
                }

                if (fitToScreenHeight != 0)
                {
                    newLocalScale.y = (float)(worldScreenHeight / height / fitToScreenHeight);
                }
                spriteRenderer.transform.localScale = newLocalScale;
            }
            else if (mode == SpriteResizeMode.TILED)
            {
                Vector2 newSize = Vector2.zero;
                if (fitToScreenWidth != 0)
                {
                    newSize.x = (float)(worldScreenWidth / width * fitToScreenWidth / 2) + offsetWidth;
                }
                else
                {
                    newSize.x = spriteRenderer.size.x;
                }

                if (fitToScreenHeight != 0)
                {
                    newSize.y = (float)(worldScreenHeight / height * fitToScreenHeight / 2);
                }
                else
                {
                    newSize.y = spriteRenderer.size.y;
                }
                spriteRenderer.size = newSize;
            }
        }
    }
}
