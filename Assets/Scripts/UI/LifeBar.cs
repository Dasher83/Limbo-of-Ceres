using QuarkAcademyJam1Team1.Scripts.Shared.ScriptableObjectsDefinitions;
using QuarkAcademyJam1Team1.Scripts.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace QuarkAcademyJam1Team1.Scripts.UI
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private int lifes;
        [SerializeField] private int minHeartsInScreen;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private Transform hearts;
        [SerializeField] private Sprite heartSprite;
        [SerializeField] private Sprite emptyHeartSprite;


        void Start()
        {
            lifes = playerData.Lifes;
            minHeartsInScreen = Constants.Player.InitialLifes - 1;
        }


        void Update()
        {
            lifes = playerData.Lifes;

            for (int i = 0; i < hearts.childCount; i++)
            {
                if (i < lifes)
                {
                    hearts.GetChild(i).GetComponent<Image>().sprite = heartSprite;
                }else{
                    hearts.GetChild(i).GetComponent<Image>().sprite = emptyHeartSprite;
                }
                if (i > minHeartsInScreen && i > lifes - 1) 
                {
                    hearts.GetChild(i).gameObject.SetActive(false); // TODO: can make an animation of banishin 
                    continue;
                }
                hearts.GetChild(i).gameObject.SetActive(true);
            }
        }


    }
}
