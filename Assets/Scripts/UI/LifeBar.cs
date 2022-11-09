using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using UnityEngine.UI;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private Sprite heartSprite;
        [SerializeField] private Sprite emptyHeartSprite;
        private IDurable durable;

        public IDurable Durable { set { durable = value; } }

        private void Update()
        {
            if (durable == null) return;

            if (durable.CurrentDurability == 0) gameObject.SetActive(false);

            for (int i = 0; i < durable.InitialDurability && i < durable.CurrentDurability; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = heartSprite;
            }

            for(int i = durable.CurrentDurability; i < durable.InitialDurability; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = emptyHeartSprite;
            }

            for (int i = durable.InitialDurability; i < durable.MaxDurability; i++)
            {
                if (i <= durable.CurrentDurability - 1)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true); // TODO: can make an animation of banishin
                }
                else
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }


    }
}
