using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Tree : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;
    private PlanetManager planetManager;

    public bool isGathering = true;     //ä�� ���� ���� �Ǻ� ����
    GameObject seedlingPrefab;          //���� ������Ʈ

    [SerializeField]
    private float time = 0f;            //���� �� ��� �ð�
    private float grownTime = 600f;     //�� �����ϴ� ���� �ɸ��� �ð�

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        //������ PlanetManager ã�ƿ���
        planetManager = FindObjectOfType<PlanetManager>();
        if (planetManager == null)
        {
            Debug.LogError("PlanetManager is not found in the scene.");
        }
    }

    private void Start()
    {
        seedlingPrefab = Resources.Load<GameObject>("Prefabs/Seedling");

        if (!isGathering)   //�������� �ɾ��� ���� �ڶ󵵷�
        {
            StartCoroutine(GrowUp());
        }

        StartCoroutine(MakeOxygen());
    }

    public void Interact()
    {
        //Debug.Log("���ͷ�Ʈ ����");
        if (isGathering)
        {
            //ä�� �ڷ�ƾ ����
            StartCoroutine(Gathering());
        }
    }

    //ä��
    private IEnumerator Gathering()
    {
        //���� 1�� ���� 3�� ȹ��
        itemManager.WoodCount += 3;

        //���� ������ ��� ����
        Instantiate(seedlingPrefab, this.transform.position, this.transform.rotation);

        //�� ������Ʈ �ı�
        Destroy(this.gameObject);

        yield return null;
    }

    //���� �ڷ�ƾ
    //�ܰ迡 ���� ������ ����
    private IEnumerator GrowUp()
    {
        while (time <= grownTime)
        {
            yield return new WaitForSeconds(0.000001f);     //������ ��
            time += (Time.deltaTime * planetManager.growthSpeed);
        }

        //�� ������ ���� ũ��� Ű��� ä���� �����ϰ� �� 
        this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        isGathering = true;

        yield return null;
    }

    //�Ϸ� ������ 0.01��ŭ ��� ����
    private IEnumerator MakeOxygen()
    {
        while (this.gameObject)
        {
            yield return new WaitForSeconds(600);
            planetManager.oxygenLevel += 0.01f;
            //Debug.Log("������ ��� ����� ��");
        }
    }
}