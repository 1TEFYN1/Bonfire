using UnityEngine;

public class ArrowBonfireController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _bonfire;

    public float circleRadius = 2f;
    public float rotationSpeed = 50f;


    private void FixedUpdate()
    {
        Vector3 directionToCampfire = _bonfire.position - _player.position;

        Vector3 directionToArrow = _bonfire.position - transform.position;

        Vector3 cross = Vector3.Cross(directionToArrow.normalized, directionToCampfire.normalized);
        float rotationDirection = Mathf.Sign(Vector3.Dot(cross, Vector3.up));

        transform.rotation = Quaternion.LookRotation(directionToCampfire.normalized);
    
        float angleRotation = Time.deltaTime * rotationSpeed * rotationDirection;
        transform.RotateAround(_player.position, Vector3.up, angleRotation);
        transform.position = _player.position + transform.forward * circleRadius;
        transform.Rotate(90f, 0f, 0f, Space.Self);
    }
}
