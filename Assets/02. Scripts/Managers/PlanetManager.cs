using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    Light lightMain = null; // 빛 오브젝트 담을 변수
    float rotateSpeed = 90f; // 빛 회전속도

    // 행성 스탯
    // 기온
    [HideInInspector]
    public float temperature = 0f;
    // 행성 내 산소량
    [HideInInspector]
    public float oxygenLevel = 0f;
    // 토지 레벨
    [HideInInspector]
    public int landLevel = 1;
    // 행성의 물 존재 여부
    [HideInInspector]
    public bool isWater = false; 

    // 날씨 관련 오브젝트 가져오기
    Rain rain = null; // 비
    Snow snow = null; // 눈

    float rainTrigger = 0;
    float snowTrigger = 0;

    // UIManager 가져오기
    UIManager uiManager = null;

    private void Awake()
    {
        // 빛 오브젝트 가져오기
        lightMain = GetComponentInChildren<Light>();

        // 비, 눈 가져오기
        rain = GetComponentInChildren<Rain>();
        snow = GetComponentInChildren<Snow>();
        // 처음엔 비, 눈 안내리게 하기
        rain.gameObject.SetActive(false);
        snow.gameObject.SetActive(false);

        // UIManager 가져오기
        uiManager = GameObject.FindWithTag("UIMANAGER").GetComponent<UIManager>();

        // 비, 눈 트리거 값 랜덤으로 정하기 (0 ~ 1 사이)
        rainTrigger = Random.Range(0f, 1f);
        snowTrigger = Random.Range(0f, 1f);
    }

    private void Start()
    {
        // 빛 회전 코루틴 실행
        StartCoroutine(RotateLightCo(lightMain));
    }

    private void Update()
    {
        ChangeTemperature();
        ChangeLandLevel();
        ChangeOxygen();
        PlanetWeather();
    }

    // 빛 회전(시간 변경) 코루틴
    private IEnumerator RotateLightCo(Light _light)
    {
        while (!uiManager.isPaused) // 게임이 멈춘 상태가 아니라면
        {
            // 2분 30초 마다 실행
            yield return new WaitForSeconds(150f);

            // 빛 90도 회전
            _light.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
        }
    }

    // 날씨 코루틴(인자로 날씨 관련 게임오브젝트)
    private IEnumerator WeatherCo(GameObject _weather)
    {
        // Snow or Rain 활성화
        _weather.gameObject.SetActive(true);

        // 5분에서 10분 정도 랜덤 지속
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        // Snow or Rain 비활성화
        _weather.gameObject.SetActive(false);
    }

    // 행성 날씨 조절 메서드
    private void PlanetWeather()
    {
        if (isWater) // 물이 존재 할 때
        {
            if (temperature > 0) // 영상
            {
                if (rainTrigger >= 0.7f) // 트리거가 0.7 이상일 때
                {
                    // 비 내리게 하기
                    StartCoroutine(WeatherCo(rain.gameObject));
                    rainTrigger = 0;
                }
                else // 비가 안내릴 경우
                {
                    if (rain.gameObject.activeSelf == false) // 비 오브젝트가 비활성화 상태일 때
                    {
                        rainTrigger = Random.Range(0f, 1f);
                    }
                }
            }
            else if (temperature <= 0) // 영하
            {
                if (snowTrigger >= 0.7f) // 트리거가 0.7 이상일 때
                {
                    // 눈 내리게 하기
                    StartCoroutine(WeatherCo(snow.gameObject));
                    snowTrigger = 0;
                }
                else // 눈이 안내릴 경우
                {
                    if (snow.gameObject.activeSelf == false) // 눈 오브젝트가 비활성화 상태일 때
                    {
                        snowTrigger = Random.Range(0f, 1f);
                    }
                }
            }
        }
    }

    // 온도 변화 메서드
    private void ChangeTemperature()
    {
        // 물 존재, 토지 정화도에 따라 온도 변화 -> 20도 정도로 바뀌게
    }

    // 토지 정화도 변화 메서드
    private void ChangeLandLevel()
    {
        // 토지 정화기 1개당 정화도 1 증가
    }

    // 행성 산소량 변화 메서드
    private void ChangeOxygen()
    {
        // 산소 생성기 존재 후 15초 마다 산소 1씩 증가
    }
}