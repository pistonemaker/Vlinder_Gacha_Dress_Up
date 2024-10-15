using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditColorPopup : BasePanel
{
    public GameObject panel;
    public Image editItemFront;
    public Image editItemBehind;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public TextMeshProUGUI redValue;
    public TextMeshProUGUI greenValue;
    public TextMeshProUGUI blueValue;
    public Button noButton;
    public Button yesButton;
    public Color originalColor;

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadColorValue();
    }

    protected override void LoadButtonAndImage()
    {
        panel = transform.GetChild(0).gameObject;
        editItemBehind = panel.transform.Find("Bubble").GetChild(0).GetComponent<Image>();
        editItemFront = panel.transform.Find("Bubble").GetChild(1).GetComponent<Image>();

        var colorBar = panel.transform.Find("Color Bar").gameObject;
        var redBar = colorBar.transform.Find("Red Bar").gameObject;
        var greenBar = colorBar.transform.Find("Green Bar").gameObject;
        var blueBar = colorBar.transform.Find("Blue Bar").gameObject;

        redSlider = redBar.GetComponentInChildren<Slider>();
        greenSlider = greenBar.GetComponentInChildren<Slider>();
        blueSlider = blueBar.GetComponentInChildren<Slider>();

        redValue = redBar.GetComponentInChildren<TextMeshProUGUI>();
        greenValue = greenBar.GetComponentInChildren<TextMeshProUGUI>();
        blueValue = blueBar.GetComponentInChildren<TextMeshProUGUI>();

        noButton = panel.transform.Find("No Button").GetComponent<Button>();
        yesButton = panel.transform.Find("Yes Button").GetComponent<Button>();
    }

    protected override void SetListener()
    {
        base.SetListener();

        redSlider.onValueChanged.AddListener(_ => ChangeColorValue());
        greenSlider.onValueChanged.AddListener(_ => ChangeColorValue());
        blueSlider.onValueChanged.AddListener(_ => ChangeColorValue());

        noButton.onClick.AddListener(() =>
        {
            editItemFront.color = originalColor;
            editItemBehind.color = originalColor;
            ClosePanel();
        });

        yesButton.onClick.AddListener(() =>
        {
            ItemBarManager.Instance.ApplyColorChange(editItemFront.color);
            ClosePanel();
        });
    }

    public void SetEditImage(Sprite sprite1, Sprite sprite2, Color color)
    {
        if (sprite1 != null)
        {
            editItemFront.sprite = sprite1;
            editItemFront.color = color;
            editItemFront.SetNativeSize();
            editItemFront.gameObject.SetActive(true);
        }
        else
        {
            editItemFront.gameObject.SetActive(false);
        }

        if (sprite2 != null)
        {
            editItemBehind.sprite = sprite2;
            editItemBehind.color = color;
            editItemBehind.SetNativeSize();
            editItemBehind.gameObject.SetActive(true);
        }
        else
        {
            editItemBehind.gameObject.SetActive(false);
        }
    }

    private void LoadColorValue()
    {
        Color color;
        if (editItemFront.sprite != null)
        {
            color = originalColor = editItemFront.color;
        }
        else
        {
            color = originalColor = editItemBehind.color;
        }
        
        float red = color.r;
        float green = color.g;
        float blue = color.b;

        redSlider.value = red;
        greenSlider.value = green;
        blueSlider.value = blue;

        redValue.text = Mathf.RoundToInt(red * 255).ToString();
        greenValue.text = Mathf.RoundToInt(green * 255).ToString();
        blueValue.text = Mathf.RoundToInt(blue * 255).ToString();
    }

    private void ChangeColorValue()
    {
        float red = redSlider.value;
        float green = greenSlider.value;
        float blue = blueSlider.value;

        redValue.text = Mathf.RoundToInt(red * 255).ToString();
        greenValue.text = Mathf.RoundToInt(green * 255).ToString();
        blueValue.text = Mathf.RoundToInt(blue * 255).ToString();

        editItemFront.color = new Color(red, green, blue, 1);
        editItemBehind.color = new Color(red, green, blue, 1);
    }

    private void OnDisable()
    {
        redSlider.onValueChanged.RemoveAllListeners();
        greenSlider.onValueChanged.RemoveAllListeners();
        blueSlider.onValueChanged.RemoveAllListeners();
    }
}