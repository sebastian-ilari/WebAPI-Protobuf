## WebAPI + ProtoBuf

### Urls of the API
```
http://localhost:49916/api/values
http://localhost:49916/api/values/5
```

### ToDos
1. Add a more realistic data model
	a. Two objects with a relationship
	b. Collections?
	c. A heavy image?
2. Improve the information returned by the client
	a. Display the new data model in a more readable way
	b. Display a timestamp before calling the service and after it returns (may have to remove the async behavior)
	c. Add an option to call the same GET multiple times
		i. Ask the user how many times
		ii. Only display timestamps (JSON and Protobuf)
