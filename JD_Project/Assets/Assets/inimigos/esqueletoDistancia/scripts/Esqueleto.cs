using UnityEngine;
using UnityEngine.AI;

public class Esqueleto : MonoBehaviour
{

    private  float _vida;



    public Transform explo_pos;
    public GameObject explosao;

    [System.Obsolete]
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cria_explosão()
    {
        Instantiate(explosao, explo_pos.position, explo_pos.rotation);
    }

}
