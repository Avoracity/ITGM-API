
# Introgami API

Call the Introgami API for a collection of usermade origami and their followers




## API Reference

For statusCode refer to https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.statuscodes?view=aspnetcore-6.0
For SQL constraints refer to https://www.w3schools.com/sql/sql_constraints.asp

## HTTP Methods

#### Get all users

```http
  GET /api/users
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Delete user

```http
  DELETE /api/users/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### Post new user

```http
  POST /api/users/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to post  |



## SQL Constraints

```NOT NULL```

## Endpoints

## Documentation

Models have a basic response model (named Response) 
that returns StatusCode whether or not API endpoint is successful.
String StatusDescription prints statusCode result
List of returned items as properties if GET method used (=new())

User contains:
	primary key 
	string of username
	list of users followed
	list of origami 

Following contains:
	primary key
	foreign key - list of users

Origami contains:
	primary key
	string of origami name
	string of origami description

