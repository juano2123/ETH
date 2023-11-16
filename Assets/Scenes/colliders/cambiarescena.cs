using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscena : MonoBehaviour
{
    public string escena;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(escena);
            Debug.Log("hpppppp");
        }
        
    }
}
