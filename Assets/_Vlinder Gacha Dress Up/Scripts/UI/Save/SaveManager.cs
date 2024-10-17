using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : Singleton<SaveManager>
{
    public SaveData saveData;
    public SaveDoll saveDollPrefab;
    public DollButton dollButtonPrefab;
    public Transform content;
    public Button backButton;
    
    public ShowDollPanel showDollPanel;
    public List<SaveDoll> saveDollList;
    public List<DollButton> dollButtonList;

    private void OnEnable()
    {
        Application.targetFrameRate = 60;
        LoadProperties();
        CreateDollButtons();    
        SetListeners();
    }

    private void LoadProperties()
    {
        backButton = transform.Find("Back Button").GetComponent<Button>();
    }

    private void CreateDollButtons()
    {
        var count = PlayerPrefs.GetInt(DataKey.Doll_Button);
        
        if (saveData.saveDataList.Count >= count)
        {
            count++;
            PlayerPrefs.SetInt(DataKey.Doll_Button, count);
        }

        for (int i = 0; i < count; i++)
        {
            CreateEmptyDollButton();

            if (saveData.saveDataList.Count > i)
            {
                var saveDoll = PoolingManager.Spawn(saveDollPrefab, transform.position, Quaternion.identity);
                saveDoll.transform.SetParent(dollButtonList[i].transform);
                saveDoll.transform.localScale = Vector3.one * 0.2f;
                saveDoll.Init(saveData.saveDataList[i]);
                dollButtonList[i].saveDoll = saveDoll;
                saveDollList.Add(saveDoll);
            }
        }
    }

    private void SetListeners()
    {
        backButton.onClick.AddListener(() =>
        {
            saveData.isEdit = false;
            saveData.editID = -1;
            LoadSceneManager.Instance.LoadScene("Game");
        });
    }

    public void CreateEmptyDollButton()
    {
        var dollButton = PoolingManager.Spawn(dollButtonPrefab, transform.position, Quaternion.identity);
        dollButton.transform.SetParent(content);
        dollButton.transform.localScale = Vector3.one;
        dollButton.id = dollButtonList.Count;
        dollButtonList.Add(dollButton); 
    }

    public void OnCreateEmptyDollButton()
    {
        int count = PlayerPrefs.GetInt(DataKey.Doll_Button);
        count++;
        PlayerPrefs.SetInt(DataKey.Doll_Button, count);
    }

    private void OnDisable()
    {
        backButton.onClick.RemoveAllListeners();
    }

    public void DeleteDollButton(int id)
    {
        if (saveDollList.Count > id)
        {
            saveData.saveDataList.RemoveAt(id);
            PoolingManager.Despawn(dollButtonList[id].gameObject);
            PoolingManager.Despawn(saveDollList[id].gameObject);
            dollButtonList.RemoveAt(id);
            saveDollList.RemoveAt(id);
        }
    }
}