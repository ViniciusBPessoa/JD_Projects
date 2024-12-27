using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] objetosParaSpawnar;    // Lista de prefabs de objetos a serem spawnados
    public float intervalo = 5f;                // Intervalo entre os spawns
    public int quantidadeInicial = 1;           // Quantidade inicial de objetos
    public int quantidadeIncrementada = 1;      // A quantidade de objetos a mais a ser spawnada a cada ciclo

    private void Start()
    {
        // Come�a a Coroutine que ir� controlar o spawn dos objetos
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        int quantidadeAtual = quantidadeInicial;

        while (true)
        {
            // Spawn dos objetos no interior do colisor
            for (int i = 0; i < quantidadeAtual; i++)
            {
                SpawnObjectInArea();
            }

            // Espera o tempo definido antes de realizar o pr�ximo spawn
            yield return new WaitForSeconds(intervalo);

            // Aumenta a quantidade de objetos a serem spawnados
            quantidadeAtual += quantidadeIncrementada;
        }
    }

    private void SpawnObjectInArea()
    {
        // Verifique se a lista de objetos para spawnar n�o est� vazia
        if (objetosParaSpawnar.Length > 0)
        {
            // Seleciona um prefab aleat�rio da lista
            int randomIndex = Random.Range(0, objetosParaSpawnar.Length);
            GameObject objetoAleatorio = objetosParaSpawnar[randomIndex];

            // Gera uma posi��o aleat�ria dentro da �rea do colisor
            Vector3 spawnPosition = GetRandomPointInCollider();

            // Instancia o objeto escolhido aleatoriamente
            Instantiate(objetoAleatorio, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Lista de objetos para spawnar est� vazia!");
        }
    }

    private Vector3 GetRandomPointInCollider()
    {
        // Obtenha o colisor que est� no spawner
        Collider2D collider = GetComponent<Collider2D>();

        // Verifique se o colisor existe
        if (collider != null)
        {
            // Obt�m um ponto aleat�rio dentro da �rea do colisor
            Vector2 randomPoint = new Vector2(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y)
            );

            return randomPoint;
        }
        else
        {
            // Caso n�o exista um colisor, retorne a posi��o atual (fallback)
            return transform.position;
        }
    }
}
