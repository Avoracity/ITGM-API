
# Introgami API

Call the Introgami API for a collection of usermade origami and their followers




## API Reference
For statusCode refer to https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.statuscodes?view=aspnetcore-6.0
For SQL constraints refer to https://www.w3schools.com/sql/sql_constraints.asp
## HTTP Methods

#### Get all items

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.

## SQL Constraints

```NOT NULL```

## Endpoints

## Documentation

Models have a basic response model (named Response) 
that returns StatusCode whether or not API endpoint is successful.
String StatusDescription prints statusCode result
List of returned items as properties if GET method used (=new())