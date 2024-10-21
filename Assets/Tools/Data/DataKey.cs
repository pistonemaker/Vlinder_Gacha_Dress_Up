using UnityEngine;

public static class DataKey
{
    #region int

    public const string ID_Body = "ID_Body";
    public const string ID_Front_Hair = "ID_Front_Hair";
    public const string ID_Behind_Hair = "ID_Behind_Hair";
    public const string ID_Background = "ID_Background";
    public const string ID_Wing = "ID_Wing";
    public const string ID_Socks = "ID_Socks";
    public const string ID_Shoes = "ID_Shoes";
    public const string ID_Trousers = "ID_Trousers";
    public const string ID_Short_Dress = "ID_Short_Dress";
    public const string ID_Long_Dress = "ID_Long_Dress";
    public const string ID_Eyes = "ID_Eyes";
    public const string ID_Eyeblow = "ID_Eyeblow";
    public const string ID_Mouth = "ID_Mouth";
    public const string ID_Insight_Shirt = "ID_Insight_Shirt";
    public const string ID_Outsight_Shirt = "ID_Outsight_Shirt";
    public const string ID_Hat = "ID_Hat";
    public const string ID_Necklace = "ID_Necklace";
    public const string ID_Hand_Bag = "ID_Hand_Bag";
    public const string ID_Birthmark = "ID_Birthmark";
    public const string ID_Blush = "ID_Blush";
    public const string ID_Earrings = "ID_Earrings";
    public const string ID_Nose = "ID_Nose";
    public const string ID_Glass = "ID_Glass";

    
    public const string Doll_Button = "Doll_Button";
    
    #endregion
    
    public static readonly int OutlineGlow = Shader.PropertyToID("_OutlineGlow");
    public static readonly int OutlineAlpha = Shader.PropertyToID("_OutlineAlpha");
    public static readonly int GreyscaleBlend = Shader.PropertyToID("_GreyscaleBlend");
    public static readonly int HsvShift = Shader.PropertyToID("_HsvShift");

    public static void ApplyConfig(Material mat, ConfigShader config)
    {
        mat.SetFloat(OutlineAlpha, config.brightness);
        mat.SetFloat(GreyscaleBlend, config.saturation);
        mat.SetFloat(HsvShift, config.hue);
    }
    
    public static void GetConFigShader(Material mat, ConfigShader config)
    {
        config.brightness = mat.GetFloat(OutlineAlpha);
        config.saturation = mat.GetFloat(GreyscaleBlend);
        config.hue = mat.GetFloat(HsvShift);
    }

    public static void CloneMaterial(Material matClone, Material mat)
    {
        matClone.SetFloat(OutlineAlpha, mat.GetFloat(OutlineAlpha));
        matClone.SetFloat(GreyscaleBlend, mat.GetFloat(GreyscaleBlend));
        matClone.SetFloat(HsvShift, mat.GetFloat(HsvShift));
    }
}
