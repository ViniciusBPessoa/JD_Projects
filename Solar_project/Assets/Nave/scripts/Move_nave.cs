using UnityEngine;

public class MoveNave : MonoBehaviour
{
    public float acceleration = 10f; // Taxa de aceleração padrão
    public float boostedAcceleration = 20f; // Taxa de aceleração ao segurar Shift
    public float maxSpeed = 15f; // Velocidade máxima da nave
    public float rotationSpeed = 5f; // Suavidade na rotação
    public Transform Mycam; // Referência à câmera para seguir a direção
    public bool usarWASD = true; // Define se o controle é por WASD ou setas

    public AudioClip engineSound; // Som do motor da nave
    private AudioSource audioSource; // Componente de áudio
    private Rigidbody rb; // Referência ao Rigidbody

    public ParticleSystem particleSystem1; // Primeiro sistema de partículas
    public ParticleSystem particleSystem2; // Segundo sistema de partículas

    private void Start()
    {
        // Obtém o Rigidbody do objeto
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desativa a gravidade para um controle mais fluido
        rb.linearDamping = 1f; // Configura o arrasto para simular resistência ao movimento

        // Configura o AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = engineSound;
        audioSource.loop = true; // Som do motor deve ser contínuo
        audioSource.playOnAwake = false; // Não toca automaticamente
        audioSource.volume = 0.5f; // Volume inicial
    }

    private void FixedUpdate()
    {
        Move();
        StopMovement();
        UpdateEngineSound();
        UpdateParticleEmission(); // Atualiza a emissão de partículas com base na velocidade
    }

    private void Move()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        // Alterna entre WASD ou setas com base em `usarWASD`
        if (usarWASD)
        {
            // Controle WASD
            moveHorizontal = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);
            moveVertical = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0f);
        }
        else
        {
            // Controle Setas
            moveHorizontal = Input.GetKey(KeyCode.LeftArrow) ? -1f : (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f);
            moveVertical = Input.GetKey(KeyCode.UpArrow) ? 1f : (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);
        }

        // Cria o vetor de movimento baseado na direção da câmera
        Vector3 movimento = new Vector3(moveHorizontal, 0, moveVertical);
        movimento = Mycam.TransformDirection(movimento);

        // Escolhe a aceleração com base na tecla Shift
        float currentAcceleration = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? boostedAcceleration : acceleration;

        // Aplica força na direção do movimento
        if (movimento.magnitude > 0.1f) // Verifica se há entrada de movimento
        {
            rb.AddForce(movimento.normalized * currentAcceleration, ForceMode.Acceleration);

            // Faz a nave rotacionar na direção da câmera somente enquanto se move
            Quaternion targetRotation = Mycam.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // Limita a velocidade máxima
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private void StopMovement()
    {
        // Para o movimento ao pressionar a barra de espaço
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector3.zero; // Zera a velocidade linear
            rb.angularVelocity = Vector3.zero; // Zera a velocidade angular
        }
    }

    private void UpdateEngineSound()
    {
        // Ativa o som do motor apenas quando a nave está se movendo
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Toca o som se ainda não estiver tocando
            }

            // Ajusta o pitch com base na velocidade
            audioSource.pitch = Mathf.Lerp(1f, 2f, rb.linearVelocity.magnitude / maxSpeed); // Pitch de 1 a 2
        }
        else
        {
            // Para o som quando a nave não está se movendo
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void UpdateParticleEmission()
    {
        // Calcula a taxa de emissão com base na velocidade
        float speed = rb.linearVelocity.magnitude; // Obtém a magnitude da velocidade
        float emissionRate = Mathf.Lerp(0f, 100f, speed / maxSpeed); // Lerp entre 0 e 100 dependendo da velocidade

        // Atualiza a taxa de emissão para ambos os sistemas de partículas
        var emissionModule1 = particleSystem1.emission;
        emissionModule1.rateOverTime = emissionRate;

        var emissionModule2 = particleSystem2.emission;
        emissionModule2.rateOverTime = emissionRate;
    }
}
