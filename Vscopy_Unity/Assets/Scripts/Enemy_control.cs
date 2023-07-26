using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_control : MonoBehaviour
{

    public float Enemy_speed;
    public Rigidbody2D Target_rb2;

    bool Live_dead = true;

    Rigidbody2D Rb2;
    SpriteRenderer Sprite;


    private void Awake() {

        //Rigidbody 2d, Spriterenderer 가져오기
        Rb2 = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();


        
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



}
