using LimboOfCeres.Scripts.AudioScripts;
using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LimboOfCeres.Scripts.PowerUps
{
    public class Shield : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.otherCollider.gameObject.CompareTag(Constants.Tags.Shield)) return;

            if (Constants.Shield.TagsToCompareForDestruction.Contains(collision.collider.gameObject.tag))
            {
                Toggle();
            }
        }
    }
}
