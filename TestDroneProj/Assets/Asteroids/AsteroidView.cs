using UnityEngine;

namespace Asteroids
{
    public class AsteroidView : MonoBehaviour
    {
        public bool IsAvailable => _isAvailable;
        
        private bool _isAvailable;

        public void SetAvailable(bool isAvailable)
        {
            _isAvailable = isAvailable;
        }
    }
}