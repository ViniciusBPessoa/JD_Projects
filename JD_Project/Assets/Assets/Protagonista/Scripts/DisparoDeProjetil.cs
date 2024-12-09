using UnityEngine;

public class DisparoDeProjetil : MonoBehaviour
{
    public GameObject projetilPrefab; // Prefab do proj�til
    public Transform pontoDeDisparo; // Ponto de onde os proj�teis ser�o disparados
    public float velocidadeProjetil = 10f; // Velocidade do proj�til

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Bot�o esquerdo do mouse
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        // Calcula a dire��o do cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direcao = (mousePos - pontoDeDisparo.position).normalized;
        direcao.z = 0; // Garante que o movimento seja no plano 2D

        // Cria o proj�til
        GameObject projetil = Instantiate(projetilPrefab, pontoDeDisparo.position, Quaternion.identity);

        // Define a velocidade do proj�til
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direcao * velocidadeProjetil;
        }
    }
}
