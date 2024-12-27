using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas
using UnityEngine.UI; // Necessário para interagir com os botões

public class MenuController : MonoBehaviour
{

    // Start é chamado uma vez antes da primeira execução de Update
    void Start()
    {

    }

    // Função para iniciar uma cena (substitua "NomeDaCena" pelo nome real da cena)
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
    // Função para fechar o jogo
    public void FecharJogo()
    {
        // Fecha o aplicativo (no editor, isso vai parar o jogo)
        Application.Quit();

        // Para o Unity Editor (não é necessário no build final)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
