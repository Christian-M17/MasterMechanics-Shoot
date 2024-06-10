using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int lifeinimigo = 100;
    public Transform inimigoTransform;
    private Vector3 transformInicial;
    private Rigidbody InimigoCorpo;
    public Transform pontoReferencia;
    private string IndoVindoX = "Indo";
    private string IndoVindoZ = "Indo";
    void Start()
    {
        
        InimigoCorpo = gameObject.GetComponent<Rigidbody>();
        transformInicial = new Vector3 (inimigoTransform.position.x, inimigoTransform.position.y, inimigoTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        pontoReferencia = GameObject.FindWithTag("Player").transform;

        if (pontoReferencia.position.x <= inimigoTransform.position.x + Torreta.distancia && pontoReferencia.position.x >= inimigoTransform.position.x - Torreta.distancia &&
            pontoReferencia.position.z <= inimigoTransform.position.z + Torreta.distancia && pontoReferencia.position.z >= inimigoTransform.position.z - Torreta.distancia
            )
        {
            InimigoCorpo.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            MovimentoZ();
            MovimentoX();
        }
    }

    void MovimentoX() { 
        switch (IndoVindoX)
        {
            case "Indo":
                if (inimigoTransform.position.x <= transformInicial.x + 10)
                {
                    InimigoCorpo.velocity = new Vector3(5, InimigoCorpo.velocity.y, InimigoCorpo.velocity.z);
                }
                else
                {
                    IndoVindoX = "Vindo";
                    inimigoTransform.rotation = Quaternion.Euler(inimigoTransform.rotation.x, -90, inimigoTransform.rotation.z);
                }
                    break;
            case "Vindo":
                if (inimigoTransform.position.x >= transformInicial.x - 10)
                {
                    InimigoCorpo.velocity = new Vector3(-5, InimigoCorpo.velocity.y, InimigoCorpo.velocity.z);
                }
                else
                {
                    inimigoTransform.rotation = Quaternion.Euler(inimigoTransform.rotation.x, 90, inimigoTransform.rotation.z);
                    IndoVindoX = "Indo";
                    
                }
                break;
                default:
                break;

        }
        
          
        
     
    }

    void MovimentoZ()
    {
        switch (IndoVindoZ)
        {
            case "Indo":
                if (inimigoTransform.position.z <= transformInicial.z + 10)
                {
                    InimigoCorpo.velocity = new Vector3(InimigoCorpo.velocity.x, InimigoCorpo.velocity.y, 5);
                }
                else
                {
                    IndoVindoZ = "Vindo";
                    Debug.Log("Vindo");
                }
                break;
            case "Vindo":
                if (inimigoTransform.position.z >= transformInicial.z - 10)
                {
                    InimigoCorpo.velocity = new Vector3(InimigoCorpo.velocity.x, InimigoCorpo.velocity.y, -5);
                }
                else
                {

                    IndoVindoZ = "Indo";
                    Debug.Log("Indo");
                }
                break;
            default:
                break;

        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            
            lifeinimigo -= 10;
            Debug.Log("Tomou tiro" + lifeinimigo);
            Destroy(collision.gameObject);
        }

        if(lifeinimigo <= 0)
        {
            Destroy(gameObject);
        }
    }
}
