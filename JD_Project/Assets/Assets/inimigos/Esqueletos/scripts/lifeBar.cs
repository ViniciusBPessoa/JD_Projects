using UnityEngine;
using UnityEngine.UI;

public class lifeBar : MonoBehaviour
{

    public stats stats;
    public Image imagem;

    public float vidaTotal;
    public float vidaAtual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaTotal = stats.vidaMaxima;
        vidaAtual = vidaTotal;
    }

    // Update is called once per frame

    public void AlterarLifeBar()
    {
        vidaTotal = stats.vidaMaxima;
        vidaAtual = stats.vida;

        imagem.fillAmount = vidaAtual / vidaTotal;
    }
}
