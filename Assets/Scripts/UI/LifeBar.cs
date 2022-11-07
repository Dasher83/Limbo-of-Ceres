using QuarkAcademyJam1Team1.Scripts.Managers;
using QuarkAcademyJam1Team1.Scripts.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class LifeBar : MonoBehaviour
    {
        // capas que si usamos el playerdata, asi el gameover se setea desde el manager, y no se manda game over en cada frame
        [SerializeField]private int lifes;
        [SerializeField]private int numbersOfHearts;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private Transform hearts;
        [SerializeField] private Sprite heartSprite;
        [SerializeField] private Sprite emptyHeartSprite;

        void Start()
        {
            lifes = Constants.Player.InitialLifes;
            numbersOfHearts = Constants.Player.MaxLifes;
        }


        void Update()
        {
            if (lifes > numbersOfHearts)
            {
                lifes = numbersOfHearts;
            }

            for (int i = 0; i < hearts.childCount; i++)
            {
                if (i < lifes)
                {
                    hearts.GetChild(i).GetComponent<Image>().sprite = heartSprite;
                }else{
                    hearts.GetChild(i).GetComponent<Image>().sprite = emptyHeartSprite;
                }
                if (i > lifes && i > 3) hearts.GetChild(i).gameObject.SetActive(false);
                else hearts.GetChild(i).gameObject.SetActive(true);
                // TODO: que el comportamiento sea el esperado y no este 
            }
        }

        public void Addlife()
        {
            lifes++;
            Debug.Log("la vida actual es: " + lifes);
        }

        public void RemoveLife()
        {
            lifes--;
            Debug.Log("la vida actual es: " + lifes);
        }
    }
}
