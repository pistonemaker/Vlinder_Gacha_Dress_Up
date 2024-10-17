using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameData gameData;
    public SaveData saveData;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void OnApplicationQuit()
    {
        saveData.isEdit = false;
        saveData.editID = -1;
    }
}
