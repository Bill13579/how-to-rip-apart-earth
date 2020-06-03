using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName;
    public int price;
    public GameObject correspondingSpawnable;
    public GameObject infoPanel;
    public Text infoPanelName;
    public Text infoPanelCost;
    public FollowMouse infoPanelFollowMouse;
    public Vector3 scale;
    private Vector2 initPos = Vector2.negativeInfinity;
    public CircleCollider2D boundary;
    public Camera mainCamera;
    public CanvasScaler canvasScaler;
    public ClimateChangeController climateChangeController;

    public void OnPointerEnter(PointerEventData eventData) {
        infoPanel.transform.position = Input.mousePosition + infoPanelFollowMouse.offset;
        infoPanelName.text = itemName;
        infoPanelCost.text = price.ToString();
        infoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        infoPanel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (initPos.Equals(Vector2.negativeInfinity)) {
            initPos = transform.position;
        }
        transform.position = Input.mousePosition;
        transform.localScale = scale;
    }

    bool WithinBoundaries(Vector3 pos)
    {
        return Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2)) <= boundary.radius;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 mp = mainCamera.ScreenToWorldPoint(Input.mousePosition / canvasScaler.scaleFactor);
        mp = new Vector3(mp.x, mp.y, 0f);
        if (WithinBoundaries(mp)) {
            climateChangeController.DeltaMoney(-price);
            GameObject itemPurchased = GameObject.Instantiate(correspondingSpawnable, mp, correspondingSpawnable.transform.rotation);
            itemPurchased.SetActive(true);
        }
        if (!initPos.Equals(Vector2.negativeInfinity)) {
            transform.position = initPos;
            initPos = Vector2.negativeInfinity;
        }
        transform.localScale = Vector3.one;
    }
}
