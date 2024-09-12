using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCostUI : MonoBehaviour
{
    // �� �Ҹ� ��ȭ
    string wallCostText = "�� �� 10 / ö 10 �ʿ�";
    public string WallCostText { get { return wallCostText; } }

    // �ٴ� �Ҹ� ��ȭ
    string floorCostText = "�ٴ� �� 10 / ö 10 �ʿ�";
    public string FloorCostText { get { return floorCostText; } }

    // ��� ������ �Ҹ� ��ȭ
    string oxyMakerCostText = "��һ����� �� 20 / ö 20 / ���� 20 �ʿ�";
    public string OxyMakerCostText { get { return oxyMakerCostText; } }

    // �� ������ �Ҹ� ��ȭ
    string waterMakerCostText = "�� ������ �� 20 / ö 20 �ʿ�";
    public string WaterMakerCostText { get { return waterMakerCostText; } }

    // �޼��� �Ҹ� ��ȭ
    string waterSupplierCostText = "�޼��� �� 20 / ö 10 �ʿ�";
    public string WaterSupplierCostText { get { return waterSupplierCostText; } }

    // ������ȭ�� �Ҹ� ��ȭ
    string landCostText = "������ȭ�� �� 20 / ö 20 �ʿ�";
    public string LandCostText { get { return landCostText; } }

    // �Ҹ� ��ȭ ����
    string notBuildItem = "���õ� ���๰�� �����ϴ�.";
    public string NotBuildItem { get {  return notBuildItem; } }
}