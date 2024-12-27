using UnityEngine;

public class mana_coletavel : MonoBehaviour
{
    public float capacidade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D Obj)
    {
        if (Obj.CompareTag("Player"))
        {
            Player player = Obj.GetComponent<Player>();
            player.ReceberMana(capacidade);
            Destroy(this.gameObject);
        }

    }

}
