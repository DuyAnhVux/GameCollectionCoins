using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    public float speed; 
    void Update()
    {
        transform.position = transform.position + Vector3.back * speed * Time.deltaTime;
    }
}
