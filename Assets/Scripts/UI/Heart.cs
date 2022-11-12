using QuarkAcademyJam1Team1.Scripts.Shared;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class Heart : MonoBehaviour
    {
        private Vector3 startPos;
        private Vector3 startScale;
        private Color startColor;
        private Coroutine receivAnimationCoroutine;
        private bool isInactive = false;

        public bool IsInactive { get {return isInactive; } private set{isInactive = false;}}

        public void Initialize()
        {
            startPos = transform.position;
            startScale = transform.localScale;
            startColor = transform.GetComponent<Image>().color;
        }

        public void RemoveHeart()
        {
            if (receivAnimationCoroutine != null)
            {
                StopCoroutine(receivAnimationCoroutine);
                receivAnimationCoroutine = null;
                ResetHearts(true);
            }
            isInactive = true;
            receivAnimationCoroutine = StartCoroutine(VanishAnim());
        }

        public void RemoveHeart(Sprite sprite)
        {
            transform.GetComponent<Image>().sprite = sprite;
        }

        public void AddHeart()
        {
            if (receivAnimationCoroutine != null)
            {
                StopCoroutine(receivAnimationCoroutine);
                receivAnimationCoroutine = null;
                ResetHearts();
            }
            isInactive = false;
            gameObject.SetActive(true);
            receivAnimationCoroutine = StartCoroutine(AppearAnim());
        }

        public void AddHeart(Sprite sprite)
        {
            transform.GetComponent<Image>().sprite = sprite;
        }

        private IEnumerator VanishAnim()
        {
            float time = 0;
            Color vanishColor = startColor;
            Vector3 vanishScale = startScale;

            while (time < Constants.Animations.HeartAnimTime)
            {
                time += Time.deltaTime;
                ShakeHeart(Constants.Animations.ShakeAnim);

                vanishColor = new Color(vanishColor.r, vanishColor.g, vanishColor.b, vanishColor.a -= Constants.Animations.VanishAnimTime);
                transform.GetComponent<Image>().color = vanishColor;

                vanishScale = new Vector3(vanishScale.x, vanishScale.y -= Constants.Animations.VanishAnimTime, vanishScale.z);
                transform.localScale = vanishScale;

                yield return new WaitForFixedUpdate();
            }

            transform.position = startPos;
            transform.localScale = startScale;
            transform.GetComponent<Image>().color = startColor;
            gameObject.SetActive(false);
        }

        private IEnumerator AppearAnim()
        {
            float time = 0;
            Color appearColor = transform.GetComponent<Image>().color;
            Vector3 appearScale = transform.localScale;

            while (time < Constants.Animations.HeartAnimTime)
            {
                
                time = Time.deltaTime;

                if (appearColor.a < startColor.a)
                {
                    appearColor = new Color(appearColor.r, appearColor.g, appearColor.b, appearColor.a += Constants.Animations.AppearAnimTime);
                    transform.GetComponent<Image>().color = appearColor;
                }
                if (appearScale.y < startScale.y)
                {
                    appearScale = new Vector3(appearScale.x, appearScale.y += Constants.Animations.AppearAnimTime, appearScale.z);
                    transform.localScale = appearScale;
                }

                yield return new WaitForFixedUpdate();
            }

            transform.GetComponent<Image>().color = startColor;
            transform.localScale = startScale;
        }

        private void ShakeHeart(float distance)
        {
            Vector3 shakePos = startPos + (Random.insideUnitSphere * distance);
            transform.position = shakePos;
        }

        private void ResetHearts(bool isRemove = false)
        {
            if (isRemove)
            {
                transform.localScale = startScale;
                transform.position = startPos;
                transform.GetComponent<Image>().color = startColor;
                return;
            }
            transform.localScale = startScale;
            transform.position = startPos;
            transform.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        }
    }
}
