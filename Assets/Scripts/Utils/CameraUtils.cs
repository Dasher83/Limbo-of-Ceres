using UnityEngine;

namespace LimboOfCeres.Scripts.Utils
{
    public static class CameraUtils
    {
        public static Bounds OrthographicBounds
        {
            get
            {
                Camera camera = Camera.main;
                float cameraHeight = camera.orthographicSize * 2;
                float screenAspect = (float)Screen.width / (float)Screen.height;
                Bounds bounds = new Bounds(
                    camera.transform.position,
                    new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
                return bounds;
            }
        }
    }
}
