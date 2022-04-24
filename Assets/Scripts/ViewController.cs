using UniRx;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using UnityEngine.UI;
namespace ui{
    public class ViewController : MonoBehaviour
    {
        //ボタンUI
        [SerializeField] private Button _button;
        //インプットフィールドUI
        [SerializeField] private InputField _inputField;
        //テキストフィールドUI
        [SerializeField] private Text _textField;
        
        //カウントアップイベント
        private Subject<int> m_CountUp = new Subject<int>();
        public IObservable<int> OnCountUp { get { return m_CountUp; } }

        //ボタンクリックイベント購読
        void Start()
        {
            _button.onClick.AsObservable().Subscribe(_ => CountUp()).AddTo(this);
        }

        //カウントアップ時の処理
        private void CountUp()
        {
            //ビューコントローラーへイベント発火
            m_CountUp.OnNext((int)3);
        }
        //テキストフィールドにカウントを表示
        public void setCount(int count){
            _textField.text = count.ToString();
        }
    }
}