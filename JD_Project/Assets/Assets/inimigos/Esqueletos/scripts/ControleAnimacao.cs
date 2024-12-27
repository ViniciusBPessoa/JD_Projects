using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ControleAnimacao : MonoBehaviour
{
    public Animator animator;
    public stats stats;

    public int estado_animacao;
    public bool morto;

    [SerializeField] private GameObject[] objetosParaSpawn;

    void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponentInParent<stats>(); // Obtém o componente stats do objeto pai
    }

    // Update is called once per frame
    void Update()
    {
        estado_animacao = stats.estado_animacao;
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        animator.SetInteger("Estado", estado_animacao);
    }
    public void StopDano() 
    {
        stats.dano = false;
        stats.estado_animacao = 0;
    }

    public void altoDestruicao()
    {
        if (objetosParaSpawn.Length > 0)
        {
            // Gera um índice aleatório na lista de prefabs
            int indiceAleatorio = Random.Range(0, objetosParaSpawn.Length);

            // Spawna o objeto selecionado no ponto de spawn
            Instantiate(objetosParaSpawn[indiceAleatorio], this.transform.position, Quaternion.identity);
        }
        stats.altoDestruicao();
    }

}
