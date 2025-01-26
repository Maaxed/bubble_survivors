using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject ScoreUi;
    private void OnEnable()
    {
        ScoreUi.SetActive(false);
    }
}
