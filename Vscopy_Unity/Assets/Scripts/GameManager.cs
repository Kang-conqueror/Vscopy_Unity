using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 사용? 자기 자신을 변수에 저장해, 다른곳에서 호출하게 함
    //메모리에 적재한다고 표현한다?
    public static GameManager instance;

    //GameManager에 다른 주요한 Unit?을 넣어서 GameManager에 접근하는 것으로
    //다른 것들에게도 접근 가능하게 함
    public PoolManager Pool;
    public Player_control Player;


    public float Game_time;
    public float Max_game_time = 20f;


    private void Awake() {
        
        instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Game_time += Time.deltaTime;

        if (Game_time > Max_game_time) {

        }

        
    }
}
