using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMovementEnabled = true;
    private Animator anim;
    private Vector3 originalScale;
    private Rigidbody2D rb;

    //// Variavel Fernando
    //private GameManager gameManager;

    //// Variaveis Guilherme
    //private float speed = 3f;
    //private Camera mainCamera;


    void Start()
    {
        // Inicializa as variaveis
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Congela a rotação
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        //// Salva a escala original
        //mainCamera = Camera.main;
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

    ////Metodos SetMovementEnabled criado para o Fernando
    //public void SetMovementEnabled(bool isEnabled)
    //{
    //    isMovementEnabled = isEnabled;
    //}

    ////Metodo HandleItemCollision criado para o Fernando
    //public void HandleItemCollision(GameObject item)
    //{
    //    gameManager.ControlCollision(item);
    //    Debug.Log("Colidiu com o item: " + item.name);
    //}


    ////Metodo IncreaseSpeed criado para o Guilerme
    //public void IncreaseSpeed(float amount)
    //{
    //    speed += amount;
    //}

    ////Metodo IncreaseVision criado para o Guilerme
    //public void IncreaseVision(float amount)
    //{
    //    if (mainCamera != null)
    //    {
    //        mainCamera.orthographicSize += amount;
    //    }
    //}
}
