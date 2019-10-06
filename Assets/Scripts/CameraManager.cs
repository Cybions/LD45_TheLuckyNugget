using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    [SerializeField]
    private List<Transform> CameraSpots;
    private int CurrentSpot = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        MoveToNextSpot();
    }

    public void ChangeCameraSpot()
    {
        CurrentSpot++;
        MoveToNextSpot(1.5f, 3);
    }

    private void MoveToNextSpot(float MoveDuration = 0,float RotDuration = 0)
    {
        Camera.main.transform.DOMove(CameraSpots[CurrentSpot].position, MoveDuration);
        Camera.main.transform.DORotateQuaternion(CameraSpots[CurrentSpot].rotation, RotDuration);
    }
}
