using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //플레이어 상태 enum
    public enum PLAYERSTATECHECK
    {
        ALIVE,
        HEAL,       //HP 회복
        DAMAGE,     //HP 감소
        DIE
    }

    //테스트 시간 조절 위한 변수
    private float seconds = 1f;

    //플레이어 기본 상태
    PLAYERSTATECHECK playerStateCheck = PLAYERSTATECHECK.ALIVE;

    //플레이어 상태 속성값
    //플레이어 생존 여부 
    private bool playerAlive = true;
    public bool PlayerAlive {  get { return playerAlive; } }

    //플레이어 체력 관련
    [SerializeField]
    private int playerCurrHp = 10;
    //public int PlayerCurrHp { get => playerCurrHp; set => playerCurrHp = value; }
    private int playerInitHp = 10;
    [HideInInspector]
    public float playerHpUI = 1;        //UI 표시 위한 변수

    //플레이어 포만감
    [SerializeField]
    private int playerCurrFull = 100;   //현재 포만감
    public int PlayerCurrFull { get => playerCurrFull; set => playerCurrFull = value; }
    private int playerInitFull = 100;   //최대 포만감
    public int PlayerInitFull => playerInitFull;
    [HideInInspector]
    public float playerFullUI = 1;      //UI 표시 위한 변수

    //플레이어 체내 수분량
    [SerializeField]
    private int playerCurrWater = 100;  //현재 수분량
    public int PlayerCurrWater { get => playerCurrWater; set => playerCurrWater = value; }
    private int playerInitWater = 100;  //최대 수분량
    public int PlayerInitWater => playerInitWater;
    [HideInInspector]
    public float playerWaterUI = 1;     //UI 표시 위한 변수

    //플레이어 산소 보유량
    [SerializeField]
    private int playerCurrOxygen = 100; //현재 산소량
    public int PlayerCurrOxygen { get => playerCurrOxygen; set => playerCurrOxygen = value; }
    private int playerInitOxygen = 100; //최대 산소량
    public int PlayerInitOxygen => playerInitOxygen;
    [HideInInspector]
    public float playerOxygenUI = 1;    //UI 표시 위한 변수

    //플레이어 상태 변경 여부 판단
    private bool isWorse = false;       // 지금 체력 감소 중인지
    private bool isBetter = false;      // 지금 체력 회복 중인지

    // 플레이어 애니메이터 가져오기
    Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Hungry());
        StartCoroutine(Thirsty());
        StartCoroutine(Breath());
        StartCoroutine(GetWorse());
        StartCoroutine(GetBetter());
    }

    private void Update()
    {
        if (playerCurrHp >= playerInitHp)
        {
            playerCurrHp = playerInitHp;
        }

        PlayerStateChecker();
        PlayerStateChanger();
        PlayerStateUICheck();
    }

    //10초 지나면 => 포만감 감소
    private IEnumerator Hungry()
    {
        while (playerAlive)     //살아있는 동안 반복
        {
            yield return new WaitForSeconds(10f * seconds);
            playerCurrFull--;

            //플레이어 포만감이 0 이하면 0으로 고정
            playerCurrFull = (playerCurrFull > 0) ? playerCurrFull : 0;
            //플레이어 포만감이 최대치 이상으로 올라가면 최대치로 고정
            playerCurrFull = (playerCurrFull > playerInitFull) ? playerInitFull : playerCurrFull;
        }
    }

    //10초 지나면 => 체내 수분 감소
    private IEnumerator Thirsty()
    {
        while (playerAlive)
        {
            yield return new WaitForSeconds(10f * seconds);
            playerCurrWater--;

            //플레이어 수분감이 0 이하면 0으로 고정
            playerCurrWater = (playerCurrWater > 0) ? playerCurrWater : 0;
            //플레이어 수분감이 최대치 이상으로 올라가면 최대치로 고정
            playerCurrWater = (playerCurrWater > playerInitWater) ? playerInitWater : playerCurrWater;
        }
    }

    //15초 지나면 => 보유 산소량 감소
    private IEnumerator Breath()
    {
        while (playerAlive)
        {
            yield return new WaitForSeconds(15f * seconds);
            playerCurrOxygen--;

            //플레이어 산소량이 0 이하면 0으로 고정
            playerCurrOxygen = (playerCurrOxygen > 0) ? playerCurrOxygen : 0;
            //플레이어 산소량이 최대치 이상으로 올라가면 최대치로 고정
            playerCurrOxygen = (playerCurrOxygen > playerInitOxygen) ? playerInitOxygen : playerCurrOxygen;
        }
    }

    //속성 중 하나라도 0 이하면 => 체력 감소
    private IEnumerator GetWorse()
    {
        while (playerAlive)
        {
            //체력 감소 상태일 때
            if (isWorse)
            {
                yield return new WaitForSeconds(60f * seconds);
                playerCurrHp--;
            }
            else
            {
                //이번 프레임에 코루틴 대기
                yield return null;
            }
        }
    }

    //플레이어 상태 속성 셋 다 70 이상으로 유지하면 => 체력 회복
    private IEnumerator GetBetter()
    {
        while (playerAlive)
        {
            //체력 회복 상태일 때
            if (isBetter)
            {
                yield return new WaitForSeconds(60f * seconds);
                playerCurrHp++;
            }
            else
            {
                //이번 프레임에 코루틴 대기
                yield return null;
            }
        }
    }

    //플레이어 상태 체크
    private void PlayerStateChecker()
    {
        //체력이 0 이하면 사망 상태
        if (playerCurrHp <= 0)
        {
            playerStateCheck = PLAYERSTATECHECK.DIE;
        }
        //속성들이 70 이상이면 체력 회복 상태
        else if (playerCurrFull >= 70 && playerCurrWater >= 70 && playerCurrOxygen >= 70)
        {
            playerStateCheck = PLAYERSTATECHECK.HEAL;
        }
        //속성 중 하나라도 0 이하면 체력 감소 상태
        else if (playerCurrFull <= 0 || playerCurrWater <= 0 || playerCurrOxygen <= 0)
        {
            playerStateCheck = PLAYERSTATECHECK.DAMAGE;
        }
        //그게 아니라면 기본 상태
        else
        {
            playerStateCheck = PLAYERSTATECHECK.ALIVE;
        }
    }

    //플레이어 상태 바꾸기
    private void PlayerStateChanger()
    {
        switch (playerStateCheck)
        {
            case PLAYERSTATECHECK.ALIVE:
                playerAlive = true;
                isWorse = false;
                isBetter = false;
                break;
            case PLAYERSTATECHECK.HEAL:
                playerAlive = true;
                isWorse = false;
                isBetter = true;        //체력 회복
                break;
            case PLAYERSTATECHECK.DAMAGE:
                playerAlive = true;
                isWorse = true;         //체력 감소
                isBetter = false;
                break;
            case PLAYERSTATECHECK.DIE:
                playerAlive = false;    //사망
                isWorse = false;
                isBetter = false;
                animator.SetTrigger("IsDie");
                break;
        }
    }

    //UI에서 체크할 값
    public void PlayerStateUICheck()
    {
        playerHpUI = (float)playerCurrHp / (float)playerInitHp;
        playerFullUI = (float)playerCurrFull / (float)playerInitFull;
        playerWaterUI = (float)playerCurrWater / (float)playerInitWater;
        playerOxygenUI = (float)playerCurrOxygen / (float)playerInitOxygen;
    }
}