using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DollButton : MonoBehaviour
{
    public int id;
    public Button button;
    public SaveDoll saveDoll;
    public Image backgroundImage;
    public Image body;
    public Image plus;
    public Image lockImg;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnChooseDollButton);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }

    public void LoadBG()
    {
        backgroundImage = transform.Find("BG").Find("BG").GetComponent<Image>();
        var thumb = transform.Find("BG").Find("Thumb");
        body = thumb.Find("Body").GetComponent<Image>();
        plus = thumb.Find("Plus").GetComponent<Image>();
        lockImg = thumb.Find("Lock").GetComponent<Image>();
        
        if (saveDoll != null)
        {
            backgroundImage.sprite = saveDoll.background.sprite;
            body.gameObject.SetActive(false);
            plus.gameObject.SetActive(false);
            lockImg.gameObject.SetActive(false);
        }
        else
        {
            if (id == SaveManager.Instance.dollButtonList.Count - 1)
            {
                plus.gameObject.SetActive(false);
                lockImg.gameObject.SetActive(true);
            }
            else
            {
                plus.gameObject.SetActive(true);
                plus.DOFade(0, 0.75f).SetLoops(-1, LoopType.Yoyo);
                lockImg.gameObject.SetActive(false);
            }
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
            if (id == SaveManager.Instance.dollButtonList.Count - 1)
            {
                plus.gameObject.SetActive(true);
                plus.DOFade(0, 0.75f).SetLoops(-1, LoopType.Yoyo);
                lockImg.gameObject.SetActive(false);
                SaveManager.Instance.CreateEmptyDollButton();
                var dollButton = SaveManager.Instance.dollButtonList[id + 1];
                dollButton.LoadBG();
                SaveManager.Instance.OnCreateEmptyDollButton();
            }
            else
            {
                SaveManager.Instance.saveData.isEdit = false;
                SaveManager.Instance.saveData.editID = -1;
                DOTween.KillAll();
                LoadSceneManager.Instance.LoadScene("Game");
            }
        }
    }
}
