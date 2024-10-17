using UnityEngine;
using UnityEngine.UI;

public class SPLManager : MonoBehaviour
{
    public Button playButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Game");
        });
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
    }
}
