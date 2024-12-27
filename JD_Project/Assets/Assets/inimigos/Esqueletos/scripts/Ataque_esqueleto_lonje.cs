using UnityEngine;

public class Ataque_esqueleto_lonje : MonoBehaviour
{
    [SerializeField] private GameObject projetilPrefab; // Prefab do projetil a ser instanciado.
    [SerializeField] private Transform spawnPoint; // Ponto de origem do projetil (ex: mão ou arco).
    [SerializeField] private Transform alvo; // Alvo para o qual o projetil será disparado.
    [SerializeField] private float velocidadeProjetil = 10f; // Velocidade do projetil.

    public float dano;
    public stats stats;

    private void Start()
    {
        // Encontra o objeto com a tag "Player" e armazena sua posição no alvo
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            alvo = player.transform; // Atribui a posição do jogador ao alvo
        }
        else
        {
            Debug.LogError("Nenhum objeto com a tag 'Player' foi encontrado!");
        }
    }

    void Update()
    {
        // Atualiza o dano baseado no poder do inimigo.
        if (stats != null)
        {
            dano = stats.poder;
        }
    }

    public void Atirar()
    {
        if (projetilPrefab != null && spawnPoint != null && alvo != null)
        {
            // Instancia o projetil no ponto de origem.
            GameObject projetil = Instantiate(projetilPrefab, spawnPoint.position, Quaternion.identity);
            projetil.GetComponent<Bala_inimigo>().dano = dano;

            // Calcula a direção do alvo.
            Vector2 direcao = (alvo.position - spawnPoint.position).normalized;

            // Aplica velocidade ao projetil.
            Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direcao * velocidadeProjetil;
            }

            // Opcional: Rotaciona o projetil para olhar na direção do alvo.
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            projetil.transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
        else
        {
            Debug.LogError("Faltando referências: verifique o prefab, o spawnPoint e o alvo.");
        }
    }
}
