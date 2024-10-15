using UnityEngine;
using UnityEngine.UI;

public class DollButton : MonoBehaviour
{
    public int id;
    public Button button;
    public SaveDoll saveDoll;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(() =>
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
        });
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
}
