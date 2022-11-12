using QuarkAcademyJam1Team1.Scripts.Shared.Interfaces;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private Sprite heartSprite;
        [SerializeField] private Sprite emptyHeartSprite;
        private List<Heart> hearts;
        private IDurable durable;

        public IDurable Durable { set { durable = value; } }


        private void Start()
        {
            hearts = new List<Heart>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Heart heart = transform.GetChild(i).GetComponent<Heart>();
                heart.Initialize();
                hearts.Add(heart);
            }
        }

        private void Update()
        {
            if (durable == null) return;

            if (durable.CurrentDurability == 0) gameObject.SetActive(false);

            for (int i = 0; i < durable.InitialDurability && i < durable.CurrentDurability; i++)
            {
                hearts[i].AddHeart(heartSprite);
            }

            for(int i = durable.CurrentDurability; i < durable.InitialDurability; i++)
            {
                hearts[i].RemoveHeart(emptyHeartSprite);
            }

            for (int i = durable.InitialDurability; i < durable.MaxDurability; i++)
            {
                if (i <= durable.CurrentDurability - 1)
                {
                    if (hearts[i].IsInactive)
                    {
                        hearts[i].AddHeart();   
                    }
                }
                else
                {
                    if (!hearts[i].IsInactive)
                    {
                        hearts[i].RemoveHeart();
                    }
                }
            }
        }
    }
}
