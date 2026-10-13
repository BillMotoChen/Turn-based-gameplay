using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFollow cinemachineFollow;
    private float targetFollowOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetFollowOffset =  cinemachineFollow.FollowOffset.y;
    }

    // Update is called once per frame
    private void Update()
    {
       HandleMovement();
       HandleRotation();
       HandleZoom();
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            inputMoveDir += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.A ))
        {
            inputMoveDir += new Vector3(-1, 0, 0);
        }

        float moveSpeed = 10f;
        
        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
    
    private void HandleRotation()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationVector += new Vector3(0, -1, 0);
        }
        
        float rotateSpeed = 100f;
        transform.eulerAngles += rotationVector * rotateSpeed * Time.deltaTime;
    }

    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            float scrollSpeed = 3f;
            targetFollowOffset += Input.mouseScrollDelta.y * scrollSpeed * Time.deltaTime;
            targetFollowOffset = Mathf.Clamp(targetFollowOffset, 1f, 15f);
        }
        
        cinemachineFollow.FollowOffset.y = Mathf.Lerp(
            cinemachineFollow.FollowOffset.y,
            targetFollowOffset,
            Time.deltaTime * 10f
        );
    }
}
