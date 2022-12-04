# BindyAppDemo
Unity App demo based on supplied requirements

### Unity version 
2021.3.9f1 (LTS)

### Resolution
1920x1080

### Networking
Due to lack of networking project experience I have structured the project as follows. 

ApiController class utilises UnityWebRequest to request data from photos endpoint.

DataManager class issues the initial call to ApiController and subscribes to event of succesfull response.

ErrorPanel class subscribed to error response

### Texture Loading
TextureLoader is a script responsible for loading Texture using UnityWebTextureRequest as Unity docs state it is the most efficient way to download texture in Unity.
TextureLoader is attached to every scroll entry instance and is an instance by itself. Therefore scroll entry object subscribes to that particular instance events rather than static events.   
TextureLoader emits 3 events OnLoading, OnLoaded and OnError.

### Rounded Corners
There was an issue with rounded corners on sprites even sprite was configured during import to stretch correctly. There's no time to test on different devices. Might be issues with stretching sprites.
