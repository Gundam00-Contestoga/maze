using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMovementEnabled = true;
    private Animator anim;
    private Vector3 originalScale;
    private Rigidbody2D rb;
    //public static GameManager Instance;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // Congela a rotação
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
                transform.localScale = new Vector3(-1.75f, 1.75f, 1);
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(1.75f, 1.75f, 1);
            }

            //Set animator parameters
            anim.SetBool("run", horizontal != 0 || vertical != 0);
        }
    }

    public void SetMovementEnabled(bool isEnabled)
    {
        isMovementEnabled = isEnabled;
    }

    //    void Awake()
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = this;
    //        }
    //        else
    //        {
    //            Destroy(gameObject);
    //        }
    //    }

    //    public void HandleItemCollision(GameObject item)
    //    {
    //        // Lógica para lidar com a colisão do item
    //        Debug.Log("Colidiu com o item: " + item.name);
    //    }
}
