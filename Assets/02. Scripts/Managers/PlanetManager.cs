//using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    Light lightMain = null; // 빛 오브젝트 담을 변수
    float rotateSpeed = 0.6f; // 회전속도 초당 0.6(= 360 / 600) -> 10분에 한바퀴

    //RainScript rain = null; // 비 이펙트 담을 변수
    bool isRain = false; // 비 내리게 할지 판단할 변수

    private void Awake()
    {
        // 빛 오브젝트 가져오기
        lightMain = GetComponentInChildren<Light>();

        // 비 이펙트 가져오기
        //rain = GetComponentInChildren<RainScript>();
        // 비 이펙트 꺼두기
        //rain.gameObject.SetActive(false);
    }

    private void Start()
    {
        // 빛 회전 코루틴 실행
        StartCoroutine(RotateLightCo(lightMain));
    }

    private void Update()
    {
        // 비 내리기가 true면 비 코루틴 실행
        if (isRain)
        {
            //StartCoroutine(RainCo(rain));
        }
    }

    // 빛 회전(시간 변경) 코루틴
    private IEnumerator RotateLightCo(Light _light)
    {
        while (true) // true 에서 게임이 정지하지 않으면으로 변경해야 함
        {
            // 1초 대기
            yield return new WaitForSeconds(1f);
            // 회전
            _light.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
            // 한 프레임에 한 번만 실행
            yield return null;
        }
    }

    // 비 코루틴
    //private IEnumerator RainCo(RainScript _rain)
    //{
    //    // 비 내리게 하기
    //    _rain.gameObject.SetActive(true);
    //    // 비 세기 랜덤으로 바꾸기
    //    _rain.RainIntensity = Random.Range(0.5f, 1f);

    //    // 랜덤 지속시간 동안 비내리게 하기
    //    yield return new WaitForSeconds(Random.Range(300f, 600f));

    //    // 비 지속시간이 끝나면 멈추게 하기
    //    _rain.gameObject.SetActive(false);
    //    // 비 내리기 false로 변경
    //    isRain = false;
    //}
}