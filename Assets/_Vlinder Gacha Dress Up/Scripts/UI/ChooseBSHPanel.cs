using UnityEngine;
using UnityEngine.UI;

public class ChooseBSHPanel : BasePanel
{
    public Slider brightnessSlider;
    public Slider saturationSlider;
    public Slider hueSlider;
    public Button resetButton;
    public SpriteRenderer editRenderer;

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
        resetButton.onClick.AddListener(() => { editRenderer.color = Color.white;});
    }

    private void OnDisable()
    {
        brightnessSlider.onValueChanged.RemoveAllListeners();
        saturationSlider.onValueChanged.RemoveAllListeners();
        hueSlider.onValueChanged.RemoveAllListeners();
        resetButton.onClick.RemoveAllListeners();
    }

    public Color HSBToRGB(float hue, float saturation, float brightness)
    {
        float r = 0, g = 0, b = 0;
    
        if (saturation == 0) 
        {
            // Màu xám
            r = g = b = brightness;
        }
        else
        {
            float sectorPos = hue / 60.0f; // Chia hue thành 6 phần (360/60)
            int sectorNumber = Mathf.FloorToInt(sectorPos);
            float fractionalSector = sectorPos - sectorNumber;

            float p = brightness * (1 - saturation);
            float q = brightness * (1 - (saturation * fractionalSector));
            float t = brightness * (1 - (saturation * (1 - fractionalSector)));

            switch (sectorNumber)
            {
                case 0:
                    r = brightness;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = brightness;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = brightness;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = brightness;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = brightness;
                    break;
                case 5:
                    r = brightness;
                    g = p;
                    b = q;
                    break;
            }
        }

        return new Color(r, g, b, 1); 
    }
    
    public void ChangeColorValue()
    {
        float hue = hueSlider.value * 360f; 
        float saturation = saturationSlider.value;
        float brightness = brightnessSlider.value; 

        Color color = HSBToRGB(hue, saturation, brightness);

        if (editRenderer != null)
        {
            editRenderer.color = color;
        }
    }
}
