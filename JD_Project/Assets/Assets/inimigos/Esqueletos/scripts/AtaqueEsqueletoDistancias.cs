using UnityEngine;

public class AtaqueEsqueletoDistancias : MonoBehaviour
{
    public GameObject explosao; // Prefab da explosão
    public Transform ExploPos; // Posição onde a explosão será criada

    void Start()
    {
        // Inicializações, se necessário
    }

    void Update()
    {
        // Lógica de atualização, se necessário
    }

    public void criaExplosao()
    {
        // Cria a explosão na posição e rotação do Transform ExploPos
        Instantiate(explosao, ExploPos.position, ExploPos.rotation);
    }
}
