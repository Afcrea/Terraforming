using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //�ǹ� ���� ���� Prefab ���� ����
    GameObject oxyMaker = null;         //��� ������
    GameObject soilPuri = null;         //���� ��ȭ ��ġ
    GameObject waterMaker = null;       //�� ������
    GameObject waterSupplier = null;    //�޼���

    private ItemManager itemManager = null;

    Vector3 pos = Vector3.zero;

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        //������ �ǹ� ������Ʈ ������
        oxyMaker = Resources.Load<GameObject>("Prefabs/OxyMaker");
        soilPuri = Resources.Load<GameObject>("Prefabs/SoilPuri");
        waterMaker = Resources.Load<GameObject>("Prefabs/WaterMaker");
        waterSupplier = Resources.Load<GameObject>("Prefabs/WaterSupplier");

        //������ ��ġ ����
        //pos = ���콺 ��ġ? �÷��̾ ������ ��ġ?
    }

    public void BuildOxyMaker()
    {
        //��һ�����: ���� 20�� ö 20�� �� 20��
        if (itemManager.WoodCount >= 20 && itemManager.IronCount >= 20 && itemManager.StoneCount >= 20)
        {
            itemManager.WoodCount -= 20;
            itemManager.IronCount -= 20;
            itemManager.StoneCount -= 20;

            GameObject go = Instantiate(oxyMaker, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("��ġ�� �ʿ��� ��ᰡ �����մϴ�.");
        }
    }

    public void BuildSoilPuri()
    {
        //�����ȭ��: �� 20�� ö 20��
        if (itemManager.StoneCount >= 20 && itemManager.IronCount >= 20)
        {
            itemManager.StoneCount -= 20;
            itemManager.IronCount -= 20;

            GameObject go = Instantiate(soilPuri, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("��ġ�� �ʿ��� ��ᰡ �����մϴ�.");
        }
    }

    public void BuildWaterMaker()
    {
        //�� ������: �� 20�� ö 20��
        if (itemManager.StoneCount >= 20 && itemManager.IronCount >= 20)
        {
            itemManager.StoneCount -= 20;
            itemManager.IronCount -= 20;

            GameObject go = Instantiate(waterMaker, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("��ġ�� �ʿ��� ��ᰡ �����մϴ�.");
        }
    }

    public void BuildWaterSupplier()
    {
        //�޼���: �� 20�� ö 10��
        if (itemManager.StoneCount >= 20 && itemManager.IronCount >= 10)
        {
            itemManager.StoneCount -= 20;
            itemManager.IronCount -= 10;

            GameObject go = Instantiate(waterSupplier, pos, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("��ġ�� �ʿ��� ��ᰡ �����մϴ�.");
        }
    }
}