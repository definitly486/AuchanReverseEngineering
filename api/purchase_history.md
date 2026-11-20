# Purchase history API

Known endpoint:

POST /ecom/lk/loyalty/history

Known header:

X-Token-CMD: Token80

Known request:

{
  "channel": "M",
  "pagination": {
    "offset": 0,
    "limit": 10
  },
  "filter": {
    "id": 2
  }
}

Known pagination:

ItemsPerPage = 10

Offsets:

0, 10, 20, 30 ...

Filter id 2: Purchases

Filter id 6: Stamp operations

Response pagination and all server fields must be verified
against complete responses.
