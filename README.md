# BindyAppDemo
Unity App demo based on supplied requirements

### Unity version 
2021.3.9f1 (LTS)

### Resolution
1920x1080

### Networking
Due to lack of networking project experience I have structured the project as follows. 

ApiController class utilises UnityWebRequest to request data from photos endpoint.

DataManager class issues the initial call to ApiController.

ErrorPanel class subscribed to error response.

Observers subscribe to ApiController's event, although request data with a call to DataManager. This has to be refactored.

### Texture Loading
TextureLoader is a script responsible for loading Texture using UnityWebTextureRequest as Unity docs state it is the most efficient way to download texture in Unity.
TextureLoader is attached to every scroll entry instance and is an instance by itself. Therefore scroll entry object subscribes to that particular instance events rather than static events.   
TextureLoader emits 3 events OnLoading, OnLoaded and OnError.

### Rounded Corners
There was an issue with rounded corners on images although sprite was configured during import to stretch correctly. There's no time to test on different devices. Might be issues with stretching sprites. 

### Page 2
Health bar is attached to skeleton joint, which is not right. But should be okay for this example. 

### Radial Zoom
Swipe controls (only for mouse) implemented but I left the buttons anyway for easier testing.

Generally Radial Zoom logic should be reworked. Probably using a more suitable collection for entries rather than List<>.

### Issues

Had to lock inputs for short time on Radial Zoom Pattern. If inputs appear to quickly, entries move directly to the new position, skipping the intermediate position and not following intended pattern. That is an issue.

Connection Error Messaging doesn't always appear on error panel as intended. Currently no time to look into it.

### Code Refactoring
Texture objects are the same on Page1 and Page2, class should be extracted to make an object usable for both cases to improve code reusability.

Network controllers logic should be better structured to create more straighforward and logical data passing from providers to observers.
Currently observer subscribes to event of controller class but requests data through data manager class which calls the controller. This definetely has to be restructured.







