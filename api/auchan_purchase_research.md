# Auchan purchase-history reverse-engineering index

This file is generated from the decompiled C# source. Search reports contain
file paths and matching lines; inspect the referenced methods before treating
any request shape or host as confirmed.

## Reports

- `purchase_history_search.txt` — history service methods and API calls
- `endpoints_search.txt` — endpoint attributes and route strings
- `dto_search.txt` — response/request DTO references
- `loymax_registration_search.txt` — registration of `ILoymaxLoyaltyApi`
- `base_url_search.txt` — environment URL providers and HTTP client setup
- `token_flow_search.txt` — `ITokenService`, Token80 and request header references
- `receipt_details_search.txt` — receipt-detail methods and product-line models
- `authentication_search.txt` — authentication-related source references
- `sms_auth/` — expanded SMS-login investigation indexes and workflow checklist

## What must be established

1. Find the exact dependency-registration method that constructs
   `ILoymaxLoyaltyApi` and identify the URL provider passed to it.
2. Follow that provider for the Production environment. Do not infer the
   Loymax host from an unrelated provider such as feedback or personal cabinet.
3. Inspect `ILoymaxLoyaltyApi.cs` for the exact route attribute and header.
4. Inspect `LoyaltyProgramPurchasesHistoryService.cs` for the serialized
   request body used by both history and receipt-detail methods.
5. Follow `ITokenService` to determine where the app obtains and stores its
   Token80. Never commit a real token, cookie, phone number or SMS code.
6. Follow the response DTO and mapper to identify the receipt identifier and
   the product rows returned by the detail request.

## Important distinction

A history response is not necessarily a receipt with itemized products.
The list of purchases and the contents of each receipt may require separate
requests. Verify the detail method and its DTO before implementing that step.

## Endpoint notation

The route attribute in the API interface is a relative path. The final URL is
formed by combining it with the base URL of the exact registered HTTP client.
Do not add or remove `/ecom` until that registration has been verified.
