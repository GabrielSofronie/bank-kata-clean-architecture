# Bank account kata

Illustrate the application of TDD and Clean Architecture.

## Requirements
---------
Build an API to return a bank account statement (date, credit, debit).

### API specification

> GET /api/accounts/{id}/statement

_Returns account statement_

#### Parameters

id (path) : ID of a bank account

#### Responses

```
{
	"accountId": "string",
	"statements": [{
		"date": "string",
		"credit": integer,
		"debit": integer
	}]
}
```