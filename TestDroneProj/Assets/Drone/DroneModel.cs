using UnityEngine;

namespace Drone
{
    [CreateAssetMenu(menuName = "DroneModel")]
    public class DroneModel : ScriptableObject
    {
        [SerializeField] private float droneSpeed;
    }
}