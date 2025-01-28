using UnityEngine;
using UnityEngine.SceneManagement; // Para gerenciar cenas

public class MenuController : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Nome;

    // Método para iniciar o jogo (carregar uma cena específica)
    public void StartGame()
    {
        SceneManager.LoadScene("NomeDaCenaDoJogo");
    }

    // Método para fechar o jogo
    public void QuitGame()
    {
        Debug.Log("Fechando o jogo..."); // Mensagem de debug

        // Fecha o jogo (funciona em builds)
        Application.Quit();

        // No Editor, encerra o modo de play
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
}
