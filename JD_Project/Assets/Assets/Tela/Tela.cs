using UnityEngine;
using UnityEngine.SceneManagement;

public class Tela : MonoBehaviour
{
    [SerializeField] private GameObject painelPausa; // Refer�ncia ao painel de pausa no Canvas
    private bool isPausado = false; // Vari�vel para controlar se o jogo est� pausado

    // Start � chamado uma vez antes da primeira execu��o de Update
    void Start()
    {
        // Inicialmente, o painel de pausa deve estar desativado
        painelPausa.SetActive(false);
    }

    // Update � chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla "P" foi pressionada
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Alterna o estado do jogo entre pausado e n�o pausado
            if (isPausado)
            {
                ContinuarJogo();
            }
            else
            {
                PausarJogo();
            }
        }
    }

    // Fun��o para pausar o jogo
    private void PausarJogo()
    {
        isPausado = true; // Marca o jogo como pausado
        Time.timeScale = 0f; // Para o tempo no jogo
        painelPausa.SetActive(true); // Ativa o painel de pausa
    }

    // Fun��o para continuar o jogo
    public void ContinuarJogo()
    {
        isPausado = false; // Marca o jogo como n�o pausado
        Time.timeScale = 1f; // Retorna o tempo ao normal
        painelPausa.SetActive(false); // Desativa o painel de pausa
    }
    public void retomarMenu()
    {
        SceneManager.LoadScene("Menu_principal"); // Substitua pelo nome da sua cena
    }
}
