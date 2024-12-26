using UnityEngine;

public class Projetio : MonoBehaviour
{
    public float dano;

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
        if (other.CompareTag("Inimigo"))
        {
            stats status = other.GetComponent<stats>();
            status.ReceberDano(dano);
        }
        if (other.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }
    }

}
