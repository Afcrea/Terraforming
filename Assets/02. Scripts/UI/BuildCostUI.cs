using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCostUI : MonoBehaviour
{
    // 벽 소모 재화
    string wallCostText = "벽 돌 10 / 철 10 필요";
    public string WallCostText { get { return wallCostText; } }

    // 바닥 소모 재화
    string floorCostText = "바닥 돌 10 / 철 10 필요";
    public string FloorCostText { get { return floorCostText; } }

    // 산소 생성기 소모 재화
    string oxyMakerCostText = "산소생성기 돌 20 / 철 20 / 나무 20 필요";
    public string OxyMakerCostText { get { return oxyMakerCostText; } }

    // 물 생성기 소모 재화
    string waterMakerCostText = "물 생성기 돌 20 / 철 20 필요";
    public string WaterMakerCostText { get { return waterMakerCostText; } }

    // 급수기 소모 재화
    string waterSupplierCostText = "급수기 돌 20 / 철 10 필요";
    public string WaterSupplierCostText { get { return waterSupplierCostText; } }

    // 토지정화기 소모 재화
    string landCostText = "토지정화기 돌 20 / 철 20 필요";
    public string LandCostText { get { return landCostText; } }

    // 소모 재화 없음
    string notBuildItem = "선택된 건축물이 없습니다.";
    public string NotBuildItem { get {  return notBuildItem; } }
}