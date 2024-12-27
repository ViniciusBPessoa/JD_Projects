using UnityEngine;
using UnityEngine.UI;

public class Controleprotagonista : MonoBehaviour
{
    public Player player;

    public Image vidaBar;
    public Image manaBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vidaBar.fillAmount = 1 - (player.vida / player.maxVida);
        manaBar.fillAmount = 1 - (player.mana / player.maxMana);
    }
}
