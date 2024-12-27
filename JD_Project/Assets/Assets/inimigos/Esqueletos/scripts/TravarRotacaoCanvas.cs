using UnityEngine;

public class TravarRotacaoCanvas : MonoBehaviour
{
    private Quaternion rotacaoInicial;

    void Start()
    {
        // Salva a rotação inicial
        rotacaoInicial = transform.rotation;
    }

    void LateUpdate()
    {
        // Mantém a rotação do RectTransform fixa
        transform.rotation = rotacaoInicial;
    }
}
