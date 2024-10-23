using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMovementEnabled = true;

    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (isMovementEnabled)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(horizontal * 3, vertical * 3);

            // Flip player left or right
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        isMovementEnabled = isEnabled;
    }
}
