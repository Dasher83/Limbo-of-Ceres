using UnityEngine;

public static class SpriteUtils
{
    public static void ResizeSpriteToScreen(GameObject target, int fitToScreenWidth = 1, int fitToScreenHeight = 1)
    {
        SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();

        spriteRenderer.transform.localScale = new Vector3(1, 1, 1);

        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 newLocalScale = spriteRenderer.transform.localScale;
        if (fitToScreenWidth != 0)
        {
            newLocalScale.x = (float)(worldScreenWidth / width / fitToScreenWidth);
        }

        if (fitToScreenHeight != 0)
        {
            newLocalScale.y = (float)(worldScreenHeight / height / fitToScreenHeight);
        }
        spriteRenderer.transform.localScale = newLocalScale;
    }
}
