using UnityEngine;

public class Rotacao : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Eixo de rotação (padrão: eixo Y)
    public float rotationSpeed = 50f;        // Velocidade de rotação (graus por segundo)

    void Update()
    {
        // Realiza a rotação no espaço local do objeto pai
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
