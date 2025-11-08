using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class AsteroidPool
    {
        private Vector2 _leftUpperCornerOfLevel = new Vector2(-79, 44);
        private Vector2 _rightDownCornerOfLevel = new Vector2(79, -44);

        private Vector2 _vector2Buffer = new Vector2();
        
        private List<AsteroidView> _inactiveAsteroidsList = new List<AsteroidView>();
        private Dictionary<int,AsteroidView> _activeAsteroidsDict = new Dictionary<int, AsteroidView>();

        private AsteroidView _asteroidViewPrefab = Resources.Load<AsteroidView>("AsteroidView");

        private Transform _asteroidsTransform;

        public AsteroidPool()
        {
            _asteroidsTransform = Object.Instantiate(new GameObject("Asteroids"), Vector3.zero,Quaternion.identity).transform;
        }

        public void CreateAsteroid()
        {
            if (_inactiveAsteroidsList.Count == 0)
            {
                RandomPos();
                
                var spawnedAsteroid = Object.Instantiate(_asteroidViewPrefab, _vector2Buffer, Quaternion.identity, _asteroidsTransform);
                spawnedAsteroid.SetAvailable(true);
                
                _activeAsteroidsDict.Add(spawnedAsteroid.GetHashCode(),spawnedAsteroid);
            }
            else
            {
                RandomPos();
                
                var inactiveAsteroid = _inactiveAsteroidsList[^1];

                inactiveAsteroid.transform.position = _vector2Buffer;
                
                inactiveAsteroid.gameObject.SetActive(true);
                inactiveAsteroid.SetAvailable(true);
                _activeAsteroidsDict.Add(inactiveAsteroid.GetHashCode(),inactiveAsteroid);
                _inactiveAsteroidsList.Remove(inactiveAsteroid);
            }
        }
        
        public void RemoveAsteroid(int hashCode)
        {
            if (_activeAsteroidsDict.ContainsKey(hashCode))
            {
                var asteroidToDelete = _activeAsteroidsDict[hashCode];
                
                asteroidToDelete.gameObject.SetActive(false);
                _inactiveAsteroidsList.Add(asteroidToDelete);
                _activeAsteroidsDict.Remove(hashCode);
            }
        }
        
        public void ClearPool()
        {
            if (_activeAsteroidsDict.Count != 0)
            {
                foreach (var asteroid in _activeAsteroidsDict.Values)
                {
                    Object.Destroy(asteroid);
                }
                
                _activeAsteroidsDict.Clear();
            }

            if (_inactiveAsteroidsList.Count != 0)
            {
                foreach (var asteroid in _inactiveAsteroidsList)
                {
                    Object.Destroy(asteroid);
                }
                
                _inactiveAsteroidsList.Clear();
            }
        }

        private void RandomPos()
        {
            _vector2Buffer.x = Random.Range(_leftUpperCornerOfLevel.x, _rightDownCornerOfLevel.x);
            _vector2Buffer.y = Random.Range(_leftUpperCornerOfLevel.y, _rightDownCornerOfLevel.y);
        }
    }
}