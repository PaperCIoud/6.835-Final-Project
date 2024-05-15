README

Here is the Unity project that was run and used for the 6.8510 final project. There are a lot of tiles in here, from assets to base Unity inputs. We were not able to get a built version made as it was never tested with a built version, so I will list the important scenes that can be run in the Unity editor to view the programs that we ran. 

Prerequisites to run: All above mentioned packages (excluding kinect package example asset, which is already included)

Important scene to play/use: 

Base cube unity view: Assets/Scenes/AnamorphocTest.unity
This scene shows the base view in the main anamorphic projection. The cube in the center can be interacted with through the leap motion. 
User test scene for task 1: Assets/Scenes/UserTest.unity
This scene is what was shown to outside users to test the intuitiveness and naturalness of the interaction of both hand and camera tracking. 
Chess Demo: Assets/Scenes/Possible3.unity
This is the view that shows the chess scene with a hidden king and queen that can only be seen by moving around the scene. This meant to be a very easy puzzle. This scene is not intractable with hands. 
*The town scene is not present in the git project due to being too large of a file to upload. 


Here are some important files and scripts that we made to allow our scene to run: 

Assets/Scripts/UserCalibration.cs - This was the code that controls users calibration. It watches for clicks on the screen at specific parts to orient the user to the scene properly
Assets/Scripts/LeapRotater.cs - This script controls where the leap motion is and handles the rotation of the virtual hands depending on the position of the player Assets/Scripts/OffCenterCamera.cs - This script does the anamorphic projection onto the camera and handles flipping the projection orientation based on the position of the user (whether they are behind or infront of the xy plane). 
Assets/KinectScripts/Cubeman/CubemanController.cs - This is the script that gets the skeleton of the user from the kinect manager
Assets/KinectScripts/KinectManager.cs - This is what controls and checks that the kinect is connected and manages settings about where the connect is in real life (height, angle, ect)

Here are the instructions on how calibration occurs: 
1. The user should face the Kinect camera directly with the front view of the tablet in front of them
2. Hold in T-pose position until the Kinect camera recognizes them
3. Stand in an upright pose with their head looking directly forward, click the game scene once to record head position
4. While still standing directly in front of the tablet, lean towards the tablet so their head is right above the screen, click the game scene to record position
5. Move to the direct left of the tablet, hold upright position and click the game scene
6. Move to the direct back of the tablet, hold upright position and click the game scene
7. Move to the direct right of the tablet, hold upright position and click the game scene
8. Center should now be calculated, so the user must go out of the range of the Kinect camera to allow for the scene to reset. 
9. Move back to the front position facing the Kinect and hold T-pose to let the Kinect camera reconnect. The scene should now be calibrated to the user
