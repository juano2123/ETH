using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Escena : MonoBehaviour
{
    // Start is called before the first frame update
    public void reiniciar() {
        SceneManager.LoadScene("Scenes/Forest");

    }

    public void CargarEsceS1() {
        SceneManager.LoadScene("Scenes/House");
    }
    public void reiniciarS2()
    {
        SceneManager.LoadScene("Scenes/House");

    }
    public void CargarEsceS2()
    {
        SceneManager.LoadScene("Scenes/Forest");
    }

}
