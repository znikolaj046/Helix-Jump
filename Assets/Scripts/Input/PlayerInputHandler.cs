using UnityEngine;
using Input;
using Tower;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputSwipePanels _swipePanel;
    [SerializeField] private TowerRotation _towerRotation;

    private void OnEnable() => _swipePanel.Swiping += RotateTower;

    private void OnDisable() => _swipePanel.Swiping -= RotateTower;

    private void RotateTower(Swipe swipe)
    {
        float xAxe = swipe.Delta.x;
        _towerRotation.AddRotation(xAxe);
    } 
}
