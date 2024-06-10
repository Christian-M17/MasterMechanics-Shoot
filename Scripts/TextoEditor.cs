using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class TextoEditor : MonoBehaviour
{
    public TMP_Text textoMunicao;
    public TMP_Text textoVida;
    private int mostrarBala;
    private int mostrarPente;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.text = "+" + MovimentoFP.life;
        mostrarBala = GunScript.Municao;
        mostrarPente = GunScript.Pente;
        textoMunicao.text = mostrarBala + "/" + mostrarPente;
    }
}
