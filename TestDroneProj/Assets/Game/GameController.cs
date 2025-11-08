using Asteroids;
using Drone;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private DroneBaseView redDroneBaseView;
        [SerializeField] private DroneBaseView blueDroneBaseView;

        [SerializeField] private UIPointsCounter uiPointsCounter;
        
        private int _redFractionPoints;
        private int _blueFractionPoints;

        private DronePool _redDronePool;
        private DronePool _blueDronePool;
        
        private AsteroidController _asteroidController;

        private void Start()
        {
            _redDronePool = new DronePool();
            _blueDronePool = new DronePool();
            
            _asteroidController = new AsteroidController();
            
            uiPointsCounter.SetUI(ref redDroneBaseView.OnAsteroidGetEvent, ref blueDroneBaseView.OnAsteroidGetEvent);
        }
    }
}