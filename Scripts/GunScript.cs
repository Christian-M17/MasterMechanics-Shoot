using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bala;
    public static int Municao = 30;
    public static int Pente = 120;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiro();
        Reload();
    }

    void tiro()
    {
        if (Input.GetMouseButtonDown(0) && Municao != 0)
        {
            Instantiate(bala, gunTransform.position, gunTransform.rotation);
            Municao -= 1;
        }
    }
    void Reload()
    {
       

        if (Input.GetKeyDown(KeyCode.R))
        {

            int recarrega = 30 - Municao;

            if (Pente > 30)
            {
                Municao += recarrega;
                Pente -= recarrega;
            }

            else if (Pente < 30)
            {
                if (recarrega < Pente) {
                    Pente -= recarrega;
                    Municao += recarrega;
                }
                else
                {
                    Municao += Pente;
                    Pente = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
