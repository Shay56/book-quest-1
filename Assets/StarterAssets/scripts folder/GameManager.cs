using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaceBook(Book book, BookShelf shelf)
    {
        if (book.category == shelf.category)
        {
            score++;
            Debug.Log("Correct placement! Score:" + score);
        }
        else
        {
            Debug.Log("Incorrect placement. The book's category does not match the shelf's category.");
        }
    }

}
