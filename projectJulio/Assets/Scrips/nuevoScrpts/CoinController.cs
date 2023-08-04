using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("paso Moneda");
        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            SceneManager.LoadScene("Nivel2");
        }
        else if
            (SceneManager.GetActiveScene().name == "Nivel2")
        {
            SceneManager.LoadScene("Nivel3");
        }
        else
          
        {
            SceneManager.LoadScene("Fin");
        }


    }
}
