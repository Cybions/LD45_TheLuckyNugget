using UnityEngine;
using UnityEngine.Events;

public class HoverElement : MonoBehaviour
{
    public bool CanHover = true;
    public UnityEvent OnElementTriggered;
    [SerializeField]
    private Material NormalMat;
    [SerializeField]
    private Material GlowMat;

    private void Start()
    {
        GetComponent<MeshRenderer>().material = NormalMat;
    }

    private void OnMouseEnter()
    {
        if (!CanHover) { return; }
        // Outline the element
        GetComponent<MeshRenderer>().material = GlowMat;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && CanHover)
        {
            OnElementTriggered.Invoke();
        }
    }

    private void OnMouseExit()
    {
        // Remove outline.
        GetComponent<MeshRenderer>().material = NormalMat;
    }

    public void ChangeHoverState(bool newState)
    {
        CanHover = newState;
    }
}
