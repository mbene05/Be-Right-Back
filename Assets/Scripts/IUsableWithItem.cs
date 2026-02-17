using UnityEngine;

public interface IUsableWithItem
{
    bool UseWithItem(Item item, Vector3 hitPoint);
}
