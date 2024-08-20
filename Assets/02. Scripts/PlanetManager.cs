//using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    Light lightMain = null; // �� ������Ʈ ���� ����
    float rotateSpeed = 0.6f; // ȸ���ӵ� �ʴ� 0.6(= 360 / 600) -> 10�п� �ѹ���

    //RainScript rain = null; // �� ����Ʈ ���� ����
    bool isRain = false; // �� ������ ���� �Ǵ��� ����

    private void Awake()
    {
        // �� ������Ʈ ��������
        lightMain = GetComponentInChildren<Light>();

        // �� ����Ʈ ��������
        //rain = GetComponentInChildren<RainScript>();
        // �� ����Ʈ ���α�
        //rain.gameObject.SetActive(false);
    }

    private void Start()
    {
        // �� ȸ�� �ڷ�ƾ ����
        StartCoroutine(RotateLightCo(lightMain));
    }

    private void Update()
    {
        // �� �����Ⱑ true�� �� �ڷ�ƾ ����
        if (isRain)
        {
            //StartCoroutine(RainCo(rain));
        }
    }

    // �� ȸ��(�ð� ����) �ڷ�ƾ
    private IEnumerator RotateLightCo(Light _light)
    {
        while (true) // true ���� ������ �������� ���������� �����ؾ� ��
        {
            // 1�� ���
            yield return new WaitForSeconds(1f);
            // ȸ��
            _light.transform.Rotate(new Vector3(rotateSpeed, 0, 0));
            // �� �����ӿ� �� ���� ����
            yield return null;
        }
    }

    // �� �ڷ�ƾ
    //private IEnumerator RainCo(RainScript _rain)
    //{
    //    // �� ������ �ϱ�
    //    _rain.gameObject.SetActive(true);
    //    // �� ���� �������� �ٲٱ�
    //    _rain.RainIntensity = Random.Range(0.5f, 1f);

    //    // ���� ���ӽð� ���� �񳻸��� �ϱ�
    //    yield return new WaitForSeconds(Random.Range(300f, 600f));

    //    // �� ���ӽð��� ������ ���߰� �ϱ�
    //    _rain.gameObject.SetActive(false);
    //    // �� ������ false�� ����
    //    isRain = false;
    //}
}