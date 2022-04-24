using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace data{
    public class Model
    {
        public IntReactiveProperty ReactiveCount = new IntReactiveProperty(0);

        public int Count
        {
            get { return ReactiveCount.Value; }
            set { 
                ReactiveCount.Value = value;
                if(ReactiveCount.Value > _maxCount){
                    ReactiveCount.Value = _maxCount;
                } }
        }
        private int _maxCount = 100;
    }
}