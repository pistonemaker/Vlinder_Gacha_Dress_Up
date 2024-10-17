using UnityEngine;
using UnityEngine.UI;

public class DollButton : MonoBehaviour
{
    public int id;
    public Button button;
    public SaveDoll saveDoll;
    public Image backgroundImage;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        LoadBG();
        
        button.onClick.AddListener(OnChooseDollButton);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    private void LoadBG()
    {
        backgroundImage = transform.Find("BG").GetComponent<Image>();
        
        if (saveDoll != null)
        {
            backgroundImage.sprite = saveDoll.background.sprite;
        }
    }

    private void OnChooseDollButton()
    {
        if (saveDoll != null)
        {
            SaveManager.Instance.showDollPanel.gameObject.SetActive(true);
            SaveManager.Instance.showDollPanel.Init(id, saveDoll);
        }
        else
        {
            SaveManager.Instance.CreateEmptyDollButton();
            SaveManager.Instance.OnCreateEmptyDollButton();
        }
    }
}
