using UnityEngine;
using UnityEngine.UI;

public class SPLManager : MonoBehaviour
{
    public Button playButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(() =>
        {
            AdsManager.Instance.DestroyBanner();
            LoadSceneManager.Instance.LoadScene("Game");
        });
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        AdsManager.Instance.LoadBanner();
        AdsManager.Instance.LoadInterstitial();
        AdsManager.Instance.LoadReward();
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
    }
}
