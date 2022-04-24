using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ui;
using data;
using utils;

public class Presenter : MonoBehaviour
{
    // スコア格納用のモデル
    private Model _model;
    //UI格納用のビューコントローラー
    [SerializeField] private ViewController _viewController;
    void Start()
    {
        //モデルを生成
        _model = new Model();

        //ビューコントローラーのカウントアップイベント購読
        _viewController.OnCountUp
            .Subscribe(count => _model.Count += count);

        //ビューコントローラーのインプットフィールドイベント購読
        _viewController.OnTextInput
            .Subscribe(text => {
                if(!utils.Validator.IsEmpty(text) && utils.Validator.IsKana(text)){
                    _model.InputText = text;
                }else{
                    Debug.Log("入力文字が不正です");
                }
            });

        //モデルのスコア変更イベント購読
        _model.ReactiveCount.AsObservable()
            .Subscribe(count => _viewController.setCount(count));
        
        //モデルのインプットフィールド変更イベント購読
        _model.ReactiveText.AsObservable()
            .Subscribe(text => Debug.Log("テキストは" + text + "に変更されました。"));
    }
}