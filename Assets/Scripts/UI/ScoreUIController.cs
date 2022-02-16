using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUIController : MonoBehaviour
{
    private Text _text;

    private void Awake() // Инициализация
    {
        _text = GetComponent<Text>();
    }
    private void HandleScoreChanges(int count) // Изменяем кол-во очков в UI
    {
        _text.text = count.ToString("D6");
        Debug.Log(count);
    }

    private void Start()
    {
        GameController.Instance.OnScoreChanged += HandleScoreChanges;
    }
}
