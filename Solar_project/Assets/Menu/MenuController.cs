using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Biblioteca necessária para TextMeshPro

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Nome;
    public TMP_InputField playerNameInput; // Campo de entrada para o nome do jogador (TMP)

    // Método para iniciar o jogo
    public void StartGame()
    {
        SceneManager.LoadScene("NomeDaCenaDoJogo");
    }

    // Método para fechar o jogo
    public void QuitGame()
    {
        Debug.Log("Fechando o jogo...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Método para ativar um GameObject e desativar outro
    public void trocaMenu()
    {
        Menu.SetActive(false);
        Nome.SetActive(true);
    }

    public void trocaMenuInverso()
    {
        Menu.SetActive(true);
        Nome.SetActive(false);
    }

    // Método para salvar o nome do jogador
    public void SavePlayerName()
    {
        string playerName = playerNameInput.text.Trim(); // Remove espaços extras

        if (string.IsNullOrEmpty(playerName)) // Verifica se o campo está vazio
        {
            Debug.LogWarning("Tentativa de salvar um nome vazio.");
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", playerName); // Salva na memória
            PlayerPrefs.Save(); // Garante que o dado seja salvo
            Debug.Log("Nome salvo: " + playerName);
            SceneManager.LoadScene("Mundo");

        }
    }
}
