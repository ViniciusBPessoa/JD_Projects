using UnityEngine;

public class DisparoDeProjetil : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform pontoDeDisparo;
    public float velocidadeProjetil = 10f;

    public Player player;
    public float dano;
    public float custoMana = 10f; // Quantidade de mana necessária para disparar
    public float tempoDeRecarga = 1f; // Tempo de cooldown entre disparos

    private float proximoDisparo = 0f; // Controle do tempo do próximo disparo

    private void Start()
    {
        dano = player.poder;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botão esquerdo do mouse
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        if (Time.time >= proximoDisparo) // Verifica se o cooldown já passou
        {
            if (player.mana >= custoMana) // Verifica se o jogador tem mana suficiente
            {
                // Reduz a mana do jogador
                player.mana -= custoMana;

                // Calcula a direção do cursor
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direcao = (mousePos - pontoDeDisparo.position).normalized;
                direcao.z = 0; // Garante que o movimento seja no plano 2D

                // Cria o projétil
                GameObject projetil = Instantiate(projetilPrefab, pontoDeDisparo.position, Quaternion.identity);
                projetil.GetComponent<Projetio>().dano = dano;

                // Define a velocidade do projétil
                Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = direcao * velocidadeProjetil;
                }

                // Atualiza o tempo do próximo disparo
                proximoDisparo = Time.time + tempoDeRecarga;
            }
            else
            {
                Debug.Log("Mana insuficiente para disparar!");
            }
        }
        else
        {
            Debug.Log("Habilidade em recarga!");
        }
    }
}
