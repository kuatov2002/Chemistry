using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Debug = System.Diagnostics.Debug;

public class AddElement : MonoBehaviour
{
    public GameObject input;
    public Database database;
    public GameObject example;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
        database.reactions = database.ParseDataString(database.csvFile.text);
    }
    void TaskOnClick(){
        
        string Text = input.GetComponent<Text>().text.Trim();
        foreach (var element in database.elements)
        {
            if (string.Equals(element.name.Trim(),Text))
            {
                print("Find this object");
                GameObject copy = Instantiate(example);
                copy.name = element.name;
                copy.transform.position=new Vector3(Random.Range(-9f,9f),Random.Range(-4.5f,4.5f),0);
                copy.GetComponent<SpriteRenderer>().color = element.color;
                

                int maxAttempts = 400;
                for (int i = 0; i < maxAttempts; i++)
                {
                    Vector3 randomPosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-4.5f, 4.5f), 0);

                    if (Physics2D.OverlapCircle(randomPosition, 0.6f) == null)
                    {
                        copy.transform.position = randomPosition;
                        Debug.Assert(database.reactions != null, "database.reactions != null");
                        for (int j = 0; j < database.reactions.GetLength(0); j++)
                        {
                                if (database.reactions[0,j].Equals(copy.name))
                                {
                                    copy.GetComponent<ElementObject>().canMakeReactions = true;
                                    break;
                                }
                        }
                        return;
                    }
                }
                print("Not enough space");
                Destroy(copy);
                return;
            }
        }
        print("Not Found in database");
    }
}

