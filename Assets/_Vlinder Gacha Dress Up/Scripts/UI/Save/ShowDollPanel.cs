using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowDollPanel : BasePanel
{
    public int curID;
    public Image BG;
    public Button backButton;
    public Button editButton;
    public Button deleteButton;
    public SaveDoll saveDoll;

    public void Init(int id, SaveDoll doll)
    {
        curID = id;
        saveDoll.CloneDoll(doll);
        BG.sprite = saveDoll.background.sprite;
    }

    protected override void LoadButtonAndImage()
    {
        backButton = transform.Find("Back Button").GetComponent<Button>();
        editButton = transform.Find("Edit Button").GetComponent<Button>();
        deleteButton = transform.Find("Delete Button").GetComponent<Button>();
        saveDoll = transform.Find("Save Doll").GetComponent<SaveDoll>();
        BG = GetComponent<Image>();
    }

    protected override void SetListener()
    {
        backButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        
        editButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            SaveManager.Instance.saveData.isEdit = true;
            SaveManager.Instance.saveData.editID = curID;
            DOTween.KillAll();
            LoadSceneManager.Instance.LoadScene("Game");
        });
        
        deleteButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.DeleteDollButton(curID);
            gameObject.SetActive(false);
        });
    }

    private void OnDisable()
    {
        backButton.onClick.RemoveAllListeners();
        editButton.onClick.RemoveAllListeners();
        deleteButton.onClick.RemoveAllListeners();
    }
}
