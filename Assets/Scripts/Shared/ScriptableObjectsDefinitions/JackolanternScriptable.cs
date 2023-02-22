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
        [SerializeField] private int _ammoRequestsMaximum;
        [SerializeField] private float _aimRateMinimum;
        [SerializeField] private float _aimRateMaximum;

        private ILimitedGetterUtility<int> _intLimitedGetter;
        private ILimitedGetterUtility<float> _floatLimitedGetter;

        public void Initialize()
        {
            _fireForceMinimum = Constants.Enemies.Jackolanterns.FireForceMinimum.Minimum;
            _fireForceMaximum = Constants.Enemies.Jackolanterns.FireForceMaximum.Minimum;
            _ammoRequestsMinimum = Constants.Enemies.Jackolanterns.AmmoRequestsMinimum.Minimum;
            _ammoRequestsMaximum = Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Minimum;
            _aimRateMinimum = Constants.Enemies.Jackolanterns.AimRateMinimum.Maximum;
            _aimRateMaximum = Constants.Enemies.Jackolanterns.AimRateMaximum.Maximum;

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

        public int AmmoRequestsMaximum
        {
            get
            {
                return _ammoRequestsMaximum;
            }

            set
            {
                _ammoRequestsMaximum = _intLimitedGetter.GetWithinLimits(
                    unlimitedValue: value,
                    minimum: Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Minimum,
                    maximum: Constants.Enemies.Jackolanterns.AmmoRequestsMaximum.Maximum);
            }
        }

        public int AmmoRequests => Random.Range(_ammoRequestsMinimum, _ammoRequestsMaximum + 1);

        public float AimRateMinimum
        {
            get
            {
                return _aimRateMinimum;
            }

            set
            {
                _aimRateMinimum = _floatLimitedGetter.GetWithinLimits(
                    unlimitedValue: value,
                    minimum: Constants.Enemies.Jackolanterns.AimRateMinimum.Minimum,
                    maximum: Constants.Enemies.Jackolanterns.AimRateMinimum.Maximum);
            }
        }

        public float AimRateMaximum
        {
            get
            {
                return _aimRateMaximum;
            }

            set
            {
                _aimRateMaximum = _floatLimitedGetter.GetWithinLimits(
                    unlimitedValue: value,
                    minimum: Constants.Enemies.Jackolanterns.AimRateMaximum.Minimum,
                    maximum: Constants.Enemies.Jackolanterns.AimRateMaximum.Maximum);
            }
        }

        public float AimRate => Random.Range(_aimRateMinimum, _aimRateMaximum);
    }
}
