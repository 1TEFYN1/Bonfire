using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _transformFollowed;
    [SerializeField] private float y, z;
    private void LateUpdate()
    {
        transform.position = new Vector3(_transformFollowed.position.x, _transformFollowed.position.y + y, _transformFollowed.position.z - z);
    }
}
