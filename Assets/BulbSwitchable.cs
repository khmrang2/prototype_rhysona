using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulbSwitchable : MonoBehaviour
{
    private Light2D light2D;
    private Coroutine blinkCoroutine;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite_on;
    public Sprite sprite_off;

    public float blinkInterval = 1f; // 깜빡거리는 간격
    public float activeDuration = 5f; // 켜진 상태를 유지하는 시간

    public float minBlinkInterval = 0.5f; // 최소 깜빡거림 간격 (초)
    public float maxBlinkInterval = 2f; // 최대 깜빡거림 간격 (초)
    public float minBlinkDuration = 0.05f; // 최소 깜빡거림 지속 시간 (초)
    public float maxBlinkDuration = 0.2f; // 최대 깜빡거림 지속 시간 (초)
    public float minIntensity = 0f; // 최소 밝기 (꺼짐 상태)
    public float maxIntensity = 1f; // 최대 밝기 (켜짐 상태)

    void Start()
    {
        light2D = GetComponent<Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
        spriteRenderer.sprite = sprite_off; // 초기에는 꺼진 상태
        light2D.intensity = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = sprite_on; // 스프라이트를 켜진 상태로 변경
            light2D.intensity = 1f; // 전구를 켜짐 상태로 설정

            if (blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine); // 이전 코루틴이 있으면 중지
            }

            blinkCoroutine = StartCoroutine(BlinkAndStopCoroutine());
        }
    }

    IEnumerator BlinkAndStopCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < activeDuration) { 
            // 깜빡거리는 지속 시간을 랜덤으로 설정
            float blinkDuration = Random.Range(minBlinkDuration, maxBlinkDuration);

            // 꺼짐 상태로 전환
            light2D.intensity = minIntensity;
            yield return new WaitForSeconds(blinkDuration);

            // 깜빡거리는 간격을 랜덤으로 설정
            float blinkInterval = Random.Range(minBlinkInterval, maxBlinkInterval);

            // 켜짐 상태로 전환
            light2D.intensity = maxIntensity;
            yield return new WaitForSeconds(blinkInterval);
        }

        // 시간이 다 되면 전구를 끄고 스프라이트를 꺼진 상태로 변경
        light2D.intensity = 0f;
        spriteRenderer.sprite = sprite_off;
        blinkCoroutine = null;
    }
}
