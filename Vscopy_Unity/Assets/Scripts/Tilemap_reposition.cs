using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap_reposition : MonoBehaviour
{
     
    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        //Area와 충돌이 아니라면, 그냥 retur해서 아래 코드 실행 안시키게
        if (!other.CompareTag("Area")) {

            return;
        }

        //Player의 좌표와, Tilemap의 좌표 
        Vector3 Player_pos = GameManager.instance.Player.transform.position;
        Vector3 Tilemap_pos = transform.position;


        //Player와 Tile맵의 x, y 거리 차이 계산
        float Difference_x = Mathf.Abs(Player_pos.x - Tilemap_pos.x);
        float Difference_y = Mathf.Abs(Player_pos.y - Tilemap_pos.y);


        Vector3 Player_dir = GameManager.instance.Player.Input_vec;

        //삼향 연산자를 통해, Input_vec의 방향에 따라 x, y의 이동방향을 +-1로 설정해줌
        float x_dir = Player_dir.x < 0 ? -1 : 1;
        float y_dir = Player_dir.y < 0 ? -1 : 1;


        //이 함수의 tag에 따라 로직 변경
        switch (transform.tag) {

            case "Map":

                // if (Difference_x > Difference_y) {
                //     transform.Translate(Vector3.right * x_dir  )
                // }
                break;



            case "Enemy":

                break;
        }

    }






}
