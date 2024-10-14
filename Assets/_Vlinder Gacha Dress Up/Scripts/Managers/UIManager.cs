using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Button saveButton;
    public Button takeOffButton;
    
    public TakeOffAllPopup takeOffAllPopup;

    private void OnEnable()
    {
        takeOffButton.onClick.AddListener(() =>
        {
            takeOffAllPopup.gameObject.SetActive(true);
        });
    }

    private void OnDisable()
    {
        saveButton.onClick.RemoveAllListeners();
        takeOffButton.onClick.RemoveAllListeners();
    }
}
