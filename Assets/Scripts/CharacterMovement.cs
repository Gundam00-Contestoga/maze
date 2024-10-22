using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool isMovementEnabled = true;

    void Start()
    {
        
    }
   
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Input.GetAxis("Horizontal")*3, Input.GetAxis("Vertical")*3);
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        isMovementEnabled = isEnabled;
    }
}
