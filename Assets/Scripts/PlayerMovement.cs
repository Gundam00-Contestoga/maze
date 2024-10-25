using UnityEngine;
using UnityEngine.VFX;

public class PlayerMovement : MonoBehaviour
{
    private bool isMovementEnabled = true;
    private Animator anim;
    private Vector3 originalScale;
    private Rigidbody2D rb;
    public VisualEffect vfxRenderer;
    public Vector3 colliderOffset;

    // Variavel Fernando
    private GameManager gameManager;

    // Variaveis Guilherme
    public float speed = 3f;
    private Camera mainCamera;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        originalScale = transform.localScale;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (isMovementEnabled)
        {
            Vector2 movement = new Vector2(horizontal * speed, vertical * speed); // Multiplicado pela vari�vel 'speed'
            Vector2 newPosition = rb.position + movement * Time.deltaTime;

            rb.MovePosition(newPosition);

            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (horizontal > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }

            anim.SetBool("run", horizontal != 0 || vertical != 0);

            Vector3 colliderPosition = transform.position + colliderOffset;
            vfxRenderer.SetVector3("ColliderPos", colliderPosition);
        }
    }

    //Metodos SetMovementEnabled criado para o Fernando
     public void SetMovementEnabled(bool isEnabled)
     {
         isMovementEnabled = isEnabled;
     }

    //// Metodo HandleItemCollision criado para o Fernando
    //public void HandleItemCollision(GameObject item)
    //{
    //    gameManager.ControlCollision(item);
    //    Debug.Log("Colidiu com o item: " + item.name);
    //}

    // Metodo IncreaseSpeed criado para o Guilherme
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    // Metodo IncreaseVision criado para o Guilherme
    public void IncreaseVision(float amount)
    {
        if (mainCamera != null)
        {
            mainCamera.orthographicSize += amount;
        }
    }


    // Método para detectar colisões
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SpriteRenderer>() != null)
        {
            Debug.Log("Colidiu com um sprite: " + collision.gameObject.name);

            // Verifica a tag da parede
            if (collision.gameObject.CompareTag("unbreakable"))
            {
                Debug.Log("A parede é inquebrável.");
            }
            else if (collision.gameObject.CompareTag("breakable"))
            {
                Debug.Log("A parede é quebrável.");
            }
        }
    }
}
