using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ControleAnimacao : MonoBehaviour
{
    public Animator animator;
    public stats stats;

    public int estado_animacao;
    public bool morto;


    void Start()
    {
        animator = GetComponent<Animator>();
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
        stats.altoDestruicao();
    }

}
