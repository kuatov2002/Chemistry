using UnityEngine;
public class ElementObject : MonoBehaviour
{
    private Element element;
    private Vector3 difference=Vector2.zero;
    private bool isActive = false;

    
    
    public bool canMakeReactions;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {

    }  

    private void OnMouseDown()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        isActive = true;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnMouseUp()
    {
        isActive = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        return; 
        if (isActive)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().color =
                (GetComponent<SpriteRenderer>().color + other.GetComponent<SpriteRenderer>().color) / 2;
        }
        // Destroy(this.gameObject);
        Debug.Log(132444);
    }
    
    
}
