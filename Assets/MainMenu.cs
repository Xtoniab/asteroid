using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   private const string UsernamePref = "username";
   
   [SerializeField] private TMP_InputField nickTxt;
   [SerializeField] private Button playBtn;

   private void Awake()
   {
      if (PlayerPrefs.HasKey(UsernamePref))
      {
         nickTxt.text = PlayerPrefs.GetString(UsernamePref);
      }
      
      playBtn.onClick.AddListener(() =>
      {
         if (!string.IsNullOrEmpty(nickTxt.text))
         {
            PlayerPrefs.SetString(UsernamePref, nickTxt.text);
            SceneManager.LoadScene("Main");
         }
      });
   }
}
