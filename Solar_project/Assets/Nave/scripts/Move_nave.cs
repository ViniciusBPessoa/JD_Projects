using UnityEngine;

public class MoveNave : MonoBehaviour
{
    public float speed = 5f; // Velocidade da nave
    public float delay = 10f; // Suavidade na rotação
    private CharacterController controller; // Referência ao CharacterController
    public Transform Mycam; // Referência à câmera para seguir a direção
    public bool usarWASD = true; // Define se o controle é por WASD ou setas

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        // Alterna entre WASD ou setas com base em `usarWASD`
        if (usarWASD)
        {
            // Controle WASD
            moveHorizontal = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);
            moveVertical = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0f);
        }
        else
        {
            // Controle Setas
            moveHorizontal = Input.GetKey(KeyCode.LeftArrow) ? -1f : (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f);
            moveVertical = Input.GetKey(KeyCode.UpArrow) ? 1f : (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);
        }

        // Cria o vetor de movimento
        Vector3 movimento = new Vector3(moveHorizontal, 0, moveVertical);
        movimento = Mycam.TransformDirection(movimento);

        // Move o objeto na cena
        controller.Move(movimento * Time.deltaTime * speed);

        // Faz a nave rotacionar suavemente na direção do movimento
        if (movimento.magnitude > 0.1f) // Garante que a nave só rotacione quando estiver se movendo
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movimento),
                Time.deltaTime * delay
            );
        }
    }
}
