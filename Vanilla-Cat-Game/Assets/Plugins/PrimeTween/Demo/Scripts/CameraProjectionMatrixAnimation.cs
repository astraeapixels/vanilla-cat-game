#if PRIME_TWEEN_INSTALLED
using PrimeTween;
using UnityEngine;

namespace PrimeTweenDemo {
    public class CameraProjectionMatrixAnimation : MonoBehaviour {
        [SerializeField] private Camera mainCamera;
        private float interpolationFactor;
        private bool isOrthographic;
        private Tween tween;

        public void AnimateCameraProjection() {
            isOrthographic = !isOrthographic;
            tween.Stop();
            tween = Tween.Custom(this, interpolationFactor, isOrthographic ? 1 : 0, 0.6f, ease: Ease.InOutSine, onValueChange: (target, t) => {
                    target.InterpolateProjectionMatrix(t);
                })
                .OnComplete(this, target => {
                    target.mainCamera.orthographic = target.isOrthographic;
                    target.mainCamera.ResetProjectionMatrix();
                });
        }

        private void InterpolateProjectionMatrix(float _interpolationFactor) {
            interpolationFactor = _interpolationFactor;
            float aspect = (float)Screen.width / Screen.height;
            var orthographicSize = mainCamera.orthographicSize;
            var perspectiveMatrix = Matrix4x4.Perspective(mainCamera.fieldOfView, aspect, mainCamera.nearClipPlane, mainCamera.farClipPlane);
            var orthoMatrix = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, mainCamera.nearClipPlane, mainCamera.farClipPlane);
            Matrix4x4 projectionMatrix = default;
            for (int i = 0; i < 16; i++) {
                projectionMatrix[i] = Mathf.Lerp(perspectiveMatrix[i], orthoMatrix[i], _interpolationFactor);
            }
            mainCamera.projectionMatrix = projectionMatrix;
        }

        public bool IsAnimating => tween.isAlive;
    }
}
#endif