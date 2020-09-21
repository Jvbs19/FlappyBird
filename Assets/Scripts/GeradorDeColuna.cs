using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeColuna : MonoBehaviour
{
    public GameObject Colunas;
    float TempoEntreColunas = 2f;
    Passaro Passaro;
    float AlturaMaxima = 3f;
    float AlturaMinima = -1f;

    void Start()
    {
        Passaro = GameObject.FindGameObjectWithTag("Passaro").GetComponent<Passaro>();
        GeraColuna();
    }

    void GeraColuna()
    {
        if (Passaro.GetMorto() == false)
        {

            float alturaAleatoria = Random.Range(AlturaMinima, AlturaMaxima);
            Vector2 posicaoAleatoria = new Vector2(transform.position.x, alturaAleatoria);

            Instantiate(Colunas, posicaoAleatoria, Quaternion.identity);
            Invoke("GeraColuna", TempoEntreColunas);
        }
    }
}


