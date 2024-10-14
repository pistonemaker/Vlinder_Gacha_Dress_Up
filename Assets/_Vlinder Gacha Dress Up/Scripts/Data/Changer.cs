public static class Changer
{
    public static string GetDataKey(EItemType itemType)
    {
        switch (itemType)
        {
            case EItemType.Background:
                return DataKey.ID_Background;
            case EItemType.Birthmark:
                return DataKey.ID_Birthmark;
            case EItemType.Eyeblow:
                return DataKey.ID_Eyeblow;
            case EItemType.Body:
                return DataKey.ID_Body;
            case EItemType.Earrings:
                return DataKey.ID_Earrings;
            case EItemType.Blush:
                return DataKey.ID_Blush;
            case EItemType.Eyes:
                return DataKey.ID_Eyes;
            case EItemType.Glass:
                return DataKey.ID_Glass;
            case EItemType.Mouth:
                return DataKey.ID_Mouth;
            case EItemType.Necklace:
                return DataKey.ID_Neckless;
            case EItemType.Nose:
                return DataKey.ID_Nose;
            case EItemType.Shoes:
                return DataKey.ID_Shoes;
            case EItemType.Socks:
                return DataKey.ID_Socks;
            case EItemType.Trouser:
                return DataKey.ID_Trousers;
            case EItemType.Wing:
                return DataKey.ID_Wing;
            case EItemType.Behind_Hair:
                return DataKey.ID_Behind_Hair;
            case EItemType.Front_Hair:
                return DataKey.ID_Front_Hair;
            case EItemType.Hand_Bag:
                return DataKey.ID_Hand_Bag;
            case EItemType.Insight_Shirt:
                return DataKey.ID_Insight_Shirt;
            case EItemType.Outsight_Shirt:
                return DataKey.ID_Outsight_Shirt;
            case EItemType.Short_Dress:
                return DataKey.ID_Short_Dress;
            case EItemType.Long_Dress:
                return DataKey.ID_Long_Dress;
            case EItemType.Normal_Hat:
                return DataKey.ID_Hat;
            default:
                return "";
        }
    }
}