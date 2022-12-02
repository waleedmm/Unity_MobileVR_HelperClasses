# Unity_MobileVR_HelperClasses
a group of helper classes for unity google cardboard VR sdk to enable:
1. teleportation
2. interaction with UI
3. interaction with objects
4. Gaze based circular progress

It needs first to follow Google Carboard here: https://developers.google.com/cardboard/develop/unity/quickstart 
then add those scripts

# Mobile Controls
The mobile application is gaze based, so it depends on head rotation and eye looking duration.
1. camera rotation: is done by rotating head
2. Movement (Walking): it’s teleportation based. So, you can move by looking 2 seconds into one of the green boxes on the ground. When the yellow circle completes the teleportation is executed and position changes.

![moving](/move.PNG)

3. Using items and UI buttons: if item is usable, then by looking at it a blue panel appears, and if looking time is 2 seconds, then a yellow circle is completed and the item is used. 

![using](/use-1.PNG)
![using](/ui.PNG)
