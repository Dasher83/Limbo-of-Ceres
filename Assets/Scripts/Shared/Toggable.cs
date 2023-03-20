using UnityEngine;


namespace LimboOfCeres.Scripts.Shared
{
    public class Toggable : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
