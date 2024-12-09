using UnityEngine;

public class Move_Protagonista : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float velocidade_correndo = 8f;
    [SerializeField] private float velocidade_esquivando = 10f;

    private Rigidbody2D rig;

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

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        velocidade_inicial = velocidade;
    }

    void Update()
    {
        // Capturar entrada do teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Criar vetor de movimento no plano XZ
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
        rig.MovePosition(rig.position + _direcao * velocidade * Time.fixedDeltaTime);
    }
    private void correndo()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidade = velocidade_correndo;
        }
        if ((Input.GetKeyUp(KeyCode.LeftShift)))
        {
            velocidade = velocidade_inicial;
        }
    }

    void OnRolando()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolando = true;
        }else if (Input.GetMouseButtonUp(1)) 
        { 
            _isRolando = false; 
        }
    }

    #endregion
}
