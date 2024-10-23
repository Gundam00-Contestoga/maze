using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMovementEnabled = true;
    private Animator anim;
    private Vector3 originalScale;

    void Start()
    {
        anim = GetComponent<Animator>();
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
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }

            //Set animator parameters
            anim.SetBool("run", horizontal != 0 || vertical != 0);
        }
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        isMovementEnabled = isEnabled;
    }
}
