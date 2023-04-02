using LimboOfCeres.Scripts.AudioScripts;
using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.Shared.Interfaces;
using UnityEngine;


namespace LimboOfCeres.Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Color _reflectedColor;

        private SpriteRenderer _spriteRenderer;
        private bool _isReflected;

        public bool IsReflected => _isReflected;

        private void Start()
        {
            _isReflected = false;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.CompareTag(Constants.Tags.Shield))
            {
                _spriteRenderer.color = _reflectedColor;
                _isReflected = true;
            }

            if (!_isReflected)
            {
                if (collision.gameObject.CompareTag(Constants.Tags.Player))
                {
                    if (collision.gameObject.GetComponent<IDamageable>().ReceiveDamage(1) > 0)
                    {
                        AudioPlayer.instance.PlaySoundEffect(SoundEffectsEnum.MALE_EVIL_LAUGH);
                    }
                }

                if (!collision.gameObject.CompareTag(Constants.Tags.Projectile) &&
                    !collision.collider.gameObject.CompareTag(Constants.Tags.Shield))
                {
                    gameObject.SetActive(false);
                }
            } 
            else if(Constants.ReflectedBullet.TagsToCompareForDestruction.Contains(collision.gameObject.tag))
            {
                gameObject.SetActive(false);
                collision.gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _isReflected = false;
            _spriteRenderer.color = Color.white;
        }
    }
}
