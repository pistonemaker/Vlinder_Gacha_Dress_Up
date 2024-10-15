using UnityEngine;
using UnityEngine.UI;

public class ChooseBSHPanel : BasePanel
{
    public Slider brightnessSlider;
    public Slider saturationSlider;
    public Slider hueSlider;
    public Button resetButton;
    public SpriteRenderer editRenderer;

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadRenderer();
    }

    protected override void LoadButtonAndImage()
    {
        brightnessSlider = transform.Find("BSH Bar").Find("B Bar").Find("Slider").GetComponent<Slider>();
        saturationSlider = transform.Find("BSH Bar").Find("S Bar").Find("Slider").GetComponent<Slider>();
        hueSlider = transform.Find("BSH Bar").Find("H Bar").Find("Slider").GetComponent<Slider>();
        resetButton = transform.Find("Reset Button").GetComponent<Button>();
    }

    protected override void SetListener()
    {
        brightnessSlider.onValueChanged.AddListener(_ => ChangeColorValue());
        saturationSlider.onValueChanged.AddListener(_ => ChangeColorValue());
        hueSlider.onValueChanged.AddListener(_ => ChangeColorValue());
        resetButton.onClick.AddListener(ResetValue);
    }

    private void OnDisable()
    {
        brightnessSlider.onValueChanged.RemoveAllListeners();
        saturationSlider.onValueChanged.RemoveAllListeners();
        hueSlider.onValueChanged.RemoveAllListeners();
        resetButton.onClick.RemoveAllListeners();
    }

    private void LoadRenderer()
    {
        editRenderer = ItemBarManager.Instance.currentItemTypeButton.GetRenderer();
        brightnessSlider.value = 1;
        saturationSlider.value = 1;
        hueSlider.value = 1;
        ChangeColorValue();
    }
    
    public void ChangeColorValue()
    {
        float hue = hueSlider.value; 
        float saturation = saturationSlider.value;
        float brightness = brightnessSlider.value; 

        Color color = Color.HSVToRGB(hue, saturation, brightness);

        if (editRenderer != null)
        {
            editRenderer.color = color;
        }
    }

    private void ResetValue()
    {
        editRenderer.color = Color.white;
    }
}
