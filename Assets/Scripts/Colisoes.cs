using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisoes : MonoBehaviour
{

    GameObject Obstaculo;
    public GameObject passaro;

    public Vector3 SizeObstaculo = new Vector3(1.16f, 10.24f, 0); //1.16/10.24
    Vector3 ObstaculoInicio;
    Vector3 ObstaculoFim;

    Vector3 SizePassaro;
    float RaioPassaro;

    public bool mata = true;

    private void Start()
    {
        passaro = GameObject.FindGameObjectWithTag("Passaro");
        Obstaculo = this.gameObject;
    }
    void Update()
    {
        AtualizaPosicao();
        ChecaColisao();


    }
    void ChecaColisao()
    {
        if (Colisao())
        {
            if (mata == true)
            {
                Debug.Log("Colidiu");
                passaro.GetComponent<Passaro>().Mata();
            }
            else
            {
                passaro.GetComponent<Passaro>().Pontua();
            }
        }
     
    }
    void AtualizaPosicao()
    {
        ObstaculoInicio = Obstaculo.transform.position - Obstaculo.transform.localScale / 2.0f;
        ObstaculoFim = Obstaculo.transform.position + Obstaculo.transform.localScale / 2.0f;
        SizePassaro = passaro.transform.position;
        RaioPassaro = passaro.transform.localScale.x / 2.0f;
    }

    bool Colisao()
    {
        Vector3 halfextents = SizeObstaculo / 2.0f;
        Vector3 diferenca = passaro.transform.position - Obstaculo.transform.position;
        Vector3 clampp = Clampp(diferenca, -halfextents, halfextents);
        Vector3 Perto = Obstaculo.transform.position + clampp;
        Vector3 dif = Perto - passaro.transform.position;
        return dif.magnitude < RaioPassaro;
    }

    Vector3 Clampp(Vector3 d, Vector3 min, Vector3 max)
    {
        float x, y, z;
        x = d.x;
        y = d.y;
        z = d.z;

        if (d.x > max.x)
            x = max.x;

        else if (d.x < min.x)
            x = min.x;

        if (d.y > max.y)
            y = max.y;
        else if (d.y < min.y)
            y = min.y;

        if (d.z > max.z)
            z = max.z;
        else if (d.z < min.z)
            z = min.z;

        return new Vector3(x, y, z);
    }

}
