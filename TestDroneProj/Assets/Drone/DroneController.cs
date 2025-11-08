using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Drone
{
    public class DroneController : IDisposable
    {
        public DroneView DroneView => _droneView;
        
        private DroneView _droneView;
        
        public DroneController(DroneView droneView)
        {
            _droneView = droneView;
        }
        
        public void Dispose()
        {
            Object.Destroy(_droneView);
        }
        
        private void StartToWork()
        {
            
        }

        private void StopWorking()
        {
            
        }

        //private Transform SeekClosestAsteroid()
        //{
        //    
        //}
    }
}