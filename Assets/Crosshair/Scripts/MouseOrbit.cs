using UnityEngine;

namespace Assets.Crosshair.Scripts
{
    public class MouseOrbit : MonoBehaviour
    {
        public float damping;
               
        public float distance = 5.0f;
        public float xSpeed = 120.0f;
        public float ySpeed = 120.0f;

        public float yMinLimit = -20f;
        public float yMaxLimit = 80f;

        float x = 0.0f;
        float y = 0.0f;


        void Start()
        {
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        public void LateUpdate()
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
                        
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, damping * Time.deltaTime);            
        }

        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360f;
            if (angle > 360)
                angle -= 360f;
            return Mathf.Clamp(angle, min, max);
        }
    }
}
