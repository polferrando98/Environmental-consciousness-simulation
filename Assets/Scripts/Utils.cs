using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static GameObject SpawnObjectAroundObject(Vector3 sourcePos, GameObject gameObject, float minDistance, float maxDistance, Transform parent, bool randomRotation)
    {
        float r = Random.Range(minDistance, maxDistance);

        GameObject newGameObject = Object.Instantiate(gameObject, parent);
        newGameObject.transform.position = RandomPosInCircle(r, sourcePos);
        if (randomRotation)
            newGameObject.transform.Rotate(0f, Random.Range(0f, 360f),0f);
        return newGameObject;

    }
    public static Vector3 RandomPosInCircle(float r, Vector3 sourcePos)
    {
        //Random position inside a circle of radius 'r' and center at 0
        Vector2 circlePos = Random.insideUnitCircle * r;
        //Set circle center at the sourcePos and convert to Vector3
        return new Vector3(sourcePos.x + circlePos.x, 0, sourcePos.z + circlePos.y);
    }
}
