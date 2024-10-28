using UnityEngine;
using UnityEngine.UI;

public class SPLManager : MonoBehaviour
{
    public Button playButton;
    public Button bannerButton;
    public Button interButton;
    public Button rewardButton;
    public Button appopenButton;
    public AdmobAds admobAds;

    private void OnEnable()
    {
        playButton.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Game");
        });
        
        bannerButton.onClick.AddListener(() =>
        {
            AdmobAds.Instance.ShowBannerAd();
        });
        
        interButton.onClick.AddListener(() =>
        {
            AdmobAds.Instance.ShowInterstitialAd();
        });
        
        rewardButton.onClick.AddListener(() =>
        {
            AdmobAds.Instance.ShowRewardedAd();
        });
        
        appopenButton.onClick.AddListener(() =>
        {
            AdmobAds.Instance.ShowOpenAppAd();
        });
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        if (AdmobAds.Instance == null)
        {
            Debug.LogError("No Admob Ads Controller");
        }
        
        AdmobAds.Instance.LoadBannerAd();
        AdmobAds.Instance.LoadInterstitialAd();
        AdmobAds.Instance.LoadRewardedAd();
        AdmobAds.Instance.LoadOpenAppAd();
        admobAds.ShowBannerAd();
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        bannerButton.onClick.RemoveAllListeners();
        interButton.onClick.RemoveAllListeners();
        rewardButton.onClick.RemoveAllListeners();
        appopenButton.onClick.RemoveAllListeners();
    }
}
