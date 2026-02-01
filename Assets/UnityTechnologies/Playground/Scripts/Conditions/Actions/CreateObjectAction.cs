using UnityEngine;
using System.Collections;


[AddComponentMenu("Playground/Actions/Create Object")]
public class CreateObjectAction : Action
{
    public GameObject prefabToCreate;
    public Vector2 newPosition;
    public bool relativeToThisObject;

    public override bool ExecuteAction(GameObject dataObject)
    {
        if (prefabToCreate != null)
        {
            if (DropManager.Instance.TryDrop())
            {
                GameObject newObject = Instantiate(prefabToCreate);

                Vector2 finalPosition = newPosition;
                if (relativeToThisObject)
                {
                    finalPosition = (Vector2)transform.position + newPosition;
                }

                newObject.transform.position = finalPosition;
            }
        }

        // SIEMPRE devolver true para que la caja se rompa
        return true;
    }
}
