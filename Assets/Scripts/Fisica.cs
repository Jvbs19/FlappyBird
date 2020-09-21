using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisica : MonoBehaviour
{

    public float Massa = 1;
    public float Bounce = 0.5f;
    public float FatorAltura = 0.5f;

    Vector3 Forca;
    Vector3 Velocidade;
    Vector3 Aceleracao;
    Vector3 Deslocamento;

    float Tempo;

    Vector3 Gravidade = new Vector3(0, -9.8f, 0);

    public bool UsandoGravidade = true;

    void Start()
    {
        Deslocamento = transform.position;
        LigaGravidade();
    }
    private void Update()
    {
      //  LigaGravidade();
    }
    void FixedUpdate()
    {
        AcionaGravidade();
       
    }
    void LigaGravidade()
    {
        if (UsandoGravidade == false)
        {
            Gravidade = Vector3.zero;
        }
        else
        {
            Gravidade = new Vector3(0, -9.8f, 0);
        }
    }
    void AcionaGravidade()
    {
        Tempo = Time.fixedDeltaTime;
        Aceleracao = Forca / Massa + Gravidade;
        Velocidade += Aceleracao * Tempo;
        Deslocamento += Velocidade * Tempo;
      
        transform.position = Deslocamento;
        Forca = Vector3.zero;
    }
    void AcionaBounce()
    {
        if (Deslocamento.y < FatorAltura)
        {
            Velocidade = Velocidade.magnitude * Bounce * Refletir(Velocidade.normalized, Vector3.up);
            Deslocamento.y = FatorAltura;
        }

        if (Velocidade.magnitude > 0.1f)
        {
            transform.position = Deslocamento;
        }
    }
    public void AdicionaForca(Vector3 f)
    {
        Forca = f;
    }
    public void AdicionaVelocidade(Vector3 v)
    {
        Velocidade = v;
    }
    public void ResetaVelocidade()
    {
        Velocidade = new Vector3(0,0,0);
    }

    void AjustaFrente()
    {
        transform.rotation = Quaternion.LookRotation(Velocidade);
    }
    public void AtualizaDeslocamento(Vector3 des)
    {
        Deslocamento = des;
    }
    public Vector3 Refletir(Vector3 Vetor, Vector3 Normal)
    {
        return Vetor - 2 * Vector3.Dot(Vetor, Normal) * Normal;
    }
}
