using UnityEngine;
using UnityEngine.AI;

public class Esqueleto : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ControleAnimacao con_animacao;

    [SerializeField] private float distancia_ativa;
    [SerializeField] private bool perseguindo = false;

    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < distancia_ativa)
        {
            con_animacao.PlayAnimation(0);
            perseguindo = true;
        }
        else { perseguindo = false; }

        if (perseguindo)
        {
            agent.SetDestination(player.transform.position);
            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                con_animacao.PlayAnimation(2);
            }
            else
            {
                con_animacao.PlayAnimation(1);
            }

            float posX = player.transform.position.x - transform.position.x;
            if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }

    }


}
