using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar/recarregar cenas

public class Explosao : MonoBehaviour
{
    public BoxCollider2D colider;

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
            Debug.Log("Jogador atingido! Recarregando cena...");
            RecarregarCena();
        }
    }

    private void RecarregarCena()
    {
        // Recarrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
