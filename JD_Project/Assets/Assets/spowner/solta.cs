using UnityEngine;

public class Solta : MonoBehaviour
{
    public GameObject prefab; // Vari�vel p�blica para atribuir o prefab via Inspetor
    public Transform spawnPoint; // Local onde o prefab ser� instanciado

    // Start � chamado antes da primeira execu��o de Update
    void Start()
    {
        // Opcional: Instanciar o prefab logo ao iniciar
        if (prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    // Update � chamado uma vez por frame
    void Update()
    {
        // Instancia o prefab quando a tecla espa�o for pressionada
        if (Input.GetKeyDown(KeyCode.L) && prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
