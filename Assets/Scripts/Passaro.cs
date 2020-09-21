using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passaro : MonoBehaviour
{

    Animator animador;
    Fisica fisica;
    public float ForcaPraCima = 200f;
    Vector3 vetorForca;
    bool Morto = false;
    public GameObject TelaFimDeJogo;
    public Text TextoPontuacao;
    public int Pontuacao = 0;

    bool pontuaUmavez = false;
    float timer = 1;
    void Start()
    {
        animador = GetComponent<Animator>();
        fisica = GetComponent<Fisica>();
        vetorForca = new Vector3(0, ForcaPraCima, 0);
    }
    void Update()
    {
        Timer();
        Comportamento();
    }
    void Timer()
    {
        if(pontuaUmavez == true)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            pontuaUmavez = false;
            timer = 1;
        }
    }
    void Comportamento()
    {
        if (Morto == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fisica.AdicionaForca(vetorForca);
                animador.SetTrigger("Voar");
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void Mata()
    {
        Morto = true; 
        fisica.UsandoGravidade = false;
        TelaFimDeJogo.SetActive(true);
        animador.SetTrigger("Morrer");
    }
    public void Pontua()
    {
        if (pontuaUmavez == false)
        {
            Pontuacao = Pontuacao + 1;
            TextoPontuacao.text = "Pontuação: " + Pontuacao;
            pontuaUmavez = true;
        }
    }
    public bool GetMorto()
    {
        return Morto;
    }
}
