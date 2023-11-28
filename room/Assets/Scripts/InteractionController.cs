using UnityEditor.PackageManager;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Transform _inventory;
    
    private Ray _ray;

    private InteractableItem _lastInteractableItem;
    private InteractableItem _lastPickedItem;


    private void Update()
    {
        if (Camera.main != null)
            _ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        
        if (Physics.Raycast(_ray, out var hitInfo, 3f))
        {    
            HighLightItems(hitInfo.collider);
        
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithWorld(hitInfo.collider);
            }
        }
        
        if (Input.GetMouseButtonDown(0) && _lastPickedItem != null)
        {
            _lastPickedItem.ThrowItem(transform.forward);
            _lastPickedItem = null;
        }
    }

    private void HighLightItems(Collider hitInfoCollider)
    {
        var interactItem = hitInfoCollider.GetComponent<InteractableItem>();

        if (_lastInteractableItem != interactItem)
        {
            if (_lastInteractableItem != null)
            {
                _lastInteractableItem.RemoveFocus();
            }

            if (interactItem != null)
            {
                interactItem.SetFocus();
            }

            _lastInteractableItem = interactItem;
        }
    }


    private void InteractWithWorld(Collider hitInfoCollider)
    {
        DoorInteract(hitInfoCollider);
        TryTakeInteractItem(hitInfoCollider);
    }

    private void DoorInteract(Collider hitInfoCollider)
    {
        if (hitInfoCollider.GetComponent<Door>() == null) return;
        var door = hitInfoCollider.GetComponent<Door>();
        door.SwitchDoorState();
    }

    private void TryTakeInteractItem(Collider hitInfoCollider)
    {
        var item = hitInfoCollider.GetComponent<InteractableItem>();
        
        if (item != _lastPickedItem)
        {
            if (_lastPickedItem != null)
            {
                _lastPickedItem.DropItem();
            }

            if (item != null)
            {
                item.TakeItem(_inventory);
            }

            _lastPickedItem = item;
        }
    }
}
