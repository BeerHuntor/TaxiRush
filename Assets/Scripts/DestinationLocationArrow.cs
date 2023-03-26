using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestinationLocationArrow : MonoBehaviour {

    private Vector3 targetPosition;
    [SerializeField] private Camera uiCamera;

    [SerializeField] private RectTransform arrowSpriteRectTransform;

    private void Update() {
        if (!GameManager.instance.HasPassenger()) {

            //NRE Returned on first frame at runtime. 
            if (GameManager.instance.GetCurrentPickupPoint() != null) {
                targetPosition = GameManager.instance.GetCurrentPickupPoint().position;
            }
        } else {
            //Sanity Check. 
            if (GameManager.instance.GetCurrentDestination() != null) {
                targetPosition = GameManager.instance.GetCurrentDestination().position;
            }
        }

        UpdateArrowRotation();

        if (IsTargetOffScreen(targetPosition)) {
            UpdateArrowScreenPosition();
        }
    }

    private void UpdateArrowRotation() {

        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;

        fromPosition.z = 0f;


        Vector3 targetDirectionNormalized = (toPosition - fromPosition).normalized;

        float angle = Mathf.Atan2(targetDirectionNormalized.y, targetDirectionNormalized.x) * Mathf.Rad2Deg;

        //Setting the <0 angle to 360 degrees. 
        if (angle < 0f) {
            angle += 360f;
        }

        // Adjustment needed as the difference between the local rotation and the actual angle was off, not sure why this works, but it shouldn't be needed,
        // but does work so leaving it as 
        float adjustedAngle = 90f - angle;

        //Adjustment as the arrow is facing the inverted direction it seems. 
        arrowSpriteRectTransform.localEulerAngles = new Vector3(0, 0, -adjustedAngle);
    }


    //This doesnt work properly. Not sure if its something in the setup that causing it. 
    //TODO: fix this!
    private void UpdateArrowScreenPosition() {

        float screenBorder = 100f; 
        Vector3 cappedTargetScreenPosition = Camera.main.WorldToScreenPoint(targetPosition);

        if (cappedTargetScreenPosition.x <= screenBorder) cappedTargetScreenPosition.x = screenBorder;
        if (cappedTargetScreenPosition.x >= Screen.width - screenBorder) cappedTargetScreenPosition.x = Screen.width - screenBorder;
        if (cappedTargetScreenPosition.y <= screenBorder) cappedTargetScreenPosition.y = screenBorder;
        if (cappedTargetScreenPosition.y >= Screen.height - screenBorder) cappedTargetScreenPosition.x = Screen.height - screenBorder;

        Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
        arrowSpriteRectTransform.position = pointerWorldPosition;
        arrowSpriteRectTransform.localPosition = new Vector3(arrowSpriteRectTransform.localPosition.x, arrowSpriteRectTransform.localPosition.y, 0f);
        
    }

    private bool IsTargetOffScreen(Vector3 targetPosition) {
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);

        // > 0 : target is to the left, < Screen.Width : Target is to the right -- y < 0 : Target is below, y > Screen.Height : Target is above 
        bool isTargetVisibleOnScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;
        Debug.Log("IsTargetVisible: " + isTargetVisibleOnScreen);

        //Returning opposite due to method naming. 
        return isTargetVisibleOnScreen;
    }
}
