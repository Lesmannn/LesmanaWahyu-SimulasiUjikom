using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRaycast : MonoBehaviour
{
    public System.Action OnClicked;

    [SerializeField]
    TileGroup tileContainer;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (click.collider != null)
            {
                //click.collider.gameObject.SetActive(false);
                tileContainer.SetName(click.collider.name);
                OnClicked?.Invoke();
            }
        }
    }
}
