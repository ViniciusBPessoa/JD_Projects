﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float velocidade_correndo = 8f;
    [SerializeField] private float velocidade_esquivando = 10f;

    [SerializeField] private float _vida;

    private Rigidbody2D rig;
    private Animator animator;

    private float velocidade_inicial;
    private Vector2 _direcao;

    private bool _isRolando;
    private bool _isDano;



    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        velocidade_inicial = velocidade;
    }

    void Update()
    {
        // Capturar entrada do teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _direcao = new Vector2(horizontal, vertical);

        correndo();
        Rolar();
    }

    private void FixedUpdate()
    {
        Movimento();
    }

    #region Movimento

    private void Movimento()
    {
        // Ajusta a velocidade dependendo do estado de rolamento
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Roll"))
        {
            rig.MovePosition(rig.position + _direcao * velocidade_esquivando * Time.fixedDeltaTime);
        }
        else
        {
            rig.MovePosition(rig.position + _direcao * velocidade * Time.fixedDeltaTime);
        }
    }

    private void correndo()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidade = velocidade_correndo;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidade = velocidade_inicial;
        }
    }
    private void Rolar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rolando = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rolando = false;
        }
    }

    public void Velocidade_rolamento_Up()
    {
        velocidade = velocidade_esquivando;
    }
    public void Velocidade_rolamento_Down()
    {
        velocidade = velocidade_inicial;
    }

    #endregion

    #region Dano e Morte

    public void ReceberDano(float dano)
    {
        if (_isRolando) return; // Se o personagem estiver rolando, ele não leva dano
        if (_isDano) return;


        float dano_final = vida - dano;
        if (dano_final > 0)
        {
            vida -= dano;
            _isDano = true;
        }else if (dano_final < 0)
        {
            vida = 0;
            _isDano = false;
        }
    }

    public void Retomar()
    {
        _isDano = false;
    }

    private void Morrer()
    {
        Debug.Log("O jogador morreu!");
        animator.SetTrigger("morte"); // Animação de morte
        // Aqui você pode adicionar lógica para reiniciar o nível ou exibir um menu
    }

    public void Curar(int quantidade)
    {
        vida += quantidade;
    }

    #endregion

    public Vector2 direcao
    {
        get { return _direcao; }
        set { _direcao = value; }
    }
    public bool rolando
    {
        get { return _isRolando; }
        set { _isRolando = value; }
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
