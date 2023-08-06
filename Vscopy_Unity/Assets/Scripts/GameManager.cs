using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 사용? 자기 자신을 변수에 저장해, 다른곳에서 호출하게 함
    //메모리에 적재한다고 표현한다?
    public static GameManager instance;

    [Header("Single tone")]
    //GameManager에 다른 주요한 Unit?을 넣어서 GameManager에 접근하는 것으로
    //다른 것들에게도 접근 가능하게 함
    public PoolManager Pool;
    public Player_control Player;

    public LevelUpUI_control LevelUpUI;

    [Header("Player info")]
    //레벨, 킬 수, 현재 경험치, 각 레벨의 필요 경험치, 체력 변수
    public int Level = 0;
    public int Kills = 0;
    public int Exp = 0;
    public int[] Next_exp = {10, 30, 60, 100, 140, 200, 260};
    public int P_Current_hp;
    public int P_Max_hp;

    [Header("Game time")]
    public float Game_time;
    public float Max_game_time = 20f;

    public bool Pause;


    private void Awake() {
        
        instance = this;

    }

    


    // Start is called before the first frame update
    void Start()
    {
        //현재 체력을 최대 체력으로 초기화
        P_Current_hp = P_Max_hp;

        //LevelUpUI_control의 Select함수 실행, 0을 넣으면 기본 무기 Shovel 장착
        LevelUpUI.Select(0);

    }

    // Update is called once per frame
    void Update()
    {
        //Pause 상태라면, Update 함수를 돌지 않게 return해줌
        if (Pause) {
            return;
        }

        Game_time += Time.deltaTime;

        if (Game_time > Max_game_time) {

        }

    }

    //경험치 획득을 관리하는 함수
    public void Get_exp() {


        Exp += 1;

        //무한 레벨 업 기능을 위해, indexoutofrange 오류를 방지하고자 Mathf.Min 사용
        //Level이 Next_exp.Length 이상이 되도, Mathf.Min 에 의해 Netx_ext의 마지막 idx의 경험치 량으로 계산
        if(Exp == Next_exp[Mathf.Min(Level, Next_exp.Length - 1)]) {
            Level += 1;
            Exp = 0;

            //레벨업 시 능력 업그레이드를 선택하는 UI를 보여주는 함수
            //LevelUpUI_control에 있음
            LevelUpUI.Show_UI();
        }

    }


    //TimeScale을 통해 Unity 게임의 시간의 속도를 조절
    //게임의 시간을 멈추는 함수
    public void Stop_game() {
        
        //
        Pause = true;
        Time.timeScale = 0;


    }

    //게임의 시간을 다시 흐르게 하는 함수
    public void Resume_game() {

        Pause = false;
        Time.timeScale = 1;

    }


}
