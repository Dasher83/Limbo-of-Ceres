using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared.Structs;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternData", menuName = "ScriptableObjects/JackolanternData", order = 5)]
    public class JackolanternScriptable : ScriptableObject, IInitializable
    {
        [SerializeField] private float _fireForceMinimum;
        [SerializeField] private float _fireForceMaximum;
        private Range<float> _fireForceMinimumRange;
        private Range<float> _fireForceMaximumRange;

        public void Initialize()
        {
            _fireForceMinimum = Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum;
            _fireForceMaximum = Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum;
            _fireForceMinimumRange = new Range<float>(
                minimum: Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireForceMinimum.Maximum);
            _fireForceMaximumRange = new Range<float>(
                minimum: Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum,
                maximum: Constants.Enemies.Jackolanterns.FireForceMaximum.Maximum);
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

        public float FireForceMaximum
        {
            get
            {
                return _fireForceMaximum;
            }

            set
            {
                if (_fireForceMaximumRange.Maximum.CompareTo(value) < 0)
                {
                    _fireForceMaximum = _fireForceMaximumRange.Maximum;
                    return;
                }

                if (_fireForceMaximumRange.Minimum.CompareTo(value) > 0)
                {
                    _fireForceMaximum = _fireForceMaximumRange.Minimum;
                    return;
                }

                _fireForceMaximum = value;
            }
        }

        public float FireForceRandom => Random.Range(_fireForceMaximum, _fireForceMaximum);
    }
}
