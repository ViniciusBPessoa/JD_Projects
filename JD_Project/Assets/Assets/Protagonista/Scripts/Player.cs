﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float velocidade_correndo = 8f;
    [SerializeField] private float velocidade_esquivando = 10f;

    public float maxVida;
    [SerializeField] private float _vida;
    public float maxMana;
    public float mana;
    public float poder;

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

        _vida = maxVida;
        mana = maxMana;
    }

    void Update()
    {
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

    #region Dano, Vida e Mana

    public void ReceberDano(float dano)
    {
        if (_isRolando) return; // Se o personagem estiver rolando, ele não leva dano
        if (_isDano) return;

        _vida -= dano;
        _vida = Mathf.Max(_vida, 0); // Garante que a vida não fique abaixo de 0
        _isDano = true;

        if (_vida <= 0)
        {
            Morrer();
        }
    }

    public void ReceberVida(float quantidade)
    {
        _vida += quantidade;
        _vida = Mathf.Min(_vida, maxVida); // Garante que a vida não exceda o máximo
    }

    public void ReceberMana(float quantidade)
    {
        mana += quantidade;
        mana = Mathf.Min(mana, maxMana); // Garante que a mana não exceda o máximo
    }

    public void Retomar()
    {
        _isDano = false;
    }

    private void Morrer()
    {
        SceneManager.LoadScene("Cena_morte"); // Substitua pelo nome da sua cena
    }

    public void Curar(int quantidade)
    {
        ReceberVida(quantidade);
    }

    #endregion

    #region Propriedades

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
        set { _vida = Mathf.Clamp(value, 0, maxVida); } // Limita o valor entre 0 e maxVida
    }
    public bool dano
    {
        get { return _isDano; }
        set { _isDano = value; }
    }

    #endregion
}
