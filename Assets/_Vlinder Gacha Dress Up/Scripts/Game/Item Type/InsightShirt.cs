using UnityEngine;

public class InsightShirt : ItemTypeButton
{
    protected override void OnEnable()
    {
        eItemType = EItemType.Insight_Shirt;
        targetRenderer = Doll.Instance.insightShirt;
        base.OnEnable();
        canNullValue = true;
        canMultiValue = false;
    }
}
