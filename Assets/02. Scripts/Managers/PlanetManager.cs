using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    Light lightMain = null; // 빛 오브젝트 담을 변수
    float rotateSpeed = 0.01f; // 회전속도 초당 0.01(= (360(각도) / 600(10분)) / 60(프레임)) -> 10분에 한바퀴

    // 행성 스탯
    [HideInInspector]
    public float temperature = 0f;
    float oxygenLevel = 0f;
    int landLevel = 1;
    bool isWater = false; // 행성의 물 존재 여부

    // 날씨 관련 오브젝트 가져오기
    Rain rain = null;
    Snow snow = null;

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

        // 행성 정보 랜덤으로 정하기
        temperature = Random.Range(-30f, 100f);
        landLevel = Random.Range(1, 3);
        oxygenLevel = Random.Range(0f, 30f);

        // UIManager 가져오기
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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

        if (isWater) // 물이 존재 할 때
        {
            if (temperature > 0) // 영상
            {
                // 비 내리게 하기
                StartCoroutine(WeatherCo(rain.gameObject));
            }
            else if (temperature <= 0) // 영하
            {
                // 눈 내리게 하기
                StartCoroutine(WeatherCo(snow.gameObject));
            }
        }
    }

    // 빛 회전(시간 변경) 코루틴
    private IEnumerator RotateLightCo(Light _light)
    {
        while (!uiManager.isPaused) // 게임이 멈춘 상태가 아니라면
        {
            // 회전
            _light.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
            // 한 프레임에 한 번만 실행
            yield return null;
        }
    }

    // 날씨 코루틴(인자로 날씨 관련 게임오브젝트)
    private IEnumerator WeatherCo(GameObject _weather)
    {
        // Snow or Rain 생성
        _weather.gameObject.SetActive(true);

        // 5분에서 10분 정도 랜덤 지속
        yield return new WaitForSeconds(Random.Range(5f, 10f));
    }

    // 온도 변화 메서드
    private void ChangeTemperature()
    {
        
    }

    // 토지 정화도 변화 메서드
    private void ChangeLandLevel()
    {

    }

    // 행성 산소량 변화 메서드
    private void ChangeOxygen()
    {

    }
}