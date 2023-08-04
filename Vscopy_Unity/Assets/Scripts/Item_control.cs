using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//각 Item의 Lv을 띄워줄 UI로 화면에 띄워줄 Script
public class Item_control : MonoBehaviour
{
 
    //Itemdata의 정보를 저장할 변수
    public Itemdata Data;

    public int Level;

    public Weapon_control Weapon;

    //Image와 Text 변환을 위해 사용할 변수
    Image Icon;

    Text Lvl_text;


    private void Awake() {
        
        //GetComponentsInChildren은 배열로 Component를 가져오고, 0 idx는 자기자신이다
        Icon = GetComponentsInChildren<Image>()[1];

        //Itemdata 에 저장되어있는 Item_icon 가져오기
        //Itemdata 에는 각 Item의 Sprite가 들어있음
        Icon.sprite = Data.Item_icon;

        //GetComponentsInChildren을 통해 Text 정보 가져와서 저장하기
        Text[] Txt = GetComponentsInChildren<Text>();
        Lvl_text = Txt[0];

    }

    private void LateUpdate() {
        
        //레벨을 표시하는 txt 계속 초기화
        Lvl_text.text = "Lv." + Level;

    }

    //버튼 클릭 시 실행시킬 함수
    public void On_click() {

        //각 버튼의 Data 변수에 저장되어있는 Itemdata의 Itemtype에 따라 Switch문 
        switch (Data.Item_type) {

            case Itemdata.Itemtype.Glove:

                break;

            //여러개의 case를 붙여서 사용 가능
            case Itemdata.Itemtype.Range:
            case Itemdata.Itemtype.Melee:

                //첫 레벨업 시 무기 생성
                if (Level == 0) {

                    //새로운 GameObject 선언
                    GameObject New_weapon = new GameObject();

                    //AddComponent를 통해 특정 Component 가져오고 반환하기
                    Weapon = New_weapon.AddComponent<Weapon_control>();

                    Weapon.Init(Data);


                }

                //레벨 업 시
                else {
                    
                     
                    //Itemdata에 저장되어 있는 기본 무기 dmg 가져오기
                    float Weapon_dmg = Data.Base_dmg;
                    int Count = 0;


                    //Itemdata에 있는 Dmgs, Cnts 배열에 접근해, 레벨 업 시
                    //각 배열의 idx의 수치만큼 무기 강화시켜주기
                    //무기의 dmg는 곱연산으로 증가시켜주기
                    //무기의 Cnt는 더해주기(근접 무기는 갯수, 원거리 무기는 관통 수 의미)
                    Weapon_dmg += Weapon_dmg * Data.Dmgs[Level - 1];
                    Count += Data.Cnts[Level - 1];


                    //레벨 업에 따른 Weapon 강화를 해주는 함수 
                    Weapon.Lvl_up(Weapon_dmg, Count);



                }



                break;

            case Itemdata.Itemtype.Heal :

                break;

             

            case Itemdata.Itemtype.Shoes:

                break;

        }

        //Lv up
        Level++;

        //현재 Dmgs 의 배열의 길이는 5다. 이는 최대 레벨을 5로 구상해놓았기 때문
        //최대 레벨을 넘지 않게 조절하는 코드
        if (Level >= Data.Dmgs.Length) {

            //Button의 interactable을 false로 해, 클릭 못하게 함
            GetComponent<Button>().interactable = false;

        }
    }



}
