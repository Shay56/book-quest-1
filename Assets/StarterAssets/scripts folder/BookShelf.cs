using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    public string category;

    private void OnCollisionEnter(Collision collision)
    {
        Book book = collision.gameObject.GetComponent<Book>();
        if (book != null)
        {
            GameManager.instance.PlaceBook(book, this);
        }
    }

}
