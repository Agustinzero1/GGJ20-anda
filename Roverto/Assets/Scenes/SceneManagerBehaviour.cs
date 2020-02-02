using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject Creditos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarJuego(){
        SceneManager.LoadScene("Juego");
    }

    public void MostrarCreditos(){
        MenuPrincipal.SetActive(false);
        Creditos.SetActive(true);
    }

    public void VolverMenuPrincipal(){
        MenuPrincipal.SetActive(true);
        Creditos.SetActive(false);
    }

    public void Salir(){
        Application.Quit();
    }
}
