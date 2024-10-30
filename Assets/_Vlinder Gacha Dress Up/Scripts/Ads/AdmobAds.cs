using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

public class AdmobAds : Singleton<AdmobAds>
{
    public string appId = "ca-app-pub-3940256099942544~3347511713"; // "ca-app-pub-3940256099942544~3347511713";//Real app id


#if UNITY_ANDROID
    string bannerId = "ca-app-pub-3940256099942544/6300978111";
    string interId = "ca-app-pub-3940256099942544/1033173712"; 
    string rewardedId = "ca-app-pub-3940256099942544/5224354917";
    string openappId = "ca-app-pub-3940256099942544/9257395921"; 
    //string nativeId = "ca-app-pub-3940256099942544/2247696110";

#elif UNITY_IPHONE
    string bannerId = "ca-app-pub-3940256099942544/6300978111";
    string interId = "ca-app-pub-3940256099942544/1033173712";
    string rewardedId = "ca-app-pub-3940256099942544/5224354917";
    string openappId = "ca-app-pub-3940256099942544/9257395921";
    string nativeId = "ca-app-pub-3940256099942544/3986624511";

#endif

    BannerView bannerView;
    InterstitialAd interstitialAd;
    RewardedAd rewardedAd;
    AppOpenAd appOpenAd;
    //NativeAd nativeAd;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(Instance.gameObject);
    }

    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus => { Debug.Log("Ads Initialised !!"); });
        AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
    }

    private void OnDestroy()
    {
        AppStateEventNotifier.AppStateChanged -= OnAppStateChanged;
    }

    #region Banner

    void CreateBannerView()
    {
        if (bannerView != null)
        {
            DestroyBannerAd();
        }

        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
    
        //listen to banner events
        ListenToBannerEvents();
    }
    
    public void LoadBannerAd()
    {
        //create a banner
        CreateBannerView();
        
        //load the banner
        if (bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest();
        Debug.Log("Loading banner Ad !!");
        bannerView.LoadAd(adRequest); //show the banner on the screen
    }

    // Shows the ad.
    public void ShowBannerAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Showing banner view.");
            bannerView.Show();
        }
    }

    void ListenToBannerEvents()
    {
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                      + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                           + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Banner view paid {0} {1}." +
                      adValue.Value +
                      adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () => { Debug.Log("Banner view recorded an impression."); };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () => { Debug.Log("Banner view was clicked."); };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () => { Debug.Log("Banner view full screen content opened."); };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
            LoadBannerAd();
        };
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner Ad");
            bannerView.Destroy();
            bannerView = null;
        }
    }

    #endregion

    #region Interstitial

    public void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        var adRequest = new AdRequest();

        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Interstitial ad failed to load" + error);
                return;
            }

            Debug.Log("Interstitial ad loaded !!" + ad.GetResponseInfo());
            interstitialAd = ad;
            InterstitialEvent(interstitialAd);
        });
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd == null)
        {
            Debug.LogError("Intersititial ad is null");
        }

        if (!interstitialAd.CanShowAd())
        {
            Debug.LogError("Intersititial can not show");
        }
        
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Intersititial ad not ready!!");
        }
    }

    public void InterstitialEvent(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Interstitial ad paid {0} {1}." +
                      adValue.Value +
                      adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { Debug.Log("Interstitial ad recorded an impression."); };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { Debug.Log("Interstitial ad was clicked."); };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { Debug.Log("Interstitial ad full screen content opened."); };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion

    #region Rewarded

    public void LoadRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        var adRequest = new AdRequest();

        RewardedAd.Load(rewardedId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Rewarded failed to load" + error);
                return;
            }

            Debug.Log("Rewarded ad loaded !!");
            rewardedAd = ad;
            RewardedAdEvents(rewardedAd);
        });
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd == null)
        {
            Debug.LogError("Rewarded ad is null");
        }

        if (!rewardedAd.CanShowAd())
        {
            Debug.LogError("Rewarded can not show");
        }
        
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) => { Debug.Log("Give reward to player !!"); });
        }
        else
        {
            Debug.LogError("Rewarded ad not ready");
        }
    }

    public void RewardedAdEvents(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Rewarded ad paid {0} {1}." +
                      adValue.Value +
                      adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { Debug.Log("Rewarded ad recorded an impression."); };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { Debug.Log("Rewarded ad was clicked."); };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { Debug.Log("Rewarded ad full screen content opened."); };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion

    #region OpenApp

    // App open ads can be preloaded for up to 4 hours.
    private readonly TimeSpan TIMEOUT = TimeSpan.FromHours(4);
    private DateTime _expireTime;

    public void LoadOpenAppAd()
    {
        // Clean up the old ad before loading a new one.
        if (appOpenAd != null)
        {
            DestroyAd();
        }

        Debug.Log("Loading app open ad.");

        // Create our request used to load the ad.
        var adRequest = new AdRequest();

        // Send the request to load the ad.
        AppOpenAd.Load(openappId, adRequest, (AppOpenAd ad, LoadAdError error) =>
        {
            // If the operation failed with a reason.
            if (error != null)
            {
                Debug.LogError("App open ad failed to load an ad with error : "
                               + error);
                return;
            }

            if (ad == null)
            {
                Debug.LogError("Unexpected error: App open ad load event fired with " +
                               " null ad and null error.");
                return;
            }

            // The operation completed successfully.
            Debug.Log("App open ad loaded with response : " + ad.GetResponseInfo());
            appOpenAd = ad;

            // App open ads can be preloaded for up to 4 hours.
            _expireTime = DateTime.Now + TIMEOUT;

            // Register to ad events to extend functionality.
            RegisterEventHandlers(ad);
        });
    }

    // Shows the ad.
    public void ShowOpenAppAd()
    {
        if (appOpenAd == null)
        {
            Debug.LogError("App open ad is null");
        }

        if (!appOpenAd.CanShowAd())
        {
            Debug.LogError("App open ad can not show");
        }
        
        // App open ads can be preloaded for up to 4 hours.
        if (appOpenAd != null && appOpenAd.CanShowAd() && DateTime.Now < _expireTime)
        {
            Debug.Log("Showing app open ad.");
            appOpenAd.Show();
        }
        else
        {
            Debug.LogError("App open ad is not ready yet.");
        }
    }

    // Destroys the ad.
    public void DestroyAd()
    {
        if (appOpenAd != null)
        {
            Debug.Log("Destroying app open ad.");
            appOpenAd.Destroy();
            appOpenAd = null;
        }
    }

    private void OnAppStateChanged(AppState state)
    {
        Debug.Log("OnAppStateChanged " + state);
        
        if (state == AppState.Foreground)
        {
            ShowOpenAppAd();
        }
        else
        {
            Debug.LogError("Can not show App Open Ad " + state);
        }
    }

    private void RegisterEventHandlers(AppOpenAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("App open ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { Debug.Log("App open ad recorded an impression."); };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { Debug.Log("App open ad was clicked."); };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { Debug.Log("App open ad full screen content opened."); };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("App open ad full screen content closed.");
            // It may be useful to load a new ad when the current one is complete.
            LoadOpenAppAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("App open ad failed to open full screen content with error : "
                           + error);
        };
    }
    
    #endregion

/*
    #region Native

    public Image img;

    public void RequestNativeAd()
    {
        AdLoader adLoader = new AdLoader.Builder(nativeId).ForNativeAd().Build();

        adLoader.OnNativeAdLoaded += this.HandleNativeAdLoaded;
        adLoader.OnAdFailedToLoad += this.HandleNativeAdFailedToLoad;

        adLoader.LoadAd(new AdRequest.Builder().Build());
    }

    private void HandleNativeAdLoaded(object sender, NativeAdEventArgs e)
    {
        print("Native ad loaded");
        this.nativeAd = e.nativeAd;

        Texture2D iconTexture = this.nativeAd.GetIconTexture();
        Sprite sprite = Sprite.Create(iconTexture, new Rect(0, 0, iconTexture.width, iconTexture.height), Vector2.one * .5f);

        img.sprite = sprite;
    }

    private void HandleNativeAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        print("Native ad failed to load" + e.ToString());

    }
    #endregion
*/
}