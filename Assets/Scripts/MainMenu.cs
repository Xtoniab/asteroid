using DefaultNamespace;
using Proyecto26;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   private const string UsernamePref = "username";

   [SerializeField] private TMP_InputField nickTxt;
   [SerializeField] private Button playBtn;
   [SerializeField] private TMP_Text highestScore;
   [SerializeField] private Button refreshBtn;

   [Header("Leaderboard")]
   [SerializeField] private LeaderTile leaderTilePrefab;
   [SerializeField] private Transform tileParent;
   
   private void Awake()
   {
      RestClient.DefaultRequestHeaders["Accept"] = "application/json";
      RestClient.DefaultRequestHeaders["Access-Control-Allow-Origin"] = "*";
      RestClient.DefaultRequestHeaders["Access-Control-Allow-Methods"] = "DELETE, POST, GET, OPTIONS";
      RestClient.DefaultRequestHeaders["Access-Control-Allow-Headers"] = "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With";
      RestClient.DefaultRequestHeaders["X-Requested-With"] = "XMLHttpRequest";
      refreshBtn.onClick.AddListener(Refresh);

      SetupTopPlayers();
      if (PlayerPrefs.HasKey(UsernamePref))
      {
         nickTxt.text = PlayerPrefs.GetString(UsernamePref);
         SetupHighestScore();
      }
      
      playBtn.onClick.AddListener(() =>
      {
         if (!string.IsNullOrEmpty(nickTxt.text))
         {
            PlayerPrefs.SetString(UsernamePref, nickTxt.text);
            SceneManager.LoadScene("Main");
         }
      });
      
      nickTxt.onValidateInput += (text, index, addedChar) => text.Length < 12 ? addedChar : '\0';
   }

   private void Refresh()
   {
      if (PlayerPrefs.HasKey(UsernamePref))
      {
         SetupHighestScore();
      }

      SetupTopPlayers();
   }

   private void SetupHighestScore()
   {
      RestApiClient.GetHighestScore(PlayerPrefs.GetString(UsernamePref), val => highestScore.text = val.ToString().PadLeft(5, '0'));
   }

   private void SetupTopPlayers(){
      foreach (Transform child in tileParent) {
         Destroy(child.gameObject);
      }

      RestApiClient.GetTopPlayers(res =>
      {
         for (var i = 0; i < res.Length; i++)
         {
            var userData = res[i];
            var tile = Instantiate(leaderTilePrefab, tileParent);
            tile.Init($"{i + 1}.{userData.username}", userData.value);
         }
      });
   }
}
