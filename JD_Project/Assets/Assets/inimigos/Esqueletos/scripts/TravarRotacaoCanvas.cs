using UnityEngine;

public class TravarRotacaoCanvas : MonoBehaviour
{
    private Quaternion rotacaoInicial;

    void Start()
    {
        // Salva a rota��o inicial
        rotacaoInicial = transform.rotation;
    }

    void LateUpdate()
    {
        // Mant�m a rota��o do RectTransform fixa
        transform.rotation = rotacaoInicial;
    }
}
