using UnityEngine;

public class SlowdownArea : MonoBehaviour
{
    [SerializeField][Range(0.1f, 0.9f)] private float _slowdownPercentage;
    [SerializeField] private string _targerLayerMask = "Enemies";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_targerLayerMask))
        {
            ISlowdown enemy = other.gameObject.GetComponent<ISlowdown>();
            enemy.ReceiveSlowdown(_slowdownPercentage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_targerLayerMask))
        {
            ISlowdown enemy = other.gameObject.GetComponent<ISlowdown>();
            enemy.ReleaseSlowdown(_slowdownPercentage);
        }
    }
}