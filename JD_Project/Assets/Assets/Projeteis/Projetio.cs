using UnityEngine;

public class Projetio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou tem uma tag específica (opcional)
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }

    }

}
