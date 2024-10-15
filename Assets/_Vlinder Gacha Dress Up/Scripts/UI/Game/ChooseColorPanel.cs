using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChooseColorPanel : BasePanel
{
    public Transform content;
    public Button editColorButton;
    public Button clearColorButton;
    public List<Button> colorButtons;

    protected override void LoadButtonAndImage()
    {
        content = transform.GetChild(0);
        editColorButton = content.Find("Edit Color Button").GetComponent<Button>();
        clearColorButton = content.Find("Clear Color Button").GetComponent<Button>();
        colorButtons = content.GetComponentsInChildren<Button>().ToList();
        colorButtons.Remove(editColorButton);
        colorButtons.Remove(clearColorButton);
    }

    protected override void SetListener()
    {
        editColorButton.onClick.AddListener(ShowEditColorPopup);
        clearColorButton.onClick.AddListener(ClearColor);

        foreach (Button button in colorButtons)
        {
            button.onClick.AddListener(() =>
            {
                var colorToChange = button.transform.GetChild(0).GetComponent<Image>().color;
                ChangeColor(colorToChange);
            });
        }
    }

    private void ShowEditColorPopup()
    {
        var sprite1 = ItemBarManager.Instance.frontHairButton.curItemData.sprite;
        var sprite2 = ItemBarManager.Instance.behindHairButton.curItemData.sprite;
        var color = ItemBarManager.Instance.currentItemTypeButton.GetCurSpriteRenderer().color;
        ItemBarManager.Instance.editColorPopup.SetEditImage(sprite1, sprite2, color);
        ItemBarManager.Instance.editColorPopup.gameObject.SetActive(true);
    }

    private void ClearColor()
    {
        ItemBarManager.Instance.ClearColor();
    }

    private void ChangeColor(Color color)
    {
        ItemBarManager.Instance.ApplyColorChange(color);
    }

    private void OnDisable()
    {
        editColorButton.onClick.RemoveAllListeners();
        clearColorButton.onClick.RemoveAllListeners();

        foreach (Button button in colorButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
