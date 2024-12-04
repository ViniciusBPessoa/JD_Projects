using System;
using UnityEngine;

public class camera_controler : MonoBehaviour
{
    public Transform nave; // Referência à nave
    public Vector3 offset = new Vector3(0, 5, -10); // Posição da câmera em relação à nave
    public float suavidade = 2f; // Suavidade ao seguir

    void LateUpdate()
    {
        if (nave != null)
        {
            // Calcula a nova posição da câmera
            Vector3 novaPosicao = nave.position + nave.TransformDirection(offset);
            transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.deltaTime * suavidade);

            // Faz a câmera olhar para a nave
            transform.LookAt(nave);
        }
    }
}