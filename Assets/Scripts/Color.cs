using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Color : MonoBehaviour
    {
        [SerializeField] public bool canBeGet = true;
        [SerializeField] public bool canBeSet = true;
        [SerializeField] private bool _same = false;
        public enum MyColor { WALL, HASCOLOR, NOCOLOR, BLACK ,BLUE,RED,YELLOW };
        [SerializeField] private MyColor _myColor = MyColor.NOCOLOR;
        [SerializeField] private MyColor _checkColor = MyColor.NOCOLOR;

        //get color
        public MyColor myColor
        {
            get
            {
                return _myColor;
            }
            set
            {
                _myColor = value;
            }
        }

        //check color
        public MyColor checkColor
        {
            get
            {
                return _checkColor;
            }
            set
            {
                _checkColor = value;
            }
        }

        //if is same
        public bool same
        {
            get
            {
                return _same;
            }

            set
            {
                _same = value;
            }
        }

        private void Update()
        {
            if(_myColor == _checkColor)
            {
                same = true;
            }
            else
            {
                same = false;
            }
        }
    }
}