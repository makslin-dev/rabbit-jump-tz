using UnityEngine;

namespace Assets.Scripts.Core.Camera
{
    public class CameraFollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        }
    }
}