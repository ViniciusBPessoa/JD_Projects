using UnityEngine;

public class Destruindo : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosParaSpawn; // Lista de prefabs para spawn
    [SerializeField] private Transform pontoDeSpawn; // Ponto onde o novo GameObject ser� gerado

    private void OnDestroy()
    {
        // Verifica se a lista de objetos n�o est� vazia
        if (objetosParaSpawn.Length > 0)
        {
            // Gera um �ndice aleat�rio na lista de prefabs
            int indiceAleatorio = Random.Range(0, objetosParaSpawn.Length);

            // Spawna o objeto selecionado no ponto de spawn
            Instantiate(objetosParaSpawn[indiceAleatorio], pontoDeSpawn.position, Quaternion.identity);
        }
    }
}
