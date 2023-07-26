using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_control : MonoBehaviour
{
    //Spawn 지점을 저장할 변수
    public Transform[] Spawn_point;

    //Spawn 시간을 설정할 변수
    float Timer;




    private void Awake() {

        //Children, 자식 개체들의 Transform components 를 가져오기
        //주의할 것은, 자기 자신의 Transform Component가 첫번째 idx로 들어간다
        //즉, Spawn_point[0] = Spawn_control의 Transform이 된다.
        Spawn_point = GetComponentsInChildren<Transform>();

    }
     

    // Update is called once per frame
    void Update()
    {
        //게속해서 시간을 더해주기, 시간이 지나면 지날수록 소환주기 빨라지게 하게끔
        Timer += Time.deltaTime;

        if (Timer > 0.2f) {
            Spwan();
            Timer = 0f;
        }


        
    }


    //Pools에 있는 Enemy를 랜덤으로 Spawn하는 함수
    void Spwan() {

        //PoolManager의 Get함수에서, Instantiate 한 값을 return 받는다.
        //그 Instantiate한 Unit을 Enemy에 저장한다. 
        GameObject Enemy =  GameManager.instance.Pool.Get(Random.Range(0, 2));

        //변수에 저장한 Instantiate 된 Unit의 좌표를 랜덤하게 변경해준다.
        Enemy.transform.position = Spawn_point[Random.Range(1, Spawn_point.Length)].position;

    }




}
