using System.Collections;
using UnityEngine;

namespace LimboOfCeres.Scripts.PlayerScritps
{
    public class PlayerFlicker : MonoBehaviour
    {
        [SerializeField]
        private float flickerDuration;
        [SerializeField]
        private Color newColorHigh;
        [SerializeField]
        private Color newColorLow;
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private bool isFlickering;

        public bool IsFlickering { get { return isFlickering; } }

        private IEnumerator FlickeringCorrutine()
        {
            while(isFlickering)
            {
                newColorLow.a = 0.50f;
                spriteRenderer.color = newColorLow;
                yield return new WaitForSeconds(flickerDuration);
                newColorHigh.a = 0.75f;
                spriteRenderer.color = newColorHigh;
                yield return new WaitForSeconds(flickerDuration);
            }
            spriteRenderer.color = originalColor;
            yield break;
        }

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
            isFlickering = false;
        }

        public void StartFlickering()
        {
            isFlickering = true;
            StartCoroutine(FlickeringCorrutine());
        }

        public void StopFlickering()
        {
            isFlickering = false;
        }
    }
}
