using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MoveNave : MonoBehaviour
{
    public float speed = 5f; // Velocidade da nave
    public camera_controler controlador;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Captura a entrada do jogador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Cria o vetor de movimento
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);


        // Move o objeto na cena
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        var lookx = -Input.GetAxisRaw("Mouse Y");
        var looky = Input.GetAxisRaw("Mouse X");

        controlador.IncrementLookRotation(new Vector2(lookx, looky));

    }

}
