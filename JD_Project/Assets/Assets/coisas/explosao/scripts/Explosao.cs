using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar/recarregar cenas

public class Explosao : MonoBehaviour
{
    public BoxCollider2D colider;
    public float dano;

    void Start()
    {
        colider = GetComponent<BoxCollider2D>();
    }

    public void auto_destruir()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player joagdor = other.GetComponent<Player>();
            joagdor.ReceberDano(dano);
        }
        if (other.CompareTag("Inimigo"))
        {
            stats status = other.GetComponent<stats>();
            status.ReceberDano(dano);
        }
    }

    private void RecarregarCena()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
}
