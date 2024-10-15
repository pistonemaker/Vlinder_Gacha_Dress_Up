using UnityEngine.UI;

public class TakeOffAllPopup : BasePanel
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
        noButton.onClick.AddListener(ClosePanel);
        yesButton.onClick.AddListener(TakeOffAll);
    }

    private void OnDisable()
    {
        noButton.onClick.RemoveAllListeners();
        yesButton.onClick.RemoveAllListeners();
    }

    private void TakeOffAll()
    {
        Doll.Instance.TakeOffDoll();
        ClosePanel();
    }
}
