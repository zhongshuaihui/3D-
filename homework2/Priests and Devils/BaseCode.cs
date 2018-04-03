using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Mygame
{
    public class location
    {
        public static Vector3 priests_1_loc = new Vector3(5, 3, 0);
        public static Vector3 priests_2_loc = new Vector3(6.3f, 3, 0);
        public static Vector3 priests_3_loc = new Vector3(7.6f, 3, 0);
        public static Vector3 devils_1_loc = new Vector3(9.5f, 3, 0);
        public static Vector3 devils_2_loc = new Vector3(10.8f, 3, 0);
        public static Vector3 devils_3_loc = new Vector3(12.1f, 3, 0);
        public static Vector3 boat_left_loc = new Vector3(-3, 0, 0);
        public static Vector3 boat_right_loc = new Vector3(3, 0, 0);
        public static Vector3 bank_left_loc = new Vector3(-8.5f, 1.5f, 0);
        public static Vector3 bank_right_loc = new Vector3(8.5f, 1.5f, 0);

        public static Vector3 boatLeft_1_loc = new Vector3(-3.7f, 1.5f, 0);
        public static Vector3 boatLeft_2_loc = new Vector3(-2.3f, 1.5f, 0);
        public static Vector3 boatRight_1_loc = new Vector3(2.3f, 1.5f, 0);
        public static Vector3 boatRight_2_loc = new Vector3(3.7f, 1.5f, 0);
    }

    public class direction
    {
        public static bool left = true;
        public static bool right = false;
    }

    public class ifadd
    {
        public static bool add = true;
        public static bool sub = false;
    }

    public interface UserActions
    {
        void boatmove();
        void priests_get_on();
        void priests_get_off();
        void devils_get_on();
        void devils_get_off();
    }

    public interface GameJudge
    {
        void change_boat_priests_num(bool add);
        void change_boat_devils_num(bool add);
        void change_bank_priests_num(bool isleftbank,bool add);
        void change_bank_devils_num(bool isleftbank, bool add);
        void ifgg(bool boatleft);
    }

    public class mainController : System.Object, UserActions,GameJudge
    {

        private static mainController instance;
        private myGameObject myGameObject;
        private int boat_priests_num,boat_devils_num,leftbank_priests_num,rightbank_priests_num,leftbank_devils_num,rightbank_devils_num;

        public static mainController getInstance()
        {
            if (instance == null)
                instance = new mainController();
            return instance;
        }

        internal void setGameObject(myGameObject _myGameObject)
        {
            if (myGameObject == null)
            {
                myGameObject = _myGameObject;
                boat_priests_num = boat_devils_num = leftbank_priests_num = leftbank_devils_num = 0;
                rightbank_priests_num = rightbank_devils_num = 3;
            }
        }

        public void boatmove()
        {
            myGameObject.boatmove();
        }

        public void devils_get_on()
        {
            myGameObject.devils_get_on();
        }

        public void devils_get_off()
        {
            myGameObject.devils_get_off();
        }

        public void priests_get_on()
        {
            myGameObject.priests_get_on();
        }

        public void priests_get_off()
        {
            myGameObject.priests_get_off();
        }

        public void change_boat_priests_num(bool add)
        {
            if (add)
                boat_priests_num++;
            else
                boat_priests_num--;
        }

        public void change_boat_devils_num(bool add)
        {
            if (add)
                boat_devils_num++;
            else
                boat_devils_num--;
        }

        public void change_bank_priests_num(bool isleftbank, bool add)
        {
            if (isleftbank)
            {
                if (add)
                    leftbank_priests_num++;
                else
                    leftbank_priests_num--;
            }
            else
            {
                if (add)
                    rightbank_priests_num++;
                else
                    rightbank_priests_num--;
            }
        }

        public void change_bank_devils_num(bool isleftbank, bool add)
        {
            if (isleftbank)
            {
                if (add)
                    leftbank_devils_num++;
                else
                    leftbank_devils_num--;
            }
            else
            {
                if (add)
                    rightbank_devils_num++;
                else
                    rightbank_devils_num--;
            }
        }

        public void ifgg(bool boatleft)
        {
            if (boatleft)
            {
                if((leftbank_priests_num >0 && leftbank_devils_num > leftbank_priests_num)||(leftbank_priests_num + boat_priests_num >0 && leftbank_devils_num + boat_devils_num > leftbank_priests_num+ boat_priests_num))
                {
                    showGameText("Defeat");
                }
                else if(leftbank_devils_num + boat_devils_num == 3 && leftbank_priests_num + boat_priests_num == 3)
                {
                    showGameText("Victory");
                }
            }
            else
            {
                if ((rightbank_priests_num > 0 && rightbank_devils_num > rightbank_priests_num) || (rightbank_priests_num + boat_priests_num > 0 && rightbank_devils_num + boat_devils_num > rightbank_priests_num + boat_priests_num))
                {
                    showGameText("Defeat");
                }
            }
        }

        void showGameText(string text)
        {
            GameObject Canvas = Camera.Instantiate(Resources.Load("Prefab/Canvas")) as GameObject;
            GameObject GameText = Camera.Instantiate(Resources.Load("Prefab/GameText"),Canvas.transform) as GameObject;
            GameText.GetComponent<Text>().text = text;
        }
    }
}

