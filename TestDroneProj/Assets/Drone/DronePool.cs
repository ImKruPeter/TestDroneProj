using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    public class DronePool
    {
        private readonly List<DroneController> _inactiveDronesList = new List<DroneController>();
        private readonly List<DroneController> _activeDronesList = new List<DroneController>();

        private Vector2 _leftUpperCornerOfLevel = new Vector2(-79, 44);
        private Vector2 _rightDownCornerOfLevel = new Vector2(79, -44);

        private Vector2 _vector2Buffer = new Vector2();
        
        private DroneView _dronePrefab = Resources.Load<DroneView>("DroneView");
        
        private Transform _dronesTransform;
        
        public DronePool()
        {
            _dronesTransform = Object.Instantiate(new GameObject("Drones"), Vector3.zero,Quaternion.identity).transform;
        }
        
        public void CreateDrone()
        {
            if (_inactiveDronesList.Count == 0)
            {
                RandomPos();
                
                var spawnedDrone = Object.Instantiate(_dronePrefab, _vector2Buffer, Quaternion.identity, _dronesTransform);
                
                _activeDronesList.Add(new DroneController(spawnedDrone));
            }
            else
            {
                RandomPos();
                
                var inactiveDrone = _inactiveDronesList[^1];

                inactiveDrone.DroneView.transform.position = _vector2Buffer;
                
                inactiveDrone.DroneView.gameObject.SetActive(true);
                
                _activeDronesList.Add(inactiveDrone);
                _inactiveDronesList.Remove(inactiveDrone);
            }
        }
        
        public void DeleteDrone()
        {
            if (_activeDronesList.Count != 0)
            {
                var asteroidToDelete = _activeDronesList[0];
                
                asteroidToDelete.DroneView.gameObject.SetActive(false);
                _inactiveDronesList.Add(asteroidToDelete);
                _activeDronesList.Remove(asteroidToDelete);
            }
        }
        
        public void ClearPool()
        {
            if (_activeDronesList.Count != 0)
            {
                foreach (var asteroid in _activeDronesList)
                {
                    asteroid.Dispose();
                }
                
                _activeDronesList.Clear();
            }

            if (_inactiveDronesList.Count != 0)
            {
                foreach (var asteroid in _inactiveDronesList)
                {
                    asteroid.Dispose();
                }
                
                _inactiveDronesList.Clear();
            }
        }
        
        private void RandomPos()
        {
            _vector2Buffer.x = Random.Range(_leftUpperCornerOfLevel.x, _rightDownCornerOfLevel.x);
            _vector2Buffer.y = Random.Range(_leftUpperCornerOfLevel.y, _rightDownCornerOfLevel.y);
        }
    }
}