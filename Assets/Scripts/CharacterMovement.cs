using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
