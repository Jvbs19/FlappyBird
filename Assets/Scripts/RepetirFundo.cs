using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFundo : MonoBehaviour
{
    Fisica fisica;
    Vector3 Size = new Vector3(20.48f, 2.5f, 0);
    Transform posicaoFundo; 

    void Start()
    {
        fisica = GetComponent<Fisica>();
        posicaoFundo = GetComponent<Transform>();
    }

    void Update()
    {
        VoltaInicio();
    }
    void VoltaInicio()
    {
        if (posicaoFundo.position.x <= -Size.x)
        {
            posicaoFundo.position = new Vector3(posicaoFundo.position.x + Size.x * 2f, posicaoFundo.position.y, 0);
            fisica.AtualizaDeslocamento(posicaoFundo.position);
        }
    }
}
