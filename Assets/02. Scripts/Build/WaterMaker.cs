using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//�� ������
public class WaterMaker : MonoBehaviour, IBuild
{
    private void Start()
    {
        ItemManager.Instance.waterMakerCnt++;       //���� �� �ʿ� �ִ� WaterMaker ���� �ľ�
    }

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    public void Demolish()
    {
        //�� ������: �� 20�� ö 20��
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 20;

        Destroy(this.gameObject);
    }

    private void OnDisable()
    {
        ItemManager.Instance.waterMakerCnt--;
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