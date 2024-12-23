using UnityEngine;

public class ControleAnimacao : MonoBehaviour
{
    public Animator animator;
    public stats stats;

    public int estado_animacao;


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

}
