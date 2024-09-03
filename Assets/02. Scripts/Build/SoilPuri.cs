using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ȭ��
public class SoilPuri : MonoBehaviour, IDemolish
{
    private ItemManager itemManager = null;
    private PlanetManager planetManager = null;

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
        //�ǹ� ���� ������ ���� �ø���
        planetManager.LandLevel++;
    }

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    public void Demolish()
    {
        //�����ȭ��: �� 20�� ö 20��
        itemManager.StoneCount += 20;
        itemManager.IronCount += 20;

        //�ǹ� �μ���
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //���� ���߱�
        planetManager.LandLevel--;
    }
}