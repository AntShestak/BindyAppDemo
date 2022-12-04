# BindyAppDemo
Unity App demo based on supplied requirements

### Unity version 
2021.3.9f1 (LTS)

### Networking
Due to lack of networking project experience I have structured the project as follows. 

ApiController class utilises UnityWebRequest to request data from photos endpoint.

DataManager class issues the initial call to ApiController and subscribes to event of succesfull response.

ErrorPanel class subscribed to error response
