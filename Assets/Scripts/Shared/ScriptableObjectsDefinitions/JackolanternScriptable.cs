using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared.Structs;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternData", menuName = "ScriptableObjects/JackolanternData", order = 5)]
    public class JackolanternScriptable : ScriptableObject, IInitializable
    {
        [SerializeField] private float _fireForceMinimum;
        private Range<float> _fireForceMinimumRange;

        public void Initialize()
        {
            _fireForceMinimum = Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum;
            _fireForceMinimumRange = new Range<float>(
                minimum: Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireForceMinimum.Maximum);
        }

        public float FireForceMinimum
        {
            get
            {
                return _fireForceMinimum;
            }

            set
            {
                if (_fireForceMinimumRange.Maximum.CompareTo(value) < 0)
                {
                    _fireForceMinimum = _fireForceMinimumRange.Maximum;
                    return;
                }

                if (_fireForceMinimumRange.Minimum.CompareTo(value) > 0)
                {
                    _fireForceMinimum = _fireForceMinimumRange.Minimum;
                    return;
                }

                _fireForceMinimum = value;
            }
        }
    }
}
