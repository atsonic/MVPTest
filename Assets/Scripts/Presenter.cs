using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ui;
using data;

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

        //モデルのスコア変更イベント購読
        _model.ReactiveCount.AsObservable().
            Subscribe(count => _viewController.setCount(count));
    }
}