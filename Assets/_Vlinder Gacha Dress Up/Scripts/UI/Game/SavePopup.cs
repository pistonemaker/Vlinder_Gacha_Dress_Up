using UnityEngine;
using UnityEngine.UI;

public class SavePopup : BasePanel
{
    public Button noButton;
    public Button yesButton;

    protected override void LoadButtonAndImage()
    {
        noButton = transform.GetChild(0).Find("No Button").GetComponent<Button>();
        yesButton = transform.GetChild(0).Find("Yes Button").GetComponent<Button>();
    }

    protected override void SetListener()
    {
        noButton.onClick.AddListener(NotSaveDoll);
        yesButton.onClick.AddListener(SaveDoll);
    }

    private void OnDisable()
    {
        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();
    }

    public void NotSaveDoll()
    {
        if (DataKey.CanShowInter())
        {
            IronSourceInterstitialEvents.onAdClosedEvent += OnAdClosedForNotSave;
            AdsManager.Instance.ShowInterstitial();
            LoadSaveScene();
        }
        else
        {
            LoadSaveScene();
        }
    }

    private void OnAdClosedForNotSave(IronSourceAdInfo adInfo)
    {
        IronSourceInterstitialEvents.onAdClosedEvent -= OnAdClosedForNotSave;
    }

    private void LoadSaveScene()
    {
        ClosePanel();
        AdsManager.Instance.DestroyBanner();
        LoadSceneManager.Instance.LoadScene("Save");
    }

    private void SaveDoll()
    {
        if (DataKey.CanShowInter())
        {
            IronSourceInterstitialEvents.onAdClosedEvent += OnAdClosedForSave;
            AdsManager.Instance.ShowInterstitial();
            SaveGameAndLoadSaveScene();
        }
        else
        {
            SaveGameAndLoadSaveScene();
        }
    }

    private void OnAdClosedForSave(IronSourceAdInfo adInfo)
    {
        IronSourceInterstitialEvents.onAdClosedEvent -= OnAdClosedForSave;
    }

    private void SaveGameAndLoadSaveScene()
    {
        Debug.Log("Save");
        ClosePanel();
        EventDispatcher.Instance.PostEvent(EventID.On_Save_Game);
        AdsManager.Instance.DestroyBanner();
        LoadSceneManager.Instance.LoadScene("Save");
    }
}