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
        

        public void RemoveHeart()
        {
            startPos = transform.position;
            startScale = transform.localScale;
            startColor = transform.GetComponent<Image>().color;
            isInactive = true;
            if (receivAnimationCoroutine != null)
            {
                StopCoroutine(receivAnimationCoroutine);
                receivAnimationCoroutine = null;
                transform.localScale = startScale;
                transform.position = startPos;
                transform.GetComponent<Image>().color = startColor;
            }
            receivAnimationCoroutine = StartCoroutine(VanishAnim());
        }

        public void AddHeart()
        {
            if (receivAnimationCoroutine != null)
            {
                StopCoroutine(receivAnimationCoroutine);
                receivAnimationCoroutine = null;
                transform.localScale = startScale;
                transform.position = startPos;
                transform.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, 1f);
            }
            isInactive = false;
            gameObject.SetActive(true);
            receivAnimationCoroutine = StartCoroutine(AppearAnim());
        }

        private IEnumerator VanishAnim()
        {
            float time = 0;
            Color vanishColor = startColor;
            Vector3 vanishScale = startScale;

            while (time < Constants.Animations.HeartAnimTime)
            {
                time += Time.deltaTime;
                ShakeHeart(Constants.Animations.ShakeAnimTime);

                vanishColor = new Color(vanishColor.r, vanishColor.g, vanishColor.b, vanishColor.a -= Constants.Animations.VanishAnimTime);
                transform.GetComponent<Image>().color = vanishColor;

                vanishScale = new Vector3(startScale.x, startScale.y -= 0.02f, startScale.z);
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

            while (time < Constants.Animations.HeartAnimTime)
            {
                

                yield return new WaitForFixedUpdate();
            }

        }

        private void ShakeHeart(float distance)
        {
            Vector3 shakePos = startPos + (Random.insideUnitSphere * distance);
            transform.position = shakePos;
        }
    }
}
