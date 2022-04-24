using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace data{
    public class Model
    {
        public IntReactiveProperty ReactiveCount = new IntReactiveProperty(0);
        public StringReactiveProperty ReactiveText = new StringReactiveProperty("");

        public int Count
        {
            get { return ReactiveCount.Value; }
            set { 
                ReactiveCount.Value = value;
                if(ReactiveCount.Value > _maxCount){
                    ReactiveCount.Value = _maxCount;
                } }
        }
        public string InputText
        {
            get { return ReactiveText.Value; }
            set { 
                ReactiveText.Value = value;
            }
        }
        private int _maxCount = 100;
    }
}