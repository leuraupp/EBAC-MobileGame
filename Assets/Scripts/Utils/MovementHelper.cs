using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float duration = 1f;

    private int index = 0;

    private void Start() {
        transform.position = positions[index].position;
        NextIndex();

        StartCoroutine(MoveToNextPosition());
    }

    private void NextIndex() {
        index++;
        if (index >= positions.Count) {
            index = 0;
        }
    }

    IEnumerator MoveToNextPosition() {
        float time = 0;

        while (true) {

            var currentPos = transform.position;

            while (time < duration) {
                transform.position = Vector3.Lerp(currentPos, positions[index].position, (time / duration));
                time += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            time = 0;

            yield return null;
        }
    }
}
