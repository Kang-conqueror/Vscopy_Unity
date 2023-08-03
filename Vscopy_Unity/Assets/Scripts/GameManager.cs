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


    private void Awake() {
        
        instance = this;

    }

    


    // Start is called before the first frame update
    void Start()
    {
        P_Current_hp = P_Max_hp;
    }

    // Update is called once per frame
    void Update()
    {

        Game_time += Time.deltaTime;

        if (Game_time > Max_game_time) {

        }

    }

    //경험치 획득을 관리하는 함수
    public void Get_exp() {


        Exp += 1;

        if(Exp == Next_exp[Level] && Level <= Next_exp.Length) {
            Level += 1;
            Exp = 0;



        }


    }






}
