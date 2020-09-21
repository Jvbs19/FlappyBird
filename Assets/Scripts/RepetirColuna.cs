using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirColuna : MonoBehaviour
{
    Fisica fisica;
    Vector3 Size = new Vector3(20.48f, 2.5f, 0);
    Transform posicaoFundo;
    float AlturaMaxima = 3f;
    float AlturaMinima = -1f;
    float alturaAleatoria;

    void Start()
    {
        fisica = GetComponent<Fisica>();
        posicaoFundo = GetComponent<Transform>();
        alturaAleatoria = Random.Range(AlturaMinima, AlturaMaxima);
   
    }

    void Update()
    {
        VoltaInicio();
    }
    void VoltaInicio()
    {
        if (posicaoFundo.position.x <= -Size.x)
        {
            alturaAleatoria = Random.Range(AlturaMinima, AlturaMaxima);
            posicaoFundo.position = new Vector3(posicaoFundo.position.x + 61, alturaAleatoria, 0);
            fisica.AtualizaDeslocamento(posicaoFundo.position);
        }
    }
}
