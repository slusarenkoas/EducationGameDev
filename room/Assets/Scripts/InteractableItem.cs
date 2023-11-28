using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField]
    private int _highlightIntensity = 4;
    [SerializeField]
    private float _power= 400;
    
    private Outline _outline;
    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void SetFocus()
    {
        _outline.OutlineWidth = _highlightIntensity;
    }
    
    public void RemoveFocus()
    {
        _outline.OutlineWidth = 0;
    }


    public void DropItem()
    {
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        transform.SetParent(null);
    }

    public void TakeItem(Transform inventory)
    {
        transform.SetParent(inventory);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
    }

    public void ThrowItem(Vector3 directionPlayer)
    {
        transform.SetParent(null);
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(directionPlayer * _power);
    }
}