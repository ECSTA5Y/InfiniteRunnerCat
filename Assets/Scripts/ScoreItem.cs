using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreItem : MonoBehaviour
{
    public TextMeshProUGUI nameTxt, rankTxt, scoreTxt;
    public Image bgImage;
    public Sprite currentPlayerSprite;
    public void SetScoreItem(string name, int rank, double score)
    {
        nameTxt.text = name.Length >= 18 ? name.Substring(0, 18) : name;
        rankTxt.text = "#" + (rank + 1).ToString();
        scoreTxt.text = score.ToString();
    }
    public void SetAsCurrentPlayer()
    {
        bgImage.sprite = currentPlayerSprite;
        //nameTxt.text = "YOU";
    }
}