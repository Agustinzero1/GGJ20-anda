using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AntennaButton : MonoBehaviour
{
    public Animator anim;

    public void GanarCorutine()
    {
        StartCoroutine( (Ganar());
    }

    public IEnumerable Ganar()
    {
        anim.SetBool("reparada",true);
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MenuPrincipal");

    }
}
