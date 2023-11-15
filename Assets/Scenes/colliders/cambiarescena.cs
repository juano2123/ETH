using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscena : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene("Scenes/tuto2");
            Debug.Log("hpppppp");
        }
        
    }
}
