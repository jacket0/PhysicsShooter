using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value = 100;

    private float _minValue = 0;

    public void DecreaseHealth(float damage)
    {
        if (damage < 0)
            return;

        _value = Mathf.Max(_minValue, _value - damage);

        if (_value == 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
