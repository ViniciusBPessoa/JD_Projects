using UnityEngine;
using UnityEngine.AI;

public class stats : MonoBehaviour
{

    [SerializeField] private float velocidade;
    [SerializeField] private float _vida;
    [SerializeField] private bool _isDano;

    [SerializeField] private float velocidade_atk;

    [SerializeField] public int estado_animacao;
    [SerializeField] private float distancia_ativa;

    public Player player;

    public  NavMeshAgent agent;
    public bool perseguindo = false;

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
        perseguicao();
    }

    public void ReceberDano(float dano)
    {
        float dano_final = vida - dano;
        if (dano_final > 0)
        {
            vida -= dano;
            _isDano = true;
        }
        else if (dano_final < 0)
        {
            vida = 0;
            _isDano = false;
        }
    }

    public void perseguicao()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < distancia_ativa)
        {
            estado_animacao = 0;
            perseguindo = true;
        }
        else { perseguindo = false; }

        if (perseguindo)
        {
            agent.SetDestination(player.transform.position);
            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                estado_animacao = 2;
            }
            else
            {
                estado_animacao = 1;
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

    public float vida
    {
        get { return _vida; }
        set { _vida = value; }
    }
    public bool dano
    {
        get { return _isDano; }
        set { _isDano = value; }
    }
}
