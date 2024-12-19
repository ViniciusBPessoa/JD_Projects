using UnityEngine;

public class Anima_protago : MonoBehaviour
{
    private Player player;
    private Animator animator;

    public bool rolar;
    public bool tomarDano;


    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movemento();
        rolar = player.rolando;
        tomarDano = player.dano;
    }

    private void movemento()
    {
        if (tomarDano)
        {
            animator.SetTrigger("dano");
        }
        // Verifica se há movimento
        if (player.direcao.sqrMagnitude > 0)
        {
            animator.SetInteger("transicao", 1);

            // Ajusta a rotação com base na direção do movimento
            if (player.direcao.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (player.direcao.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }

            // Ativa o trigger de esquiva se variavel for verdadeira
            if (rolar)
            {
                animator.SetTrigger("esquiva");
            }
        }
        else
        {
            animator.SetInteger("transicao", 0);
        }
    }
}
