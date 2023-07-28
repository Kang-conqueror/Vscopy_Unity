using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_control : MonoBehaviour
{
    //무기의 Id, Prefab Id, dmg, 갯수, 속도를 저장할 변수
    public int Id;

    public int Prefabs_idx;

    public float Weapon_dmg;

    public float Count;

    public float Weapon_speed;

    //근접 무기의 경우, Player와 떨어진 거리를 저장할 변수
    public float Weapon_distance = 0.15f;


    private void Start() {
        
        Init();

    }



    // Update is called once per frame
    void Update()
    {
        
        switch (Id) {

            //근접무기일 경우, 회전시켜주자
            case 0:
                
                //Weapon을 Children으로 둔 부모를 회전시켜줘서, Weapon은 고정되어 있지만
                //Parent의 회전을 따라가기에, 회전하는 것 처럼 보임
                //Vector3.foward, 즉 Z축을 기준으로 회전시켜주자
                transform.Rotate(Vector3.forward * Weapon_speed * Time.deltaTime);

                break;
            
            default:

                break;


        }


    }


    //무기의 Id값에 따라 로직이 다름
    public void Init() {

        switch (Id) {
            
            //Id가 0이면(근접무기로 설정함) 무기 이동속도 
            case 0:
                Weapon_speed -= 150;
                Batch();

                break;
            
            default:

                break;


        }
    }


    //Weapon을 관리하는 함수
    void Batch() {

        //무기의 개수만큼 for문 이용해서 생성
        for (int idx = 0; idx < Count; idx++) {

            //PoolManager의 Get함수 이용, 무기 생성 하기
            Transform Bullet = GameManager.instance.Pool.Get(Prefabs_idx).transform;


            //생성한 무기는 PoolManager가 부모로 되어 있기에, 부모를 이 Script를 가진 대상으로 바꾸기
            Bullet.parent = transform;


            //근접 무기의 경우, 여러개 있을 시 Player을 빙글빙글 도는 구조
            //각 무기를 생성된 개수에 맞게 회전 시키기 위한 Z축 벡터값
            //Ex) Count가 2(0도, 180도), 4(0도, 90도, 180도, 270도) 
            Vector3 Rotation_vec = Vector3.forward * 360 * idx / Count;


            //생성 된 Bullet을 갯수에 따른 각도만큼 회전시키기
            Bullet.Rotate(Rotation_vec);


            //Bullet은 생성 직후 Player의 자식 개체인 Weapon의 자식으로 생성됨
            //즉, Bullet은 Player의 위치와 같은 좌표에 생성된다
            //Player와 거리를 두기 위해, Bullet이 바라보는 윗방향, 
            //즉 Bullet.up에 Weapon_distance(떨어트릴 거리)를 곱해 Bullet 기준 위로 이동
            //
            Bullet.Translate(Bullet.up * Weapon_distance, Space.World);


            //-1 은 근접 무기용, 관통 수 제한이 없음
            Bullet.GetComponent<Bullet_control>().Init(Weapon_dmg, -1);



        }





    }








}
