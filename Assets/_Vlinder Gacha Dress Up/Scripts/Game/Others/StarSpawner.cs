using System.Collections;
using DG.Tweening;
using UnityEngine;

public class StarSpawner : Singleton<StarSpawner>
{
    public Star starPrefab;
    public Sprite sprite1;
    public Sprite sprite2;
    public int starNumber;
    public float width;
    public float height;
    public float duration;

    public IEnumerator SpawnStar()
    {
        for (int round = 0; round < 3; round++)
        {
            for (int i = 0; i < starNumber; i++)
            {
                var star = PoolingManager.Spawn(starPrefab, transform.position, Quaternion.identity);
                star.transform.SetParent(transform);

                Vector2 startPos = new Vector2(Random.Range(-width, width), Random.Range(-height, height) + 1.5f);
                star.transform.position = startPos;

                star.sr.sprite = sprite1;
                star.transform.localScale = Vector3.one * 0.2f;
                star.transform.DOKill();
                star.transform.DOScale(0.75f, duration);
                StartCoroutine(AnimateStar(star));
            }

            yield return new WaitForSeconds(duration);
        }
    }

    private IEnumerator AnimateStar(Star star)
    {
        yield return new WaitForSeconds(duration);
        
        star.sr.sprite = sprite2;
        star.transform.DOScale(0.2f, duration);

        yield return new WaitForSeconds(duration);
        PoolingManager.Despawn(star.gameObject);
    }
}
