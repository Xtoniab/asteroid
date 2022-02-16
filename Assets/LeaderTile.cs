using TMPro;
using UnityEngine;

public class LeaderTile : MonoBehaviour
{
   [SerializeField] private TMP_Text nameTxt;
   [SerializeField] private TMP_Text scoreTxt;


   public void Init(string username, int score)
   {
      nameTxt.text = username;
      scoreTxt.text = score.ToString().PadLeft(5, '0');
   }
}
