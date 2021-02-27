using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //Scoreを表示するテキスト
    private GameObject scoreText;
    //得点
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //ScoreTextに獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = this.score + "pt";
    }

    //他のオブジェクトと接触した場合の処理
    void OnCollisionEnter(Collision collision)
    {
        //星(小)に衝突した場合
        if (collision.gameObject.name == "SmallStar")
        {
            //scoreを加算
            score += 10;
        }

        //星(大)に衝突した場合
        if (collision.gameObject.name == "LargeStar")
        {
            //scoreを加算
            score += 30;
        }

        //雲(小)に衝突した場合
        if (collision.gameObject.name == "SmallCloud")
        {
            // スコアを加算
            this.score += 50;
        }

        //雲(大)に衝突した場合
        if (collision.gameObject.name == "LargeCloud")
        {
            // スコアを加算
            this.score += 100;
        }
    }
}