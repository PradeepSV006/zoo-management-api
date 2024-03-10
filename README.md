# Zoo Management API

This API calculates the cost required for feeding the animals in a zoo for a specified number of days.

## Endpoint

HTTP Method: GET

Route: `/api/zoo/cost`

### Query Parameters

- `numDays` (integer): Specifies the number of days for which the cost is to be calculated.

### Response

The API returns the total cost needed for feeding the animals in the zoo for the specified number of days. The response status code can be either 200, 400, or 500, depending on the outcome of the request.

- **200 OK:** The request was successful, and the response contains the calculated cost as {cost : 0.00}.
- **400 Bad Request:** The request is invalid, typically due to missing or invalid parameters.
- **500 Internal Server Error:** An unexpected error occurred during the calculation process.

### More Information

For detailed design decisions and considerations, please refer to the [Design Document](https://github.com/PradeepSV006/zoo-management-api/blob/master/DESIGN-DOCUMENT.md).