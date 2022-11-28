using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AccelerationVlocityControl: MonoBehaviour
    {
        public Vector3 angularInput = Vector3.zero;
        private Vector3 lastInput;
        public Vector3 velocityShown;
        
        private Rigidbody rigi;
        private Vector3 lastVelocity;
        private Vector3 nowVelocity;
        private float timer;

        private void Start()
        {
            lastInput = angularInput;
            rigi = GetComponent<Rigidbody>();
            lastVelocity = rigi.velocity;
            timer = 0f;
            velocityShown = rigi.velocity;
        }

        private void FixedUpdate()
        {
            velocityShown = rigi.velocity;
            
            //print(angularInput - lastInput);
            //print("timer:"+timer);
            timer += Time.fixedDeltaTime;
            if ((angularInput - lastInput).magnitude > 0.01)
            {
                //print("has changed");
                lastInput = angularInput;
                nowVelocity = lastVelocity + angularInput * timer;
                lastVelocity = nowVelocity;
                rigi.velocity = nowVelocity;
                timer = 0f;
            }

            //rigi.velocity = new Vector3(1, 3, 4);
        }
    }
}