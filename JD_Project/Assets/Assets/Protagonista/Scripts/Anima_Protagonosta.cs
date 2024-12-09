using UnityEngine;

public class Anima_protago : MonoBehaviour
{
    private Move_Protagonista move_protagonista;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move_protagonista = GetComponent<Move_Protagonista>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movemento();
    }

    private void movemento()
    {
        if (move_protagonista.direcao.sqrMagnitude > 0)
        {
            if (move_protagonista.rolando)
            {
                animator.SetTrigger("esquiva");
            }
            else
            {
                animator.SetInteger("transicao", 1);
            }
            
        }
        else
        {
            animator.SetInteger("transicao", 0);
        }

        if (move_protagonista.direcao.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

    }



}
