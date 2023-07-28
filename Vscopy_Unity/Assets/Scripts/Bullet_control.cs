using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_control : MonoBehaviour
{ 
    //Bullet의 dmg를 저장할 변수
    public float Bullet_dmg;

    //Bullet의 Per, 관통 정도를 담당할 변수(근접무기는 항상 관통함)
    public int Per;


    //Bullet의 dmg, Per을 초기화시켜주는 함수
    public void Init(float Bullet_dmg, int Per) {

        //this를 통해 Init함수 외부의 변수에 접근
        this.Bullet_dmg = Bullet_dmg;

        this.Per = Per;


    }

















}
