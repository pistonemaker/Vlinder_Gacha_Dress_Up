using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject circleSmall;
    public GameObject circleBig;

    public void Init()
    {
        circleBig.transform.localScale = Vector3.one * 0.5f;
        circleSmall.transform.localScale = Vector3.one * 0.15f;
    }

    public IEnumerator CircleAnim()
    {
        Init();
        circleBig.transform.DOKill();
        circleSmall.transform.DOKill();

        Tween bigTween = circleBig.transform.DOScale(0.75f, 0.75f);
        Tween smallTween = circleSmall.transform.DOScale(0.65f, 0.75f);

        yield return smallTween.WaitForCompletion();

        gameObject.SetActive(false);
        ClickManager.Instance.circleCoroutine = null;
    }
}