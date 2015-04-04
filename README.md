## WebAPI + ProtoBuf

### Urls of the API
```
http://localhost:49916/api/values
http://localhost:49916/api/values/5
```

### ToDos
1. Add a more realistic data model
1.a. Two objects with a relationship
1.b. Collections?
1.c. A heavy image?
2. Improve the information returned by the client
2.a. Display the new data model in a more readable way
2.b. Display a timestamp before calling the service and after it returns (may have to remove the async behavior)
2.c. Add an option to call the same GET multiple times
2.c.i. Ask the user how many times
2.c.ii. Only display timestamps (JSON and Protobuf)
