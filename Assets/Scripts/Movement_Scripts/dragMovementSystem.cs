/***************************************************************************************************************************
 *This script provides a MovementSystem for dragging the player along the rope through the world. It gives the possibility
 *to move along the rope in both directions. Therefor the player has to grap the rope with his left hand by pushing the grip
 *button. Then he can drag himself just like he would do in the real world along the rope. 
 ***************************************************************************************************************************/

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class dragMovementSystem : ContinuousMoveProviderBase
    {
        public GameObject SceneManager;
        public ActionBasedController controller; //LeftHand Controller.
        public Camera camera;
        private Vector3 controllerPos, camViewVec;
        private Vector2 movementVec;
        private float prevZPos, deltaZ;
        private bool controllerMoved;

        /*********************************************************************************************************************
         * Gets called continuously asking for a movement direction.
         * Return: Direction in which movement should lead (Vector2)
        **********************************************************************************************************************/
        protected override Vector2 ReadInput()
        {
            camViewVec = camera.transform.forward;
            controllerPos= controller.positionAction.action.ReadValue<Vector3>();
            deltaZ = controllerPos.z - prevZPos;
            base.moveSpeed = -deltaZ * 100; //moveSpeed dertermines the direction and speed of drag Movement.
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

                movementVec = new Vector2(0 - camViewVec.x, 1 + (camViewVec.z -1)); //movementVec is always interpreted according to the players viewing angle. To always get a Vector (0,1) in the world coordinate system the viewing angle is computet corresponding.
                return movementVec;
            }
            else
            {
                movementVec = new Vector2(0, 0); //if the rope is not touched or the controller is not moved there is no drag Movement.
                return movementVec;
            }
        }

        
    }

}