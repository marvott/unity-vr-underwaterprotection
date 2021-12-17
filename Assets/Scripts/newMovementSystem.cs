using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


namespace UnityEngine.XR.Interaction.Toolkit
{
    public class newMovementSystem : ContinuousMoveProviderBase
    {
        public GameObject SceneManager;
        public ActionBasedController controller;
        public Camera camera;
        private Vector3 controllerPos, camViewVec;
        private float prevZPos, prevYPos, deltaZ;
        private bool controllerMoved;

        protected override Vector2 ReadInput()
        {
            camViewVec = camera.transform.forward;
            controllerPos= controller.positionAction.action.ReadValue<Vector3>();
            deltaZ = controllerPos.z - prevZPos;
            base.moveSpeed = -deltaZ * 100;
            if (Mathf.Abs(controllerPos.z - prevZPos) >= 0.005)
            {
                controllerMoved = true;
                prevZPos = controllerPos.z;
            }
            else
            {
                controllerMoved = false;
            }

            if (SceneManager.GetComponent<SceneManagerScript>().isRopeTouched() && controllerMoved)
            {

                Vector2 movementVec = new Vector2(0 - camViewVec.x, 1 + (camViewVec.z -1));
                Debug.Log("CamVec" + camViewVec);
                Debug.Log("MoveVec" + movementVec);
                return movementVec;
            }
            else
            {
                return new Vector2(0, 0);
            }
        }

        
    }

}