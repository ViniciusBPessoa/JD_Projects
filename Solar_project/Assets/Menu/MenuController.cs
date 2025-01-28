using UnityEngine;
using UnityEngine.SceneManagement; // Para gerenciar cenas

public class MenuController : MonoBehaviour
{

    public GameObject toActivate;
    public GameObject toDeactivate;

    // M�todo para iniciar o jogo (carregar uma cena espec�fica)
    public void StartGame()
    {
        SceneManager.LoadScene("NomeDaCenaDoJogo");
    }

    // M�todo para fechar o jogo
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

    // M�todo para ativar um GameObject e desativar outro
    public void trocaMenu()
    {
        toActivate.SetActive(true);        
        toDeactivate.SetActive(false);
    }
    public void trocaMenuInverso()
    {
        toActivate.SetActive(false);
        toDeactivate.SetActive(true);
    }
}
