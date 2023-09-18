using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public HingeJoint steeringWheel;
        public float maxTurnAngle;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = Mathf.Clamp(steeringWheel.angle / maxTurnAngle, -1, 1);
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            //float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, 1, 0, 0);
#else
            m_Car.Move(h, 1, 0, 0f);
#endif
        }
    }
}
