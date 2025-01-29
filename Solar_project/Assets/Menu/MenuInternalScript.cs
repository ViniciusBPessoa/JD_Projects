using UnityEngine;
using TMPro; // Biblioteca para TextMeshPro

public class MenuInternalScript : MonoBehaviour
{
    public TextMeshProUGUI positionText; // Referência ao TMP Text para exibir as posições
    public GameObject playerShip; // Referência ao GameObject da nave
    public GameObject[] planets; // Referências para os GameObjects dos planetas
    public TextMeshProUGUI playerNameText; // Referência ao TMP Text para exibir o nome do jogador
    public TextMeshProUGUI speedText; // Referência ao TMP Text para exibir a velocidade da nave

    private  Rigidbody rb; // Referência ao Rigidbody da nave

    void Start()
    {
        // Obtém o Rigidbody da nave
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        // Atualiza a posição na tela a cada início
        UpdatePositions();
        LoadPlayerName();
    }

    private void Update()
    {
        UpdatePositions();
        UpdateSpeed(); // Atualiza a velocidade a cada frame
    }

    void UpdatePositions()
    {
        // Formata a posição da nave com duas casas decimais
        string formattedShipPosition = "Nave - X: " + playerShip.transform.position.x.ToString("F2") +
                                       " Y: " + playerShip.transform.position.y.ToString("F2") +
                                       " Z: " + playerShip.transform.position.z.ToString("F2");

        // Inicializa uma string para armazenar as posições dos planetas
        string planetsPositionText = "";

        // Itera sobre os planetas para pegar o nome e a posição de cada um
        foreach (GameObject planet in planets)
        {
            Vector3 planetPosition = planet.transform.position;
            planetsPositionText += planet.name + " - X: " + planetPosition.x.ToString("F2") +
                                   " Z: " + planetPosition.z.ToString("F2") + "\n";
        }

        // Atualiza o texto na tela com a posição da nave e dos planetas
        positionText.text = formattedShipPosition + "\n" + planetsPositionText;
    }

    // Função para carregar o nome do jogador da memória e exibir na tela
    void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Jogador"); // Carrega o nome salvo, ou "Jogador" se não encontrado
        playerNameText.text = playerNameText.text + playerName; // Atualiza o TMP Text com o nome
    }

    // Função para exibir a velocidade da nave
    void UpdateSpeed()
    {
        speedText.text = "Speed: "; // Exibe a velocidade com 2 casas decimais
        float speed = rb.linearVelocity.magnitude; // Obtém a magnitude da velocidade (magnitude é a velocidade total)
        speedText.text = speedText.text + speed.ToString("F2"); // Exibe a velocidade com 2 casas decimais
    }
}
