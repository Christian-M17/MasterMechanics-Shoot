using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoFP : MonoBehaviour
{
    public Transform PlayerTransform;
    private Rigidbody corpo;
    public float velocidade = 5f;
    public static int life;
    private float forcaPulo = 7f;
    private bool noChao;
    private bool movimentoVertical;



    //camera
    public Transform CameraTransform;
    Vector2 rotacaoMouse;
    public int sensibilidade;
    
    
    void Start()
    {
        life = 100;
        Cursor.lockState = CursorLockMode.Locked;
        corpo = gameObject.GetComponent<Rigidbody>();
        movimentoVertical = false;
        
    }

    
    void Update()
    {

        cameraControle();
        Movimentacao();
        Pulo();

        

    }
    void cameraControle()
    {
        Vector2 controleMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        rotacaoMouse = new Vector2(rotacaoMouse.x + controleMouse.x * sensibilidade * Time.fixedDeltaTime,
            rotacaoMouse.y + controleMouse.y * sensibilidade * Time.fixedDeltaTime);



        PlayerTransform.eulerAngles = new Vector3(PlayerTransform.eulerAngles.x, rotacaoMouse.x, PlayerTransform.eulerAngles.z);

        rotacaoMouse.y = Mathf.Clamp(rotacaoMouse.y, -80, 80);

        CameraTransform.localEulerAngles = new Vector3(-rotacaoMouse.y,
            CameraTransform.localEulerAngles.y,
            CameraTransform.localEulerAngles.z);
    }

    void Movimentacao() {

        corpo.velocity = new Vector3(0, corpo.velocity.y, 0);
        
        

        if (Input.GetKey(KeyCode.W))
        {
            
            corpo.velocity = new Vector3(transform.forward.x * velocidade, corpo.velocity.y, transform.forward.z * velocidade);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            corpo.velocity = new Vector3(-transform.forward.x * velocidade, corpo.velocity.y, -transform.forward.z * velocidade);



        }
        if (Input.GetKey(KeyCode.A))
        {
            corpo.velocity = new Vector3(-transform.right.x * velocidade, corpo.velocity.y, -transform.right.z * velocidade);

        }
        if (Input.GetKey(KeyCode.D))
        {
            corpo.velocity = corpo.velocity = new Vector3(transform.right.x * velocidade, corpo.velocity.y, transform.right.z * velocidade);

        }
        
    }

    void Pulo()
    {

        movimentoVertical = Input.GetButtonDown("Jump");

        if (movimentoVertical == true && noChao == true)
        {
            Debug.Log("pulou");
            corpo.AddForce(new Vector3(0, forcaPulo, 0), ForceMode.Impulse);
            
        }


    }

    void OnTriggerEnter(Collider other)
    {
        
            noChao = true;
            Debug.Log("No chão");
            


        
    }

    void OnTriggerExit(Collider other)
    {
        
            noChao = false;
            

            Debug.Log("No ar");




        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BalaInimigo"))
        {

            life -= 10;

            Destroy(collision.gameObject);

            if (life <= 0) {
                life = 100;
            PlayerTransform.position = new Vector3(0, 2, 0);
        }
        }
    }


}
