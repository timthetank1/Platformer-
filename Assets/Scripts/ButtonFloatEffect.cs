using System.Timers;
using UnityEngine;

public class ButtonFloatEffect : MonoBehaviour
{
    private Vector2 spinOffset = new Vector2(30,15);
    private float spinPeriod = 25;
    private float growSize = 0.05f;
    private float growPeriod = 7f;
    private float timer;

    void Start()
    {
        timer = 0;
    }

    void Update() {
        timer += Time.deltaTime;
        transform.localPosition = new Vector2(spinOffset.x * Mathf.Sin(2 * Mathf.PI * timer / spinPeriod), spinOffset.y * Mathf.Cos(2 * Mathf.PI * timer / spinPeriod));
        transform.localScale = new Vector2(1, 1) * (1 + growSize * Mathf.Sin(2 * Mathf.PI * timer / growPeriod));
    }
}
