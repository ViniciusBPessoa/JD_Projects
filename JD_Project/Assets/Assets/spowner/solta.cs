using UnityEngine;

public class Solta : MonoBehaviour
{
    public GameObject prefab; // Variável pública para atribuir o prefab via Inspetor
    public Transform spawnPoint; // Local onde o prefab será instanciado

    // Start é chamado antes da primeira execução de Update
    void Start()
    {
        // Opcional: Instanciar o prefab logo ao iniciar
        if (prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Instancia o prefab quando a tecla espaço for pressionada
        if (Input.GetKeyDown(KeyCode.L) && prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
