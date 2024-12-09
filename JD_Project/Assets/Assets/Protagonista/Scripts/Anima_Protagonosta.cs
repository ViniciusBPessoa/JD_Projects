using UnityEngine;

public class Anima_protago : MonoBehaviour
{
    private Player player;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movemento();
    }

    private void movemento()
    {
        // Verifica se h� movimento
        if (player.direcao.sqrMagnitude > 0)
        {
            // Verifica se est� rolando e ajusta a anima��o
            if (player.rolando)
            {
                animator.SetTrigger("esquiva");
            }
            else
            {
                animator.SetInteger("transicao", 1);
            }

            // Ajusta a rota��o com base na dire��o do movimento
            if (player.direcao.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (player.direcao.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        else
        {
            // Define a anima��o como parada
            animator.SetInteger("transicao", 0);
        }
    }


}
