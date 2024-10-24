using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Determines how quickly the camera follows the target.
    public float FollowSpeed = 2f;

    //The object that the camera will follow.
    public Transform target;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not set for CameraFollow script.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            //Creates a new position for the camera based on the target's position.
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);

            // Vector3.Slerp é usada para interpolar entre dois pontos em um espaço tridimensional 
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}
