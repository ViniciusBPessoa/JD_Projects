using UnityEngine;
using UnityEngine.SceneManagement;

public class Tela : MonoBehaviour
{
    [SerializeField] private GameObject painelPausa; // Referência ao painel de pausa no Canvas
    private bool isPausado = false; // Variável para controlar se o jogo está pausado

    // Start é chamado uma vez antes da primeira execução de Update
    void Start()
    {
        // Inicialmente, o painel de pausa deve estar desativado
        painelPausa.SetActive(false);
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla "P" foi pressionada
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Alterna o estado do jogo entre pausado e não pausado
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

    // Função para pausar o jogo
    private void PausarJogo()
    {
        isPausado = true; // Marca o jogo como pausado
        Time.timeScale = 0f; // Para o tempo no jogo
        painelPausa.SetActive(true); // Ativa o painel de pausa
    }

    // Função para continuar o jogo
    public void ContinuarJogo()
    {
        isPausado = false; // Marca o jogo como não pausado
        Time.timeScale = 1f; // Retorna o tempo ao normal
        painelPausa.SetActive(false); // Desativa o painel de pausa
    }
    public void retomarMenu()
    {
        SceneManager.LoadScene("Menu_principal"); // Substitua pelo nome da sua cena
    }
}
