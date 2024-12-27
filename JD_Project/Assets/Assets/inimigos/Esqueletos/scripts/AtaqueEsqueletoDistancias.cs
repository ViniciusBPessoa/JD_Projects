using UnityEngine;

public class AtaqueEsqueletoDistancias : MonoBehaviour
{
    public GameObject explosao; // Prefab da explosão
    public Transform ExploPos; // Posição onde a explosão será criada

    public stats statos;

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
        GameObject explode =  Instantiate(explosao, ExploPos.position, ExploPos.rotation);
        explode.GetComponent<Explosao>().dano = statos.poder;
    }
}
