using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public void RestartGame()
    {
        StartCoroutine(RestartNextFrame());
    }

    IEnumerator RestartNextFrame()
    {
        yield return null;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }

}
