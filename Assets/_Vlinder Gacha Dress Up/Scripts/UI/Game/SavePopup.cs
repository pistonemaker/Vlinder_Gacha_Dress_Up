using UnityEngine.SceneManagement;
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
        noButton.onClick.AddListener(LoadSaveScene);
        yesButton.onClick.AddListener(SaveDoll);
    }

    private void OnDisable()
    {
        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();
    }

    private void LoadSaveScene()
    {
        ClosePanel();
        SceneManager.LoadSceneAsync("Scenes/Save");
    }

    private void SaveDoll()
    {
        ClosePanel();
        EventDispatcher.Instance.PostEvent(EventID.On_Save_Game);
        SceneManager.LoadSceneAsync("Scenes/Save");
    }
}
