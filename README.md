# LoadScene
This class provides resources for implementing an interface that shows the device's battery level and status.

## Script settings in Inspector
![](../master/Example.png)

## Steps for use
1. Attach the **LoadScene.cs** script to any **GameObject** in the Scene.

2. **On Start:** if 'true' starts loading the scene in the Start () method.

3. **Scene Name:** name of the scene to be called.

4. **Async Load:** starts loading the scene asynchronously.

5. **Wait In Load:** adjusts a time in seconds during the charge cycle.

6. **Progress Bar:** allows you to attach a Slider component to show the scene loading process.

7. **Wait After load:** if 'true', it waits to execute the Execute() method to finish loading the scene.
