using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject balaPrincipal;
    public GameObject balaSecundaria;
    public float velocidadBala;
    public Transform puntoDisparo;

    public int cargadorPrincipal = 10;
    public int cargadorSecundario = 5;

    private int balasRestantesPrincipal;
    private int balasRestantesSecundario;

    private Animator animator;

    public float duracionAnimacionDisparo = 0.6f;

    public float tiempoCooldown = 0.4f;
    private float ultimoDisparo = -999f;

    public AudioClip sonidoDisparoPrincipal;
    public AudioClip sonidoDisparoSecundario;
    public AudioClip sonidoDisparoEnemigo1;
    public AudioClip sonidoDisparoEnemigo2;
    private AudioSource audioSource;

    void Start()
    {
        balasRestantesPrincipal = cargadorPrincipal;
        balasRestantesSecundario = cargadorSecundario;

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.tag == "Enemy")
        {
            InvokeRepeating("DispararProyectilPrincipal", 0, 4f);
        }
    }

    void Update()
    {
        if (gameObject.tag == "Player")
        {
            if (Time.time >= ultimoDisparo + tiempoCooldown)
            {
                if (Input.GetMouseButtonDown(0) && balasRestantesPrincipal > 0)
                {
                    DispararProyectil(balaPrincipal);
                    balasRestantesPrincipal--;
                    ultimoDisparo = Time.time;

                    Debug.Log("Bala principal restante: " + balasRestantesPrincipal);
                    ReproducirSonido(sonidoDisparoPrincipal);
                    ActivarAnimacionDisparoPlayer();
                }

                else if (Input.GetMouseButtonDown(1) && balasRestantesSecundario > 0)
                {
                    DispararProyectil(balaSecundaria);
                    balasRestantesSecundario--;
                    ultimoDisparo = Time.time;

                    Debug.Log("Bala secundaria restante: " + balasRestantesSecundario);
                    ReproducirSonido(sonidoDisparoSecundario);
                    ActivarAnimacionDisparoPlayer();
                }
            }
        }
    }

    void ReproducirSonido(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    void ActivarAnimacionDisparoPlayer()
    {
        if (animator != null)
        {
            animator.SetBool("Disparo", true);
            StartCoroutine(DesactivarAnimacionDisparo());
        }
    }

    IEnumerator DesactivarAnimacionDisparo()
    {
        yield return new WaitForSeconds(duracionAnimacionDisparo);
        if (animator != null)
        {
            animator.SetBool("Disparo", false);
        }
    }

    void DispararProyectilPrincipal()
    {
        
        if (balasRestantesPrincipal > 0)
        {
            
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                
                float distancia = Vector3.Distance(transform.position, jugador.transform.position);
                float distanciaMaximaSonido = 15f;

                if (gameObject.tag == "Enemy")
                {
                    if (distancia <= distanciaMaximaSonido)
                    {
                        if (gameObject.name.Contains("Covid19"))
                        {
                            ReproducirSonido(sonidoDisparoEnemigo1);
                        }
                        else if (gameObject.name.Contains("Caballito"))
                        {
                            ReproducirSonido(sonidoDisparoEnemigo2);
                        }
                        DispararProyectil(balaPrincipal);
                        ActivarAnimacionDisparoEnemigo();
                    }
                }
                else
                {
                    DispararProyectil(balaPrincipal);
                }
            }
            
            balasRestantesPrincipal--;
        }
    }
    void ActivarAnimacionDisparoEnemigo()
    {
        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }
    }


    void DispararProyectil(GameObject balaPrefab)
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        Bala scriptBala = bala.GetComponent<Bala>();
        if (scriptBala != null)
        {
            scriptBala.origenDisparo = this.gameObject;
        }

        Collider balaCol = bala.GetComponent<Collider>();
        Collider emisorCol = GetComponent<Collider>();
        if (balaCol != null && emisorCol != null)
        {
            Physics.IgnoreCollision(balaCol, emisorCol);
        }

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDisparo.forward * velocidadBala;
        }

        Destroy(bala, 5f);
    }
}
