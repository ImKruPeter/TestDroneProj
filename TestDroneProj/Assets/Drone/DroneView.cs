using Pathfinding;
using UnityEngine;

namespace Drone
{
    public class DroneView : MonoBehaviour
    {
        public AIDestinationSetter AIDestinationSetter => aiDestinationSetter;
        
        [SerializeField] private AIDestinationSetter aiDestinationSetter;
        
        private Fraction _fraction;

        private bool _isAsteroidIn;
        
        public void SetAsteroidIn(bool isAsteroidIn)
        {
            _isAsteroidIn = isAsteroidIn;
        }

        public bool GetAsteroidInState()
        {
            return _isAsteroidIn;
        }
    }

    enum Fraction
    {
        Red,
        Blue
    }
}