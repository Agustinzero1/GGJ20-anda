using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AlcanceBehaviour : MonoBehaviour
{
    public int LongitudBrazo { get; set; }

    public int Multiplicador = 1;

    public AlargarBrazoBehaviour Brazo;

    private SphereCollider alcance {get;set;}

    // Start is called before the first frame update
    void Start()
    {
        alcance = GetComponent<SphereCollider>();
        
        LongitudBrazo = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IObjetivo ObtenerAlcanzable(){
        alcance.radius = LongitudBrazo * Multiplicador;

        return Physics  .OverlapSphere(transform.position, alcance.radius)
                        .FirstOrDefault(x => x.gameObject.GetComponent<IObjetivo>() != null )
                        ?.gameObject.GetComponent<IObjetivo>();



    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hola mundo "+ other.gameObject.name);
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Chao mundo "+ other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            Debug.Log("GTFO mundo TOMAR"+ other.gameObject.name);
            
            IActivable activador = other.gameObject.GetComponent<IActivable>();

            if(activador is null){
                return;
            }

            activador.Activar();
            Brazo.LongitudMaxima += Multiplicador; 
        }
    }

}
