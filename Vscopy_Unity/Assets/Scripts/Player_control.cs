using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    //Scanner_control Script를 받을 변수
    public Scanner_control Scanner_Control;



    //키보드 입력의 벡터를 받을 변수
    public Vector2 Input_vec;

    //Rigidbody 2d component, Spriterenderer를 받을 변수
    public Rigidbody2D Rb2;
    private SpriteRenderer Sprite;

    //Animator 받을 변수
    private Animator Ani;

    //이동속도 변수
    public float Player_speed;




    private void Awake() {
        
        Rb2 = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();
        Scanner_Control = GetComponent<Scanner_control>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //좌우, 상하 Input값 받아서 벡터에 넣기
        Input_vec.x = Input.GetAxisRaw("Horizontal");
        Input_vec.y = Input.GetAxisRaw("Vertical");

        
    }

    //고정된 시간마다 작동하는, FixedUpdate로 이동을 구현
    private void FixedUpdate() {
        

        Rb2.velocity = Input_vec.normalized * Player_speed;




    }

    //매 프레임 종료 후에 작동되는 LateUpdate
    private void LateUpdate() {
        
        //SetFloat로 벡터의 magnitued, 벡터의 길이 전달해주기
        Ani.SetFloat("Speed", Input_vec.magnitude);


        //이동중이고, 좌측 이동이라면
        if (Input_vec.x != 0 ) {

            //flipx를 True로 해주어, 캐릭터를 뒤집어준다
            Sprite.flipX = Input_vec.x < 0;

        }



    }









}
