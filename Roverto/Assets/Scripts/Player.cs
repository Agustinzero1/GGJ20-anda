using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int maxBateryLvl = 100;
    public int bateryLvl = 100;

    public int speed = 5;

    private bool isCargando = true;

    public float currentTimeToDie = 3;
    public float timeToDie = 3;

    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bateryLvl == 0)
        {
            if (currentTimeToDie > 0)
                currentTimeToDie = currentTimeToDie - speed * Time.deltaTime;
            else
            {
                
                if (!dead)
                {
                    dead = true;
                    StartCoroutine(Die());
                    AudioManager.instance.PlayFx("12");

                }
            }
        }
        else
        {
            currentTimeToDie = timeToDie;
            if (isCargando)
            {
                bateryLvl = Mathf.CeilToInt(bateryLvl + speed * Time.deltaTime) <= maxBateryLvl ? Mathf.CeilToInt(bateryLvl + speed * Time.deltaTime) : maxBateryLvl;
            }
            else
            {
                bateryLvl = Mathf.FloorToInt(bateryLvl - speed * Time.deltaTime) > 0 ? Mathf.FloorToInt(bateryLvl - speed * Time.deltaTime) : 0;
            }
        }
    }

    public void ChangeCargar(bool isCargando)
    {
        this.isCargando = isCargando;
    }

    IEnumerator Die()
    {
 
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
