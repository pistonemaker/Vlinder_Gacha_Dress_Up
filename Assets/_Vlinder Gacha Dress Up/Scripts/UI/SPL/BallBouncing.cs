using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BallBouncing : MonoBehaviour
{
    public RectTransform ball1;
    public RectTransform ball2;
    public RectTransform ball3;
    public RectTransform ball4;

    public float bounceHeight = 100f; 
    public float bounceDuration = 0.5f; 

    private void OnEnable()
    {
        float startPosY = 100f;
        ball1.anchoredPosition = new Vector2(ball1.anchoredPosition.x, startPosY);
        ball2.anchoredPosition = new Vector2(ball2.anchoredPosition.x, startPosY);
        ball3.anchoredPosition = new Vector2(ball3.anchoredPosition.x, startPosY);
        ball4.anchoredPosition = new Vector2(ball4.anchoredPosition.x, startPosY);
    }

    public IEnumerator StartBouncing()
    {
        while (true)
        {
            yield return StartCoroutine(Bouncing(ball1));
            yield return StartCoroutine(Bouncing(ball2));
            yield return StartCoroutine(Bouncing(ball3));
            yield return StartCoroutine(Bouncing(ball4));
        }
    }

    private IEnumerator Bouncing(RectTransform ball)
    {
        Vector2 originalPos = ball.anchoredPosition;
        ball.DOAnchorPos(new Vector2(originalPos.x, originalPos.y + bounceHeight), bounceDuration).SetEase(Ease.OutQuad);
        yield return new WaitForSecondsRealtime(bounceDuration);
        ball.DOAnchorPos(originalPos, bounceDuration).SetEase(Ease.InQuad);
        yield return new WaitForSecondsRealtime(bounceDuration);
    }
}

