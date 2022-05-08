using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;

    private void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        Vector3 news= new Vector3(newPosition.x, 0, newPosition.z);
        transform.position = Vector3.Slerp(transform.position, news, FollowSpeed * Time.deltaTime);
    }
}