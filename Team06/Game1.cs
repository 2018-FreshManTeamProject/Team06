﻿// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using Team06.Actor;  //Playerなど
using Team06.Device; //Rendererなど
using Team06.Def;    //Screenなど
using Team06.Util;
using Team06.Scene;

using System.Collections.Generic;  //LIst,Dictionary用



/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace Team06
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
        private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト
        private GameDevice gameDevice;
        private Renderer renderer;     //描画オブジェクト
        private SceneManager sceneManager;   //シーン管理者
        private Timer timer;
        private TimerUI timerUI;
        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";
            //Screenクラスの値で画面サイズを設定
            graphicsDeviceManager.PreferredBackBufferWidth = Screen.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = Screen.Height;

            Window.Title = "Team06";

        }

        /// <summary>
        /// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
        /// </summary>
        protected override void Initialize()
        {
            // この下にロジックを記述

            //ゲームデバイスの実体生成と取得
            gameDevice = GameDevice.Instance(Content, GraphicsDevice);

            sceneManager = new SceneManager();
            //sceneManager.Add(Scene.Scene.Title, new SceneFader(new Title()));       //シーンフェーダーを追加
            CountUpTimer scoreTimer = new CountUpTimer();
            IScene addScene = new GamePlay(scoreTimer);
           
            sceneManager.Add(Scene.Scene.Title, new Title());
            sceneManager.Add(Scene.Scene.GamePlay, addScene);
            sceneManager.Add(Scene.Scene.Ending,new Ending(addScene,scoreTimer));
            // sceneManager.Add(Scene.Scene.Ending, new SceneFader(new Ending(addScene)));
            sceneManager.Change(Scene.Scene.Title);             //最初のシーンはタイトルに変更

            timer = new CountDownTimer(30);
            timerUI = new TimerUI(timer);
            // この上にロジックを記述
            base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
        }
       
        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {
             // 画像を描画するために、スプライトバッチオブジェクトの実体生成
             spriteBatch = new SpriteBatch(GraphicsDevice);
             renderer = gameDevice.GetRenderer();

            // この下にロジックを記述
            renderer.LoadContent("title");
            //  renderer.LoadContent("kabe");
            renderer.LoadContent("number1");
            renderer.LoadContent("timer");
            renderer.LoadContent("congratulation1");
            renderer.LoadContent("searchlight");
            renderer.LoadContent("stage");
            renderer.LoadContent("kaito");
            renderer.LoadContent("goalyoko");




            ////    renderer.LoadContent("fade", fade);
            //    Sound sound = gameDevice.GetSound();
            //    string filepath = "";
            //    sound.LoadBGM("titlebgm", filepath);
            // この上にロジックを記述
            // base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
            // この上にロジックを記述
        }
        /// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }

        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            if((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                Exit();
            }

            // この下に更新ロジックを記述
            //ゲームデバイスを更新
            gameDevice.Update(gameTime);   //必ずこの1回のみ

            //入力状態更新
            // Input.Update();　　　　//必ずこの1っ回のみ
            //シーン管理者更新
            sceneManager.Update(gameTime);

            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // この下に描画ロジックを記述

            //シーン管理者描画
            sceneManager.Draw(renderer);
            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }
    }
}
