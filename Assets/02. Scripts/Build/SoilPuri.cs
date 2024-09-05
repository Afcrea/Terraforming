using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ȭ��
public class SoilPuri : MonoBehaviour, IBuild
{
    private PlanetManager planetManager = null;

    private void Awake()
    {
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
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 20;

        //�ǹ� �μ���
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //���� ���߱�
        planetManager.LandLevel--;
    }


    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuildCost()
    {
        ItemManager.Instance.StoneCount -= 20;
        ItemManager.Instance.IronCount -= 20;
    }
}