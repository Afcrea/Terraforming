using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    Light lightMain = null; // �� ������Ʈ ���� ����
    float rotateSpeed = 90f; // �� ȸ���ӵ�

    // �༺ ����
    // ���
    [HideInInspector]
    public float temperature = 0f;
    // �༺ �� ��ҷ�
    [HideInInspector]
    public float oxygenLevel = 0f;
    // ���� ����
    [HideInInspector]
    public int landLevel = 1;
    // �༺�� �� ���� ����
    [HideInInspector]
    public bool isWater = false; 

    // ���� ���� ������Ʈ ��������
    Rain rain = null; // ��
    Snow snow = null; // ��

    float rainTrigger = 0;
    float snowTrigger = 0;

    // UIManager ��������
    UIManager uiManager = null;

    private void Awake()
    {
        // �� ������Ʈ ��������
        lightMain = GetComponentInChildren<Light>();

        // ��, �� ��������
        rain = GetComponentInChildren<Rain>();
        snow = GetComponentInChildren<Snow>();
        // ó���� ��, �� �ȳ����� �ϱ�
        rain.gameObject.SetActive(false);
        snow.gameObject.SetActive(false);

        // UIManager ��������
        uiManager = GameObject.FindWithTag("UIMANAGER").GetComponent<UIManager>();

        // ��, �� Ʈ���� �� �������� ���ϱ� (0 ~ 1 ����)
        rainTrigger = Random.Range(0f, 1f);
        snowTrigger = Random.Range(0f, 1f);
    }

    private void Start()
    {
        // �� ȸ�� �ڷ�ƾ ����
        StartCoroutine(RotateLightCo(lightMain));
    }

    private void Update()
    {
        ChangeTemperature();
        ChangeLandLevel();
        ChangeOxygen();
        PlanetWeather();
    }

    // �� ȸ��(�ð� ����) �ڷ�ƾ
    private IEnumerator RotateLightCo(Light _light)
    {
        while (!uiManager.isPaused) // ������ ���� ���°� �ƴ϶��
        {
            // 2�� 30�� ���� ����
            yield return new WaitForSeconds(150f);

            // �� 90�� ȸ��
            _light.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
        }
    }

    // ���� �ڷ�ƾ(���ڷ� ���� ���� ���ӿ�����Ʈ)
    private IEnumerator WeatherCo(GameObject _weather)
    {
        // Snow or Rain Ȱ��ȭ
        _weather.gameObject.SetActive(true);

        // 5�п��� 10�� ���� ���� ����
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        // Snow or Rain ��Ȱ��ȭ
        _weather.gameObject.SetActive(false);
    }

    // �༺ ���� ���� �޼���
    private void PlanetWeather()
    {
        if (isWater) // ���� ���� �� ��
        {
            if (temperature > 0) // ����
            {
                if (rainTrigger >= 0.7f) // Ʈ���Ű� 0.7 �̻��� ��
                {
                    // �� ������ �ϱ�
                    StartCoroutine(WeatherCo(rain.gameObject));
                    rainTrigger = 0;
                }
                else // �� �ȳ��� ���
                {
                    if (rain.gameObject.activeSelf == false) // �� ������Ʈ�� ��Ȱ��ȭ ������ ��
                    {
                        rainTrigger = Random.Range(0f, 1f);
                    }
                }
            }
            else if (temperature <= 0) // ����
            {
                if (snowTrigger >= 0.7f) // Ʈ���Ű� 0.7 �̻��� ��
                {
                    // �� ������ �ϱ�
                    StartCoroutine(WeatherCo(snow.gameObject));
                    snowTrigger = 0;
                }
                else // ���� �ȳ��� ���
                {
                    if (snow.gameObject.activeSelf == false) // �� ������Ʈ�� ��Ȱ��ȭ ������ ��
                    {
                        snowTrigger = Random.Range(0f, 1f);
                    }
                }
            }
        }
    }

    // �µ� ��ȭ �޼���
    private void ChangeTemperature()
    {
        // �� ����, ���� ��ȭ���� ���� �µ� ��ȭ -> 20�� ������ �ٲ��
    }

    // ���� ��ȭ�� ��ȭ �޼���
    private void ChangeLandLevel()
    {
        // ���� ��ȭ�� 1���� ��ȭ�� 1 ����
    }

    // �༺ ��ҷ� ��ȭ �޼���
    private void ChangeOxygen()
    {
        // ��� ������ ���� �� 15�� ���� ��� 1�� ����
    }
}