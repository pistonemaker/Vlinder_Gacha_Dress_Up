using UnityEngine;
using UnityEngine.UI;

public class ChooseBSHPanel : BasePanel
{
    public Slider brightnessSlider;
    public Slider saturationSlider;
    public Slider hueSlider;
    public Button resetButton;
    public SpriteRenderer editRenderer;
    public Material material;

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadRenderer(ItemBarManager.Instance.currentItemTypeButton.GetRenderer());
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

    public void LoadRenderer(SpriteRenderer sr)
    { 
        editRenderer = sr;
        material = editRenderer.material;
        material.SetFloat(DataKey.OutlineGlow, 200f);
        material.SetFloat(DataKey.OutlineAlpha, 0f);
        material.SetFloat(DataKey.GreyscaleBlend, 0f);
        material.SetFloat(DataKey.HsvShift, 0f);
        brightnessSlider.value = 0;
        saturationSlider.value = 0;
        hueSlider.value = 0;
    }
    
    public void ChangeColorValue()
    {
        float hue = hueSlider.value; 
        float saturation = saturationSlider.value;
        float brightness = brightnessSlider.value; 
        material.SetFloat(DataKey.OutlineAlpha, brightness);
        material.SetFloat(DataKey.GreyscaleBlend, saturation);
        material.SetFloat(DataKey.HsvShift, hue * 360);
    }

    public void ResetValue()
    {
        material.SetFloat(DataKey.OutlineGlow, 200f);
        material.SetFloat(DataKey.OutlineAlpha, 0f);
        material.SetFloat(DataKey.GreyscaleBlend, 0f);
        material.SetFloat(DataKey.HsvShift, 0f);
        brightnessSlider.value = 0;
        saturationSlider.value = 0;
        hueSlider.value = 0;
    }
}
