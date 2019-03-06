using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour {

    public enum Tags { Item_1, Item_2, Item_3, Item_4, Item_5, Item_6, Item_7, Item_8, Item_9 };
    public Tags ItemTag = new Tags();

    Vector2 StartPos;
    Vector2 TargetPos;
    float DeltaX, DeltaY;
    [SerializeField]
    bool IsLocked;

    private void Start()
    {
        StartPos = transform.position;
        this.gameObject.tag = ItemTag.ToString();
    }
   
    private void OnMouseOver()
    {
        if (!IsLocked)
        {
            DeltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            DeltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
      
    }


    private void OnMouseDrag()
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Pos.x - DeltaX, Pos.y - DeltaY);
    }


    private void OnMouseUp()
    {
        if (IsLocked)
        {
            transform.position = TargetPos;
            Jawaban.instance.createQuestion();
            //this.gameObject.GetComponent<ImageController>().enabled = false;
        }
            
        else 
            transform.position = StartPos;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == this.gameObject.tag)
        {
            Debug.Log("Ikeh mz");
            TargetPos = obj.transform.position;
            IsLocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == this.gameObject.tag)
            IsLocked = false;
    }
}
