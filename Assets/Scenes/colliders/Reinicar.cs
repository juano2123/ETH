using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    // Cambié el nombre de la variable a "colliderObject" para evitar la advertencia.
    public GameObject colliderObject;

    private void OnTriggerEnter(Collider other)
    {
        
            // Asegúrate de que el nombre de la escena esté correctamente escrito y exista en el proyecto.
            SceneManager.LoadScene("Scenes/tuto2");
            Debug.Log("hola");
        
    }
}
