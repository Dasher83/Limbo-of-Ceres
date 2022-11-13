using QuarkAcademyJam1Team1.Scripts.Shared;
using QuarkAcademyJam1Team1.Scripts.Utils;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.PlayerScritps
{
    public class PlayerRespawnSafely : MonoBehaviour
    {
        [SerializeField]
        private LayerMask dontIgnoreMe;
        private PlayerPositionReseter playerPositionReseter;
        private Rigidbody2D rb;
        private RaycastHit2D[] hits;
        private bool keepPlayerSafe;
        private bool isSafeToGetOut;
        private SpriteRenderer floorSpriteRenderer = null;
        private SpriteRenderer ceilingSpriteRenderer = null;

        public bool IsPlayerProtected { get { return keepPlayerSafe; } }
        public bool IsSafeToGetOut { get { return isSafeToGetOut; } }

        private void Start()
        {
            playerPositionReseter = gameObject.GetComponent<PlayerPositionReseter>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            keepPlayerSafe = false;
            isSafeToGetOut = false;
            floorSpriteRenderer = GameObject.Find(Constants.GameObjects.MainFloor).GetComponent<SpriteRenderer>();
            ceilingSpriteRenderer = GameObject.Find(Constants.GameObjects.MainCeiling).GetComponent<SpriteRenderer>();
        }

        private IEnumerator KeepPlayerSafeCorrutine()
        {
            while (keepPlayerSafe && !IsSafeToGetOut)
            {
                hits = Physics2D.CircleCastAll(
                    origin: gameObject.transform.position,
                    radius: (CameraUtils.OrthographicBounds.size.y - floorSpriteRenderer.size.y - ceilingSpriteRenderer.size.y) / 2 - Mathf.Epsilon,
                    direction: Vector2.right,
                    distance: Mathf.Epsilon,
                    layerMask: dontIgnoreMe);
                isSafeToGetOut = !hits.Any(
                    h => h.collider.gameObject.CompareTag(Constants.Tags.Projectile) || 
                    h.collider.gameObject.CompareTag(Constants.Tags.Enemy));
                yield return new WaitForEndOfFrame();
            }
        }

        public void GetToSafety()
        {
            keepPlayerSafe = true;
            playerPositionReseter.Reset();
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            StartCoroutine(KeepPlayerSafeCorrutine());
        }

        public void LeaveSafety()
        {
            keepPlayerSafe = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        private void OnDrawGizmosSelected()
        {
            if (floorSpriteRenderer == null || ceilingSpriteRenderer == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(gameObject.transform.position, (CameraUtils.OrthographicBounds.size.y - floorSpriteRenderer.size.y - ceilingSpriteRenderer.size.y) / 2 - Mathf.Epsilon);
        }
    }
}
