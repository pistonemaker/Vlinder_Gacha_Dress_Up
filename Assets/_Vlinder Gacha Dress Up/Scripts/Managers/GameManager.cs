using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;

    private void Awake()
    {
        CheckGetData();
    }

    private void CheckGetData()
    {
        if (gameData.data.Count < 0)
        {
            //LoadData();
        }
    }

    private void LoadData(string folderPath)
    {
        
    }
}
