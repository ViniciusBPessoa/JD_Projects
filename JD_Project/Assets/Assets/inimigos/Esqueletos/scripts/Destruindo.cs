using UnityEngine;

public class Destruindo : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosParaSpawn; // Lista de prefabs para spawn
    [SerializeField] private Transform pontoDeSpawn; // Ponto onde o novo GameObject será gerado

    private void OnDestroy()
    {
        // Verifica se a lista de objetos não está vazia
        if (objetosParaSpawn.Length > 0)
        {
            // Gera um índice aleatório na lista de prefabs
            int indiceAleatorio = Random.Range(0, objetosParaSpawn.Length);

            // Spawna o objeto selecionado no ponto de spawn
            Instantiate(objetosParaSpawn[indiceAleatorio], pontoDeSpawn.position, Quaternion.identity);
        }
    }
}
