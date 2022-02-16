using UnityEngine;

public class HeathGridController : MonoBehaviour
{
    public void UpdateGrid(int health) // Обновление кол-ва отображаемых hp
    {
        int childCount = transform.childCount;

        if (health > childCount)
        {
            for (int i = childCount; i < health; i++)
            {
                var newHealthUI = UIHealthPool.Instance.Get();
                newHealthUI.transform.SetParent(transform);
                newHealthUI.transform.localScale = Vector3.one;
                newHealthUI.gameObject.SetActive(true);
            }
        }
        else if (childCount > health)
        {
            for (int i = health; i < childCount; i++)
            {
                var oldHealthUI = transform.GetChild(0);
                UIHealthPool.Instance.SendToPool(oldHealthUI);
            }
        }
    }

    public void Start()
    {
        GameController.Instance.OnLivesLeftChanged += UpdateGrid;
    }
}
