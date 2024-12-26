using UnityEngine;

public class AtaqueEsqueletoDistancias : MonoBehaviour
{
    public GameObject explosao; // Prefab da explos�o
    public Transform ExploPos; // Posi��o onde a explos�o ser� criada

    void Start()
    {
        // Inicializa��es, se necess�rio
    }

    void Update()
    {
        // L�gica de atualiza��o, se necess�rio
    }

    public void criaExplosao()
    {
        // Cria a explos�o na posi��o e rota��o do Transform ExploPos
        Instantiate(explosao, ExploPos.position, ExploPos.rotation);
    }
}
