using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ads Data", menuName = "Data/Ads Data")]
public class AdsData : ScriptableObject
{
    public List<ItemAdsData> data;
}

[Serializable]
public class ItemAdsData
{
    public List<int> idHasAds;
}