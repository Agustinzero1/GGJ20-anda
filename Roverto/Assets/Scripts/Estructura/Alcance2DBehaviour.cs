using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Alcance2DBehaviour : MonoBehaviour
{
    public int LongitudBrazo { get; set; }

    public int Multiplicador = 1;

    public AlargarBrazoBehaviour Brazo;

    private CircleCollider2D alcance {get;set;}

    List<Collider2D> results = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        alcance = GetComponent<CircleCollider2D>();
        
        LongitudBrazo = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            
            alcance.OverlapCollider( new ContactFilter2D().NoFilter(),results); 

            IActivable activable = results.FirstOrDefault(c => c.gameObject.GetComponent<IActivable>() != null)?.GetComponent<IActivable>();

            Debug.Log("Click + "+ activable?.ToString());
            if(activable is null){
                return;
            }

            activable.Activar();
        }
    }

    public IObjetivo ObtenerAlcanzable(){
        alcance.radius = LongitudBrazo * Multiplicador;

        return Physics  .OverlapSphere(transform.position, alcance.radius)
                        .FirstOrDefault(x => x.gameObject.GetComponent<IObjetivo>() != null )
                        ?.gameObject.GetComponent<IObjetivo>();



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hola mundo "+ other.gameObject.name);
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Chao mundo "+ other.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
       
    }

}
