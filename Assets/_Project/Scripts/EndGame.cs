using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Canvas _winCanvas;
    [SerializeField] private UI_Menu _menu;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _winCanvas.gameObject.SetActive(true);
            _menu.OpenUI();
        }
    }
}
