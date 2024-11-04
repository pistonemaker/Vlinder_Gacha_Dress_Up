using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameData gameData;
    public SaveData saveData;
    public AdsData adsData;

    private void Start()
    {
        Application.targetFrameRate = 60;
        AdsManager.Instance.LoadBanner();
    }

    private void OnApplicationQuit()
    {
        saveData.isEdit = false;
        saveData.editID = -1;
    }
}
