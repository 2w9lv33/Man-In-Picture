using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Color : MonoBehaviour
    {
        public enum MyColor { WALL, HASCOLOR, NOCOLOR, BLACK };
        [SerializeField] private MyColor _myColor = MyColor.NOCOLOR;
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
    }
}