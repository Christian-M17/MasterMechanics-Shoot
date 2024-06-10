using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public float tempo = 3;
    public GameObject balainimigo;
    public Transform torreTransform;
    public Transform pontoReferencia;
    public Transform armaPosicao;
    public static int distancia;


    void Start()
    {
        distancia = 50;
    }

    // Update is called once per frame
    void Update()
    {

        pontoReferencia = GameObject.FindWithTag("Player").transform;

        if (pontoReferencia.position.x <= torreTransform.position.x + distancia && pontoReferencia.position.x >= torreTransform.position.x - distancia && 
            pontoReferencia.position.z <= torreTransform.position.z + distancia && pontoReferencia.position.z >= torreTransform.position.z - distancia
            )
        {
            torreTransform.LookAt(pontoReferencia);

            tempo -= Time.deltaTime;
            if (tempo <= 0)
            {
                Instantiate(balainimigo, armaPosicao.position + new Vector3(0, 0.3f, 0), torreTransform.rotation);
                tempo = 3;
            }
        }
    }
}
