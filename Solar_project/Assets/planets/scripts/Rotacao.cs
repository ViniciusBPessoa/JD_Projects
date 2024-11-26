using UnityEngine;

public class Rotacao : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Eixo de rota��o (padr�o: eixo Y)
    public float rotationSpeed = 50f;        // Velocidade de rota��o (graus por segundo)

    void Update()
    {
        // Realiza a rota��o no espa�o local do objeto pai
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
