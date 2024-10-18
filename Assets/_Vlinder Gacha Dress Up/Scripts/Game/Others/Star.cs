using UnityEngine;

public class Star : MonoBehaviour
{
    public SpriteRenderer sr;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}
