using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Buliding : MonoBehaviour
{
    private bool _isBuilding;

    public List<GameObject> bulidObjects;

    ThirdPersonController ThirdPersonController;

    PlayerInput playerInput;
    
    public Camera mainCamera;

    private InputActionMap currentActionMap; // 현재 활성화된 액션 맵

    private GameObject buildingPrefab;
    public Material previewShader;

    private GameObject previewObject;
    private Material originalShader;

    private Material previewEnableShader;
    private Material previewUnenableShader;

    int groundLayer;
    int defaultLayer;
    int previewLayer;
    int buildObjLayer;

    int buildingLayer;

    bool build = false;

    Selector selector;

    int currIndex;
    int prevIndex;

    bool prevBuildEnable = false;
    bool buildEnable = false;

    [Tooltip("건설 오브젝트 돌릴 각도")]
    public float rotationAngle = 15f;
    float rotation;

    void Start()
    {
        ThirdPersonController = GetComponent<ThirdPersonController>();
        playerInput = GetComponent<PlayerInput>();
        selector = GetComponent<Selector>();

        groundLayer = LayerMask.NameToLayer("GROUND");
        defaultLayer = LayerMask.NameToLayer("Default");
        previewLayer = LayerMask.NameToLayer("PREVIEW");
        buildObjLayer = LayerMask.NameToLayer("BUILDOBJ");

        buildingLayer = 1 << groundLayer | 1 << buildObjLayer;

        mainCamera = Camera.main;

        previewEnableShader = Resources.Load<Material>("Materials/BuildingSystem/PreviewEnable");
        previewUnenableShader = Resources.Load<Material>("Materials/BuildingSystem/PreviewUnenable");

        if (previewEnableShader == null)
        {
            Debug.LogError("Failed to load material. Make sure the path is correct and the material is located in the Resources folder.");
        }
        else
        {
            Debug.Log("Material loaded successfully.");
        }

        if (previewUnenableShader == null)
        {
            Debug.LogError("Failed to load material. Make sure the path is correct and the material is located in the Resources folder.");
        }
        else
        {
            Debug.Log("Material loaded successfully.");
        }
    }

    private void Update()
    {
        prevIndex = currIndex;
        currIndex = selector.selectedIndex;
        if (bulidObjects.Count > currIndex)
            buildingPrefab = bulidObjects[currIndex];

        if (build && currIndex != prevIndex)
        {
            BuildObjectChange();
        }
        //print(currIndex);

        if (previewObject)
        {
            buildEnable = previewObject.GetComponent<PreviewCollision>().prewviewEnable;

            if (buildEnable)
            {
                previewShader = previewEnableShader;
            }

            else
            {
                previewShader = previewUnenableShader;
            }

            if (prevBuildEnable != buildEnable)
            {
                BuildObjectChange();
            }

            prevBuildEnable = buildEnable;
            //Debug.Log(prevBuildEnable);
            //Debug.Log(buildEnable);
        }

        
    }

    // 건축 모드 시 프리뷰 오브젝트의 메테리얼을 변경하는 함수 현재 previewShader 가 적용됨
    void BuildObjectChange()
    {
        if(previewObject) 
        {
            Destroy(previewObject);
        }
        
        if(bulidObjects.Count <= 0)
        {
            Debug.LogError("Buliding System Error !");
            return;
        }
        
        previewObject = Instantiate(buildingPrefab);

        previewObject.transform.rotation = Quaternion.Euler(0, rotation, 0);

        // 오브젝트의 셰이더를 미리보기 셰이더로 변경
        var renderer = previewObject.GetComponent<Renderer>();
        originalShader = renderer.material;
        renderer.material = previewShader;
        previewObject.GetComponent<BoxCollider>().isTrigger = true;
        previewObject.AddComponent<PreviewCollision>();
    }

    // B키에 바인딩 된 함수 건축 모드 전환 함수
    void OnBuliding()
    {
        _isBuilding = !_isBuilding;

        if (_isBuilding)
        {
            Cursor.lockState = CursorLockMode.Confined;
            playerInput.SwitchCurrentActionMap("BuildingSystem");

            BuildObjectChange();

            build = true;
            
            StartCoroutine(UpdatePreviewPosition());
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
            build = false;
            Destroy(previewObject);
        }
    }

    // 마우스 좌클릭에 바인딩 건축 모드에서 조건 체크 후 건설 함수 호출
    public void OnBuildingConfirm()
    {
        if (bulidObjects.Count <= 0)
        {
            Debug.LogError("Buliding System Error !");
            return;
        }

        if (buildEnable)
        {
            PlaceBuilding();
        }
    }

    // C 키에 바인딩 건축오브젝트 파괴
    void OnDestoryBuildObj()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitinfo, 50f, 1 << buildObjLayer))
        {
            Destroy(hitinfo.collider.gameObject);
        }
    }

    // E 키에 바인딩 건축 오브젝트 회전
    void OnChangRotation()
    {
        rotation = rotation + rotationAngle;
        previewObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    // 프리뷰 오브젝트 위치 재조정 함수
    IEnumerator UpdatePreviewPosition()
    {
        while(build)
        {
            // Raycast를 사용하여 월드 좌표를 계산
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, buildingLayer))
            {
                previewObject.transform.position = hitInfo.point;
            }
            yield return null;
        }
    }

    // 프리뷰 오브젝트의 메테리얼을 원상복구하여 생성하는 함수 // 건설 함수
    void PlaceBuilding()
    {
        previewObject.GetComponent<BoxCollider>().isTrigger = false;
        previewObject.GetComponent<Renderer>().material = originalShader;
        // 미리보기 오브젝트의 위치에 실제 건물 생성
        GameObject newObject = Instantiate(buildingPrefab, previewObject.transform.position, previewObject.transform.rotation);

        newObject.layer = buildObjLayer;

        previewObject.GetComponent<BoxCollider>().isTrigger = true;
        previewObject.GetComponent<Renderer>().material = previewShader;
    }
}
