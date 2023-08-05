using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_control : MonoBehaviour
{
    //좌우 확인을 위한 bool 변수
    public bool Is_left;

    //Player와 Hand의 Sprite를 저장할 변수
    public SpriteRenderer Sprite;

    SpriteRenderer Player;

    //Vector3 Righthand_pos = new Vector3

    
    private void Awake() {
        
        //GetComponentsInParent는 자기 자신이 첫번째로 들어가니, 0대신 1로 idx 접근
        Player = GetComponentsInParent<SpriteRenderer>()[1];

    }




}
