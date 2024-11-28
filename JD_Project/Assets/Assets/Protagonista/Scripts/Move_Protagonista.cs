using UnityEngine;

public class Move_Protagonista : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        Movimento();
    }

    private void Movimento()
    {
        // Capturar entrada do teclado
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou ←/→
        float vertical = Input.GetAxis("Vertical"); // W/S ou ↑/↓

        // Criar vetor de movimento no plano XZ
        Vector3 direcao = new Vector3(horizontal, vertical, 0);

        // Normalizar a direção (opcional para manter velocidade constante)
        if (direcao.magnitude > 1)
        {
            direcao.Normalize();
        }

        // Mover o objeto no plano XZ
        transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
    }
}
