using UnityEngine;
using PrimeTween;
using UnityEngine.Rendering.PostProcessing;

public class WorldTween : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Awake()
    {
        initialPosition = transform.position;

    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);
        // Tween.Scale(transform, endValue: new Vector3(.41f, .41f, .41f), duration: 1f, Ease.OutSine, cycles: -1, CycleMode.Yoyo);
        //Tween.PositionY(transform, endValue: 10, duration: 5, Ease.OutSine);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }

    // Update is called once per frame

}

