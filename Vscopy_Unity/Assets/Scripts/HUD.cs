using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //열거형으로 선언해보기
    public enum Infotype {Exp, Level, Kills, Time, Hp}

    //열거형 변수 선언
    public Infotype Type;

    //Txt, Slider을 담을 변수 선언
    Text My_txt;
    Slider My_slider;




    private void Awake() {

        //Component 가져오기
        My_txt = GetComponent<Text>();
        My_slider = GetComponent<Slider>();
        
    }

    //열거형으로 선언한 데이터를 switch case 문을 이용해서 사용해보기
    private void LateUpdate() {
        

        switch (Type) {
            
            
            case Infotype.Exp:

                float Cur_exp = GameManager.instance.Exp;
                float Max_exp = GameManager.instance.Next_exp[GameManager.instance.Level];

                My_slider.value = Cur_exp / Max_exp;


                break;

            case Infotype.Level:

                break;

            case Infotype.Kills:

                break;


            case Infotype.Time:

                break;


            case Infotype.Hp:

                break;

                        




        }






    }





}
