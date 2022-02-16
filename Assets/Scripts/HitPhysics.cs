using UnityEngine;

public class HitPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        var destructable = col.gameObject.GetComponent<IDestructable>();
        if (destructable != null)
        {
            destructable.Destruct(col.gameObject);
        }
    }
}
