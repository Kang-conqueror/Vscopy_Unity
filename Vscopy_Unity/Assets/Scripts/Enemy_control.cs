using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_control : MonoBehaviour
{
    //이동속도를 담을 변수
    public float Enemy_speed;

    //현재 체력, 최대 체력을 담을 변수
    public float Current_hp;

    public float Max_hp;

    //Animator을 받을 변수
    public RuntimeAnimatorController[] Run_ani_con; 

    //Player의 Rigidbody 2d를 받을 변수
    public Rigidbody2D Target_rb2;

    //Unit의 생존, 사망을 확인할 Bool 변수
    bool Live_dead;

    //Rigidbody 2d, Spriterenderer을 받을 변수
    Rigidbody2D Rb2;
    SpriteRenderer Sprite;

    Animator Anim;


    private void Awake() {

        //Rigidbody 2d, Spriterenderer 가져오기
        Rb2 = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        
    }


    //이동을 Fixedupdate로 구현
    private void FixedUpdate() {

        //죽었을 시, return 시켜서 아래 이동 코드를 안따라가게 함
        if (!Live_dead){
            return;
        }
        
        //Target에서 자신의 위치를 빼, Target을 향한 벡터 구성
        Vector2 Direction_vec = Target_rb2.position - Rb2.position;
        Vector2 N_vec = Direction_vec.normalized * Enemy_speed;

        Rb2.velocity = N_vec;

    }

    private void LateUpdate() {
        
        //Target의 x좌표가 자신의 x좌표보다 작으면, flipx를 통해 세로선 기준 뒤집기
        Sprite.flipX = Target_rb2.position.x < Rb2.position.x;

    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {   
        //Prefab은 활성화되지 않은 상태이기에, Scene의 Unit에 접근할 수 없다.
        //OnEnable로 Unit이 Enable되었을 때, GamaManager에 접근해 Player의 정보 가져오기
        Target_rb2 = GameManager.instance.Player.GetComponent<Rigidbody2D>();

        //Object Pooling으로 Unit을 계속 재활용하며 사용할 것이기에, OnEnable시
        //Live를 true로 해준다.
        Live_dead = true;

        //위와 같은 이유로, 사망 후 Disable 되었으면 체력이 0 이하일 것이기에
        //체력을 최대체력으로 설정해준다
        Current_hp = Max_hp;

    }

    //Enemy의 data를 가져오는 함수를 생성, Spawn_data class를 통째로 가져오기
    public void Get_data(Spawn_data data) {

        Anim.runtimeAnimatorController = Run_ani_con[data.Sprite_type];

        Enemy_speed = data.E_speed;

        Current_hp = data.Hp;
        Max_hp = data.Hp;


    }

}
