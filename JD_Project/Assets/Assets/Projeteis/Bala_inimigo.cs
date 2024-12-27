using UnityEngine;

public class Bala_inimigo : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.ReceberDano(dano);
        }
        if (other.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }
    }

}
