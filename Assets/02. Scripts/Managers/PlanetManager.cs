using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    Light lightMain = null; // �� ������Ʈ ���� ����
    float rotateSpeed = 0.01f; // ȸ���ӵ� �ʴ� 0.01(= (360(����) / 600(10��)) / 60(������)) -> 10�п� �ѹ���

    // �༺ ����
    [HideInInspector]
    public float temperature = 0f;
    float oxygenLevel = 0f;
    int landLevel = 1;
    bool isWater = false; // �༺�� �� ���� ����

    // ���� ���� ������Ʈ ��������
    Rain rain = null;
    Snow snow = null;

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

        // �༺ ���� �������� ���ϱ�
        temperature = Random.Range(-30f, 100f);
        landLevel = Random.Range(1, 3);
        oxygenLevel = Random.Range(0f, 30f);

        // UIManager ��������
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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

        if (isWater) // ���� ���� �� ��
        {
            if (temperature > 0) // ����
            {
                // �� ������ �ϱ�
                StartCoroutine(WeatherCo(rain.gameObject));
            }
            else if (temperature <= 0) // ����
            {
                // �� ������ �ϱ�
                StartCoroutine(WeatherCo(snow.gameObject));
            }
        }
    }

    // �� ȸ��(�ð� ����) �ڷ�ƾ
    private IEnumerator RotateLightCo(Light _light)
    {
        while (!uiManager.isPaused) // ������ ���� ���°� �ƴ϶��
        {
            // ȸ��
            _light.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
            // �� �����ӿ� �� ���� ����
            yield return null;
        }
    }

    // ���� �ڷ�ƾ(���ڷ� ���� ���� ���ӿ�����Ʈ)
    private IEnumerator WeatherCo(GameObject _weather)
    {
        // Snow or Rain ����
        _weather.gameObject.SetActive(true);

        // 5�п��� 10�� ���� ���� ����
        yield return new WaitForSeconds(Random.Range(5f, 10f));
    }

    // �µ� ��ȭ �޼���
    private void ChangeTemperature()
    {
        
    }

    // ���� ��ȭ�� ��ȭ �޼���
    private void ChangeLandLevel()
    {

    }

    // �༺ ��ҷ� ��ȭ �޼���
    private void ChangeOxygen()
    {

    }
}