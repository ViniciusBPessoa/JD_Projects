using System;
using UnityEngine;

public class camera_controler : MonoBehaviour
{
    public Transform nave; // Refer�ncia � nave
    public Vector3 offset = new Vector3(0, 5, -10); // Posi��o da c�mera em rela��o � nave
    public float suavidade = 2f; // Suavidade ao seguir

    void LateUpdate()
    {
        if (nave != null)
        {
            // Calcula a nova posi��o da c�mera
            Vector3 novaPosicao = nave.position + nave.TransformDirection(offset);
            transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.deltaTime * suavidade);

            // Faz a c�mera olhar para a nave
            transform.LookAt(nave);
        }
    }
}