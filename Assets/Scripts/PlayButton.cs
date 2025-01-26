using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public void OnClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
