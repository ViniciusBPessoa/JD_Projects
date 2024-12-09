using UnityEngine;

public class ControleAnimacao : MonoBehaviour
{
    public Animator animator;

    public GameObject explocao;
    public Transform explo_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(int valor)
    {
        animator.SetInteger("Estado", valor);
    }

    public void cria_explosão()
    {
        Instantiate(explocao, explo_pos.position, explo_pos.rotation);
    }
}
