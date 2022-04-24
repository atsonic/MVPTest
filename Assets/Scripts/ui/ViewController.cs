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

        //カウントアップイベント
        private Subject<string> m_TextInput = new Subject<string>();
        public IObservable<string> OnTextInput { get { return m_TextInput; } }
        //ボタンクリックイベント購読
        void Start()
        {
            _button.onClick.AsObservable().Subscribe(_ => CountUp()).AddTo(this);
            _inputField.OnEndEditAsObservable().Subscribe(text => TextInput(text)).AddTo(this);
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
        //カウントアップ時の処理
        private void TextInput(string text)
        {
            //ビューコントローラーへイベント発火
            m_TextInput.OnNext((string)text);
        }
    }
}