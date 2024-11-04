using UnityEngine.UI;

public class WatchAdsPopup : BasePanel
{
    public Button noButton;
    public Button yesButton;
    public ItemButton targetButton;

    protected override void LoadButtonAndImage()
    {
        noButton = transform.GetChild(0).Find("No Button").GetComponent<Button>();
        yesButton = transform.GetChild(0).Find("Yes Button").GetComponent<Button>();
    }

    protected override void SetListener()
    {
        noButton.onClick.AddListener(ClosePanel);
        yesButton.onClick.AddListener(WatchRewardAds);
    }

    private void OnDisable()
    {
        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();
    }

    private void WatchRewardAds()
    {
        IronSourceRewardedVideoEvents.onAdClosedEvent += OnAdClosed;
        AdsManager.Instance.ShowReward();
    }

    private void OnAdClosed(IronSourceAdInfo adInfo)
    {
        IronSourceRewardedVideoEvents.onAdClosedEvent -= OnAdClosed;
        ClosePanel();
        UnlockItem();
    }

    private void UnlockItem()
    {
        targetButton.UnlockItem();
    }
}