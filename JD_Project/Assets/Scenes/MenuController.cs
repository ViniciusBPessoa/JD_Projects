using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para carregar cenas
using UnityEngine.UI; // Necess�rio para interagir com os bot�es

public class MenuController : MonoBehaviour
{

    // Start � chamado uma vez antes da primeira execu��o de Update
    void Start()
    {

    }

    // Fun��o para iniciar uma cena (substitua "NomeDaCena" pelo nome real da cena)
    public void IniciarCena()
    {
        // Troca para a cena especificada
        SceneManager.LoadScene("SampleScene"); // Substitua pelo nome da sua cena
    }
    public void IniciarTest()
    {
        // Troca para a cena especificada
        SceneManager.LoadScene("Cena_test"); // Substitua pelo nome da sua cena
    }
    // Fun��o para fechar o jogo
    public void FecharJogo()
    {
        // Fecha o aplicativo (no editor, isso vai parar o jogo)
        Application.Quit();

        // Para o Unity Editor (n�o � necess�rio no build final)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
