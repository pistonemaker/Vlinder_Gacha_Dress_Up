public class TransitionFx : Singleton<TransitionFx>
{
    public BallBouncing ballBouncing;

    public void StartLoadScene()
    {
        gameObject.SetActive(true);
        StartCoroutine(ballBouncing.StartBouncing());
    }

    public void EndLoadScene()
    {
        gameObject.SetActive(false);
        StopCoroutine(ballBouncing.StartBouncing());
    }
}