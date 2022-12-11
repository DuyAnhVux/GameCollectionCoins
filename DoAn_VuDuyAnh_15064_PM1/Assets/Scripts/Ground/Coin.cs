using UnityEngine;
public class Coin : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 90;
    void Update()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime * 2f);
    }
}
