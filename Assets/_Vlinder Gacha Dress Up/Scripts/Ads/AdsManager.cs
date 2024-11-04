using UnityEngine;

public class AdsManager : Singleton<AdsManager>
{
#if UNITY_ANDROID
    private string appKey = "1ffc50a05";
#elif UNITY_IPHONE
    private string appKey = "";
#else
    private string appKey = "unexpected_platform";
#endif

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SDKInit;

        // Banner Ads Events
        IronSourceBannerEvents.onAdLoadedEvent += BannerOnAdLoadedEvent;
        IronSourceBannerEvents.onAdLoadFailedEvent += BannerOnAdLoadFailedEvent;
        IronSourceBannerEvents.onAdClickedEvent += BannerOnAdClickedEvent;
        IronSourceBannerEvents.onAdScreenPresentedEvent += BannerOnAdScreenPresentedEvent;
        IronSourceBannerEvents.onAdScreenDismissedEvent += BannerOnAdScreenDismissedEvent;
        IronSourceBannerEvents.onAdLeftApplicationEvent += BannerOnAdLeftApplicationEvent;

        // Interstitial Ads Events
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;

        // Reward Ads Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;
    }

    private void Start()
    {
        IronSource.Agent.validateIntegration();
        IronSource.Agent.init(appKey);
    }

    private void SDKInit()
    {
        Debug.Log("SDK is initialized");
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        IronSource.Agent.onApplicationPause(pauseStatus);
    }

    #region Banner Ads

    public void LoadBanner()
    {
        IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, IronSourceBannerPosition.TOP);
    }

    public void DestroyBanner()
    {
        IronSource.Agent.destroyBanner();
    }

    //Invoked once the banner has loaded
    private void BannerOnAdLoadedEvent(IronSourceAdInfo adInfo)
    {
    }

    //Invoked when the banner loading process has failed.
    private void BannerOnAdLoadFailedEvent(IronSourceError ironSourceError)
    {
    }

    // Invoked when end user clicks on the banner ad
    private void BannerOnAdClickedEvent(IronSourceAdInfo adInfo)
    {
    }

    //Notifies the presentation of a full screen content following user click
    private void BannerOnAdScreenPresentedEvent(IronSourceAdInfo adInfo)
    {
    }

    //Notifies the presented screen has been dismissed
    private void BannerOnAdScreenDismissedEvent(IronSourceAdInfo adInfo)
    {
    }

    //Invoked when the user leaves the app
    private void BannerOnAdLeftApplicationEvent(IronSourceAdInfo adInfo)
    {
    }

    #endregion

    #region Interstitial Ads

    public void LoadInterstitial()
    {
        IronSource.Agent.loadInterstitial();
    }

    public void ShowInterstitial()
    {
        if (IronSource.Agent.isInterstitialReady())
        {
            IronSource.Agent.showInterstitial();
        }
        else
        {
            Debug.LogError("Interstitial is not ready yet");
        }
    }

    // Invoked when the interstitial ad was loaded succesfully.
    private void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo)
    {
    }

    // Invoked when the initialization process has failed.
    private void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
    {
        Debug.LogError("Interstitial ads load failed");
    }

    // Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
    private void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
    }

    // Invoked when end user clicked on the interstitial ad
    private void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo)
    {
    }

    // Invoked when the ad failed to show.
    private void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo)
    {
    }

    // Invoked when the interstitial ad closed and the user went back to the application screen.
    private void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
        LoadInterstitial();
    }

    // Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
    // This callback is not supported by all networks, and we recommend using it only if  
    // it's supported by all networks you included in your build. 
    private void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo)
    {
    }

    #endregion

    #region Reward Ads

    public void LoadReward()
    {
        IronSource.Agent.loadRewardedVideo();
    }

    public void ShowReward()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            IronSource.Agent.showRewardedVideo();
        }
        else
        {
            Debug.LogError("Reward ads is not ready yet");
        }
    }
    
    // Indicates that there’s an available ad.
    // The adInfo object includes information about the ad that was loaded successfully
    // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
    private void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
    {
    }

    // Indicates that no ads are available to be displayed
    // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
    private void RewardedVideoOnAdUnavailable()
    {
        Debug.LogError("Rewarded video is not available yet");
    }

    // The Rewarded Video ad view has opened. Your activity will lose focus.
    private void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
    }

    // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
    private void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
        LoadReward();
    }

    // The user completed to watch the video, and should be rewarded.
    // The placement parameter will include the reward data.
    // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
    private void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
        Debug.Log("Give reward to player");
    }

    // The rewarded video ad was failed to show.
    private void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
    {
    }

    // Invoked when the video ad was clicked.
    // This callback is not supported by all networks, and we recommend using it only if
    // it’s supported by all networks you included in your build.
    private void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
    }

    #endregion
}