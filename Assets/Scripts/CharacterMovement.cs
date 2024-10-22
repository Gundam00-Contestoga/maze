using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Input.GetAxis("Horizontal")*3, Input.GetAxis("Vertical")*3);
    }
}
