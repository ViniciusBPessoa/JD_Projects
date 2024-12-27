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
        // Começa a Coroutine que irá controlar o spawn dos objetos
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

            // Espera o tempo definido antes de realizar o próximo spawn
            yield return new WaitForSeconds(intervalo);

            // Aumenta a quantidade de objetos a serem spawnados
            quantidadeAtual += quantidadeIncrementada;
        }
    }

    private void SpawnObjectInArea()
    {
        // Verifique se a lista de objetos para spawnar não está vazia
        if (objetosParaSpawnar.Length > 0)
        {
            // Seleciona um prefab aleatório da lista
            int randomIndex = Random.Range(0, objetosParaSpawnar.Length);
            GameObject objetoAleatorio = objetosParaSpawnar[randomIndex];

            // Gera uma posição aleatória dentro da área do colisor
            Vector3 spawnPosition = GetRandomPointInCollider();

            // Instancia o objeto escolhido aleatoriamente
            Instantiate(objetoAleatorio, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Lista de objetos para spawnar está vazia!");
        }
    }

    private Vector3 GetRandomPointInCollider()
    {
        // Obtenha o colisor que está no spawner
        Collider2D collider = GetComponent<Collider2D>();

        // Verifique se o colisor existe
        if (collider != null)
        {
            // Obtém um ponto aleatório dentro da área do colisor
            Vector2 randomPoint = new Vector2(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y)
            );

            return randomPoint;
        }
        else
        {
            // Caso não exista um colisor, retorne a posição atual (fallback)
            return transform.position;
        }
    }
}
