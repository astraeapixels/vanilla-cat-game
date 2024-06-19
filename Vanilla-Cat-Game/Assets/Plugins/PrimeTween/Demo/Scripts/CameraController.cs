#if PRIME_TWEEN_INSTALLED
using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PrimeTweenDemo {
    public class CameraController : MonoBehaviour {
        [SerializeField] private HighlightedElementController highlightedElementController;
        [SerializeField] private SwipeTutorial swipeTutorial;
        [SerializeField] private Camera mainCamera;
        [SerializeField, Range(0f, 1f)] private float cameraShakeStrength = 0.4f;
        private float currentAngle;
        private Vector3? inputBeginPos;
        private bool isAnimating;
        private float curRotationSpeed;

        private void OnEnable() {
            currentAngle = transform.localEulerAngles.y;
            isAnimating = true;
            Tween.Custom(this, 0, 5, 2, (target, val) => target.curRotationSpeed = val);
        }

        private void Update() {
            if (isAnimating) {
                currentAngle += curRotationSpeed * Time.deltaTime;
                transform.localEulerAngles = new Vector3(0f, currentAngle);
            }
            if (highlightedElementController.current == null && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                inputBeginPos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0)) {
                inputBeginPos = null;
            }
            if (inputBeginPos.HasValue) {
                var deltaMove = Input.mousePosition - inputBeginPos.Value;
                if (Mathf.Abs(deltaMove.x) / Screen.width > 0.05f) {
                    isAnimating = false;
                    inputBeginPos = null;
                    currentAngle += Mathf.Sign(deltaMove.x) * 45f;
                    Tween.LocalRotation(transform, new Vector3(0f, currentAngle), 1.5f, Ease.OutCubic);
                    swipeTutorial.Hide();
                }
            }
        }

        public void ShakeCamera() {
            Shake();
        }

        internal Sequence Shake(float startDelay = 0) {
            return Tween.ShakeCamera(mainCamera, cameraShakeStrength, startDelay: startDelay);
        }
    }
}
#endif