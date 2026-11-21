# Deep purchase-history investigation

Generated automatically by decompile_auchan.sh.

## Reports

1. 01_pin_interactor_sendpin.txt — surrounding source for the SMS PIN
   interactor, phone checks, SMS dispatch and verification methods.
2. 01_pin_interactor_references.txt — exact C# references/call sites.
3. 02_loymax_url_provider.txt — provider, environment selection, HTTP
   client setup and API registration with surrounding source.
4. 02_loymax_registration_references.txt — C# registration/provider hits.
5. 03_receipt_items_and_details.txt — receipt-detail methods, response
   models, product fields and mapping code.
6. 03_receipt_item_references.txt — focused C# references.
7. 07_token20_client_password.txt — Token20 source, format and serialization.
8. 07_token20_client_password_references.txt — focused C# references.
9. 08_device_id_udid_mapping.txt — generated Device ID vs original UDID.
10. 08_device_id_udid_mapping_references.txt — focused C# references.
11. 09_needhash_true_response.txt — needHash=true request and response.
12. 09_needhash_true_response_references.txt — focused C# references.
13. 10_cheque_number_detail_loading.txt — chequeNumber details call chain,
    automatic/on-demand loading, loops and batching.
14. 10_cheque_number_detail_loading_references.txt — focused C# references.
15. 11_token20_checkphone_beginverify_token80_verifyphone_sequence.txt — source context for the complete phone-authentication chain.
16. 11_authentication_sequence_references.txt — exact references and call sites for each authentication stage.
17. 12_loymax_api_auth_bridge.txt — correlates verified authentication/token flow with the registered Loymax API client, Production base URL, history route and token header.
18. 12_loymax_api_auth_bridge_references.txt — focused C# references for that API bridge.

## Questions the source must answer

### SMS
- Does SendPin() first call CheckPhone()?
- Which method actually sends the SMS?
- Is the SMS request made before or after Token80 acquisition?
- Which token is passed to each call, and what are the exact headers,
  query parameters and request body?
- What is Token20 exactly: source value, byte/string format, transformations
  (hashing/encoding), and serialized location in the request?
- What does the UI/ViewModel await before accepting the four-digit code?

### Complete phone authentication sequence
- Locate the source and exact wire representation of Token20. Is it a constant, derived value, or response field? Do not print live credentials.
- Find the caller of CheckPhone and record its method, route, query/body, headers, response DTO and error handling.
- Follow BeginVerifyPhone from its call site. Determine whether it dispatches the SMS, creates a challenge, or performs another operation.
- Establish exactly when Token80 is requested, which response field supplies it, and whether it is cached or refreshed.
- Follow VerifyPhone and record the code/challenge fields, HTTP method, route, headers, response DTO and success/failure branches.
- Build a source-backed call graph with caller/callee evidence. If the observed order differs from the proposed sequence, report the observed order.
- Never include actual phone numbers, SMS codes, Token20/Token80 values, cookies or account-specific responses.

### Loymax URL
- Which dependency-registration method constructs ILoymaxLoyaltyApi?
- Which exact provider is passed to that registration?
- What URL does that provider return for Production?
- Is /ecom part of the base URL or the relative API route?
- Confirm the final URL by joining the registered base URL and route
  attribute; do not infer it from another API client.

### Receipt items
- Which identifier in a history row is passed to the details method?
- Is the field named chequeNumber, and is it transformed before the request?
- Are details requested automatically for every history row (loop/batch/
  parallel), or only when a receipt is opened?
- What is the exact details endpoint and request body?
- Which response DTO contains product rows?
- Which mapper converts those rows to UI/domain purchase items?
- Are item name, quantity, unit price, total price, discounts and barcode
  actually returned, or are some fields absent?

### Device identity and needHash

- Which exact platform/API call supplies the original UDID?
- Is Device ID generated, persisted, or read from Android ID?
- Compare source value, format, casing and transformations; do not assume
  UUID-like identifiers are interchangeable.
- What request is made with needHash=true, and what does the server return
  (status, content type, DTO fields, hash/challenge/error)?
- Compare true/false branches without recording real account secrets.

## Evidence rules

A search hit is only a lead. Read the full containing method and its callers.
If a report has no hits, check whether the managed assembly was successfully
extracted and decompiled. Never substitute a guessed route, host, request
field or token type for missing evidence.

Do not commit real phone numbers, SMS codes, access tokens, cookies, HAR/PCAP
captures, account responses or personal purchase receipts.
