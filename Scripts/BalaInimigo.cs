using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaInimigo : MonoBehaviour
{
    public Transform BalaTransform;
    public Rigidbody BalaRigidBody;
    public Transform pontoReferencia;
    public int velocidade = 500;
    void Start()
    {
        pontoReferencia = GameObject.FindWithTag("Player").transform;
        BalaTransform.LookAt(pontoReferencia);
        BalaRigidBody.velocity = new Vector3(transform.forward.x * velocidade, 1, transform.forward.z * velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        if (BalaTransform.position.x > 500 || BalaTransform.position.x < -500 || BalaTransform.position.z > 500 || BalaTransform.position.z < -500 || BalaTransform.position.y < -100 || BalaTransform.position.y > 100)
        {
            Destroy(gameObject);
        }
    }

    
}
