using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreItem : MonoBehaviour
{
    public TextMeshProUGUI nameTxt, rankTxt, scoreTxt;
    public Image bgImage;
    public Color currentPlayerColor;
    public void SetScoreItem(string name, int rank, double score)
    {
        nameTxt.text = name.Length >= 17 ? name.Substring(0, 17) : name;
        rankTxt.text = "#" + (rank + 1).ToString();
        scoreTxt.text = score.ToString();
    }
    public void SetAsCurrentPlayer()
    {
        bgImage.color = currentPlayerColor;
        nameTxt.text = "YOU";
    }
}