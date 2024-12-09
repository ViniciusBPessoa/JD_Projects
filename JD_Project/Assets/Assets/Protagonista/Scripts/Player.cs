using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float velocidade_correndo = 8f;
    [SerializeField] private float velocidade_esquivando = 10f;

    [SerializeField] private int _vida;

    private Rigidbody2D rig;
    private Animator animator;

    private float velocidade_inicial;
    private Vector2 _direcao;
    private bool _isRolando;

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

    public int vida
    {
        get { return _vida; }
        set { _vida = value; }
    }

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
        OnRolando();
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

    private void OnRolando()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("esquiva");
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
}
