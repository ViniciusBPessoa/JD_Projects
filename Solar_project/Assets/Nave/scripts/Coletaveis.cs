using UnityEngine;
using UnityEngine.SceneManagement;

public class Coletaveis : MonoBehaviour
{
    public int N_coletados = 0;
    public int N_totais;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        N_totais = GameObject.FindGameObjectsWithTag("Coletavel").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void soma()
    {
        N_coletados++;
        if(N_coletados >= N_totais)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
