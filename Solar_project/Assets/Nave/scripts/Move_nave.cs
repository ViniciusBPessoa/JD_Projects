using UnityEngine;
using TMPro;

public class MoveNave : MonoBehaviour
{
    public float speed = 5f; // Velocidade da nave

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
    }
}
