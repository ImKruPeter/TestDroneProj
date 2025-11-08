using System;
using UnityEngine;

namespace Drone
{
    public class DroneBaseView : MonoBehaviour
    {
        public Action OnAsteroidGetEvent;
        
        private Fraction _fraction;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("DroneFull"))
            {
                OnAsteroidGetEvent?.Invoke();
            }
        }
    }
}