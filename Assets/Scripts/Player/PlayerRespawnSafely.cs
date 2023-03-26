using LimboOfCeres.Scripts.Shared;
using LimboOfCeres.Scripts.TimeScripts;
using LimboOfCeres.Scripts.Utils;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace LimboOfCeres.Scripts.Player
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
        private ResettableTimer recoveryTimer;

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
            recoveryTimer = new ResettableTimer(time: Constants.Player.RecoveryTime);
        }

        private void UpdateRigidbody2DConstraints(RigidbodyConstraints2D newConstraints)
        {
            rb.constraints = newConstraints;
            rb.AddForce(Vector2.up * Mathf.Epsilon);
        }

        private IEnumerator KeepPlayerSafeCorrutine()
        {
            while (keepPlayerSafe && !IsSafeToGetOut)
            {
                recoveryTimer.Countdown(time: Time.deltaTime);
                hits = Physics2D.CircleCastAll(
                    origin: gameObject.transform.position,
                    radius: (CameraUtils.OrthographicBounds.size.y - floorSpriteRenderer.size.y - ceilingSpriteRenderer.size.y) / 2 - Mathf.Epsilon,
                    direction: Vector2.right,
                    distance: Constants.Player.SafetyBubble.TravelDistance,
                    layerMask: dontIgnoreMe);
                isSafeToGetOut = recoveryTimer.OutOfTime && !hits.Any(
                    h => h.collider.gameObject.CompareTag(Constants.Tags.Projectile) || 
                    h.collider.gameObject.CompareTag(Constants.Tags.Enemy));
                yield return new WaitForEndOfFrame();
            }
            LeaveSafety();
        }

        private void LeaveSafety()
        {
            recoveryTimer.Reset();
            keepPlayerSafe = false;
            isSafeToGetOut = false;
            UpdateRigidbody2DConstraints(RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation);
        }

        public void GetToSafety()
        {
            keepPlayerSafe = true;
            playerPositionReseter.Reset();
            UpdateRigidbody2DConstraints(RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation);
            StartCoroutine(KeepPlayerSafeCorrutine());
        }

        private void OnDrawGizmosSelected()
        {
            if (floorSpriteRenderer == null || ceilingSpriteRenderer == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(
                gameObject.transform.position,
                (CameraUtils.OrthographicBounds.size.y - floorSpriteRenderer.size.y - ceilingSpriteRenderer.size.y) / 2 - Mathf.Epsilon);
        }
    }
}
