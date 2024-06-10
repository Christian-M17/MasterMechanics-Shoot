using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpeed : MonoBehaviour
{
    private Rigidbody corpoBala;
    public Transform transformBala;
    public int velocidade = 500;
    
    void Start()
    {
        corpoBala = gameObject.GetComponent<Rigidbody>();
        corpoBala.velocity = new Vector3(transform.forward.x * velocidade, transform.forward.y * velocidade - 10, transform.forward.z * velocidade);


    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (transformBala.position.x > 500 ||transformBala.position.x < -500 ||  transformBala.position.z > 500 || transformBala.position.z < -500 ||transformBala.position.y < -100 || transform.position.y > 100)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Enemy")){
            Destroy(gameObject);
            Debug.Log("Contato"); }
    }

   
}
