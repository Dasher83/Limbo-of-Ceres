using LimboOfCeres.Scripts.Shared.Interfaces;
using LimboOfCeres.Scripts.Shared.Structs;
using LimboOfCeres.Scripts.Utils;
using UnityEngine;


namespace LimboOfCeres.Scripts.Shared.ScriptableObjectsDefinitions
{
    [CreateAssetMenu(fileName = "JackolanternData", menuName = "ScriptableObjects/JackolanternData", order = 5)]
    public class JackolanternScriptable : ScriptableObject, IInitializable
    {
        [SerializeField] private float _fireForceMinimum;
        [SerializeField] private float _fireForceMaximum;
        [SerializeField] private int _ammoRequestsMinimum;

        private ILimitedGetterUtility<int> _intLimitedGetter;
        private ILimitedGetterUtility<float> _floatLimitedGetter;

        public void Initialize()
        {
            _fireForceMinimum = Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum;
            _fireForceMaximum = Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum;
            _ammoRequestsMinimum = Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Minimum;

            _intLimitedGetter = new LimitedGetterUtility<int>();
            _floatLimitedGetter = new LimitedGetterUtility<float>();
        }

        public float FireForceMinimum
        {
            get
            {
                return _fireForceMinimum;
            }

            set
            {
                _fireForceMinimum = _floatLimitedGetter.GetWithinLimits(
                    unlimitedValue: value,
                    minimum: Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum,
                    maximum: Constants.Enemies.Jackolanterns.FireForceMinimum.Maximum);
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
                _fireForceMaximum = _floatLimitedGetter.GetWithinLimits(
                    unlimitedValue: value,
                    minimum: Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum,
                    maximum: Constants.Enemies.Jackolanterns.FireForceMaximum.Maximum);
            }
        }

        public float FireForceRandom => Random.Range(_fireForceMaximum, _fireForceMaximum);

        public int AmmoRequestsMinimum
        {
            get
            {
                return _ammoRequestsMinimum;
            }

            set
            {
                _ammoRequestsMinimum = _intLimitedGetter.GetWithinLimits(
                    unlimitedValue: value,
                    minimum: Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Minimum,
                    maximum: Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Maximum);
            }
        }

        public int AmmoRequests => Random.Range(_ammoRequestsMinimum, Constants.Enemies.Jackolanterns.AmmoRequestsMaximum + 1);
    }
}
