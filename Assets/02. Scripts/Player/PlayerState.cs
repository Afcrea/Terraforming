using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //�÷��̾� ���� enum
    public enum PLAYERSTATECHECK
    {
        ALIVE,
        HEAL,       //HP ȸ��
        DAMAGE,     //HP ����
        DIE
    }

    //�׽�Ʈ �ð� ���� ���� ����
    private float seconds = 1f;

    //�÷��̾� �⺻ ����
    PLAYERSTATECHECK playerStateCheck = PLAYERSTATECHECK.ALIVE;

    //�÷��̾� ���� �Ӽ���
    //�÷��̾� ���� ���� 
    private bool playerAlive = true;
    public bool PlayerAlive {  get { return playerAlive; } }

    //�÷��̾� ü�� ����
    [SerializeField]
    private int playerCurrHp = 10;
    //public int PlayerCurrHp { get => playerCurrHp; set => playerCurrHp = value; }
    private int playerInitHp = 10;
    [HideInInspector]
    public float playerHpUI = 1;        //UI ǥ�� ���� ����

    //�÷��̾� ������
    [SerializeField]
    private int playerCurrFull = 100;   //���� ������
    public int PlayerCurrFull { get => playerCurrFull; set => playerCurrFull = value; }
    private int playerInitFull = 100;   //�ִ� ������
    public int PlayerInitFull => playerInitFull;
    [HideInInspector]
    public float playerFullUI = 1;      //UI ǥ�� ���� ����

    //�÷��̾� ü�� ���з�
    [SerializeField]
    private int playerCurrWater = 100;  //���� ���з�
    public int PlayerCurrWater { get => playerCurrWater; set => playerCurrWater = value; }
    private int playerInitWater = 100;  //�ִ� ���з�
    public int PlayerInitWater => playerInitWater;
    [HideInInspector]
    public float playerWaterUI = 1;     //UI ǥ�� ���� ����

    //�÷��̾� ��� ������
    [SerializeField]
    private int playerCurrOxygen = 100; //���� ��ҷ�
    public int PlayerCurrOxygen { get => playerCurrOxygen; set => playerCurrOxygen = value; }
    private int playerInitOxygen = 100; //�ִ� ��ҷ�
    public int PlayerInitOxygen => playerInitOxygen;
    [HideInInspector]
    public float playerOxygenUI = 1;    //UI ǥ�� ���� ����

    //�÷��̾� ���� ���� ���� �Ǵ�
    private bool isWorse = false;       // ���� ü�� ���� ������
    private bool isBetter = false;      // ���� ü�� ȸ�� ������

    // �÷��̾� �ִϸ����� ��������
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

    //10�� ������ => ������ ����
    private IEnumerator Hungry()
    {
        while (playerAlive)     //����ִ� ���� �ݺ�
        {
            yield return new WaitForSeconds(10f * seconds);
            playerCurrFull--;

            //�÷��̾� �������� 0 ���ϸ� 0���� ����
            playerCurrFull = (playerCurrFull > 0) ? playerCurrFull : 0;
            //�÷��̾� �������� �ִ�ġ �̻����� �ö󰡸� �ִ�ġ�� ����
            playerCurrFull = (playerCurrFull > playerInitFull) ? playerInitFull : playerCurrFull;
        }
    }

    //10�� ������ => ü�� ���� ����
    private IEnumerator Thirsty()
    {
        while (playerAlive)
        {
            yield return new WaitForSeconds(10f * seconds);
            playerCurrWater--;

            //�÷��̾� ���а��� 0 ���ϸ� 0���� ����
            playerCurrWater = (playerCurrWater > 0) ? playerCurrWater : 0;
            //�÷��̾� ���а��� �ִ�ġ �̻����� �ö󰡸� �ִ�ġ�� ����
            playerCurrWater = (playerCurrWater > playerInitWater) ? playerInitWater : playerCurrWater;
        }
    }

    //15�� ������ => ���� ��ҷ� ����
    private IEnumerator Breath()
    {
        while (playerAlive)
        {
            yield return new WaitForSeconds(15f * seconds);
            playerCurrOxygen--;

            //�÷��̾� ��ҷ��� 0 ���ϸ� 0���� ����
            playerCurrOxygen = (playerCurrOxygen > 0) ? playerCurrOxygen : 0;
            //�÷��̾� ��ҷ��� �ִ�ġ �̻����� �ö󰡸� �ִ�ġ�� ����
            playerCurrOxygen = (playerCurrOxygen > playerInitOxygen) ? playerInitOxygen : playerCurrOxygen;
        }
    }

    //�Ӽ� �� �ϳ��� 0 ���ϸ� => ü�� ����
    private IEnumerator GetWorse()
    {
        while (playerAlive)
        {
            //ü�� ���� ������ ��
            if (isWorse)
            {
                yield return new WaitForSeconds(60f * seconds);
                playerCurrHp--;
            }
            else
            {
                //�̹� �����ӿ� �ڷ�ƾ ���
                yield return null;
            }
        }
    }

    //�÷��̾� ���� �Ӽ� �� �� 70 �̻����� �����ϸ� => ü�� ȸ��
    private IEnumerator GetBetter()
    {
        while (playerAlive)
        {
            //ü�� ȸ�� ������ ��
            if (isBetter)
            {
                yield return new WaitForSeconds(60f * seconds);
                playerCurrHp++;
            }
            else
            {
                //�̹� �����ӿ� �ڷ�ƾ ���
                yield return null;
            }
        }
    }

    //�÷��̾� ���� üũ
    private void PlayerStateChecker()
    {
        //ü���� 0 ���ϸ� ��� ����
        if (playerCurrHp <= 0)
        {
            playerStateCheck = PLAYERSTATECHECK.DIE;
        }
        //�Ӽ����� 70 �̻��̸� ü�� ȸ�� ����
        else if (playerCurrFull >= 70 && playerCurrWater >= 70 && playerCurrOxygen >= 70)
        {
            playerStateCheck = PLAYERSTATECHECK.HEAL;
        }
        //�Ӽ� �� �ϳ��� 0 ���ϸ� ü�� ���� ����
        else if (playerCurrFull <= 0 || playerCurrWater <= 0 || playerCurrOxygen <= 0)
        {
            playerStateCheck = PLAYERSTATECHECK.DAMAGE;
        }
        //�װ� �ƴ϶�� �⺻ ����
        else
        {
            playerStateCheck = PLAYERSTATECHECK.ALIVE;
        }
    }

    //�÷��̾� ���� �ٲٱ�
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
                isBetter = true;        //ü�� ȸ��
                break;
            case PLAYERSTATECHECK.DAMAGE:
                playerAlive = true;
                isWorse = true;         //ü�� ����
                isBetter = false;
                break;
            case PLAYERSTATECHECK.DIE:
                playerAlive = false;    //���
                isWorse = false;
                isBetter = false;
                animator.SetTrigger("IsDie");
                break;
        }
    }

    //UI���� üũ�� ��
    public void PlayerStateUICheck()
    {
        playerHpUI = (float)playerCurrHp / (float)playerInitHp;
        playerFullUI = (float)playerCurrFull / (float)playerInitFull;
        playerWaterUI = (float)playerCurrWater / (float)playerInitWater;
        playerOxygenUI = (float)playerCurrOxygen / (float)playerInitOxygen;
    }
}