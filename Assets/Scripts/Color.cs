using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Color : MonoBehaviour
    {
        [SerializeField] public bool canBeSet = true;
        public enum MyColor { WALL, HASCOLOR, NOCOLOR, BLACK };
        [SerializeField] private MyColor _myColor = MyColor.NOCOLOR;
        [SerializeField] private MyColor _checkColor = MyColor.NOCOLOR;
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

        public MyColor checkColor
        {
            get
            {
                return _checkColor;
            }
            set { }
        }
    }
}