using LimboOfCeres.Scripts.Shared;
using UnityEngine;


namespace LimboOfCeres.Scripts.Spawnables.ExtraLife
{
    public class MoveExtraLife : MonoBehaviour
    {
        [SerializeField] private ExtraLifeScriptable _extraLife;

        private void Update()
        {
            gameObject.transform.Translate(Vector3.left * _extraLife.MovementSpeed.LimitedValue * Time.deltaTime);
        }
    }
}
