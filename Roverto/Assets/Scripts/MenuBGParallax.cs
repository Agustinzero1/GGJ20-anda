using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGParallax : MonoBehaviour
{
    public Layer[] layers;

    public Transform player;
    public int Divider;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Layer layer in layers)
        {
            layer.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = new Vector2(
            (player.position.x - Screen.width / Divider) / (Screen.width / Divider),
            (player.position.y - Screen.height / Divider) / (Screen.height / Divider));

        if (layers != null)
        {
            foreach(Layer layer in layers)
            {
                layer.Update(delta);
            }
        }

    }

    [System.Serializable]
    public class Layer
    {
        public Transform transform;
        public Vector2 maxDistance = new Vector2(1,1);
        public float easing = 2;

        private Vector3 startPosition;

        public void Start()
        {
            startPosition = transform.localPosition;
        }

        public void Update(Vector2 delta)
        {
            Vector3 targetPos = startPosition + new Vector3(maxDistance.x * delta.x, maxDistance.y * delta.y, startPosition.z);
            if (easing > 0)
            {
                transform.localPosition = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * easing);
            }
            else
            {
                transform.localPosition = targetPos;
            }
            
        }
    }
}
