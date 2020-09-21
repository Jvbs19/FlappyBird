using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaFundo : MonoBehaviour
{
    Fisica fisica;
    public Vector3 Velocidade = new Vector3(5f, 0, 0); 
    public Passaro Passaro; 

    void Start()
    {
        Passaro = GameObject.FindGameObjectWithTag("Passaro").GetComponent<Passaro>();
        fisica = GetComponent<Fisica>(); 
        fisica.AdicionaVelocidade(Velocidade); 
    }

    void Update()
    {
        if (Passaro.GetMorto() == true)
        {
            fisica.ResetaVelocidade();
        }
    }
}
