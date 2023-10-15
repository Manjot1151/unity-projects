using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public Canvas deathCanvas;
    public GameObject player;
    public static bool alive = true;
    private bool died = false;
    void Update()
    {
        if (!alive && !died)
        {
            Die();
            died = true;
            return;
        }
    }
    public void Die()
    {
        alive = false;
        player.SetActive(false);
        deathCanvas.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathCanvas.gameObject.SetActive(false);
        player.SetActive(true);
        alive = true;
        died = false;
    }
}
