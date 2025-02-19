using UnityEngine;

public class Toggler : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    public void ToggleObject()
    {
        _object.SetActive(!_object.activeSelf);
    }
}
