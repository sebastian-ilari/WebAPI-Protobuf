## WebAPI + ProtoBuf

### Urls of the API
```
http://localhost:49916/api/film
http://localhost:49916/api/fiml/1
```

### ToDos

1. Improve the information returned by the client
  * Move the model to an external project and reference it from both of the other ones
  * Call the new film controller from the client
  * Remove the old ProtobufDTO
  * Remove the Async behavior
  * Create a menu with the following options: Get one film and display its properties; Call films and compare return times on JSON and Protobuf
2. Add heavy image to the data model?