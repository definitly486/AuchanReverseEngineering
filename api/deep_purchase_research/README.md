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

## Questions the source must answer

### SMS
- Does SendPin() first call CheckPhone()?
- Which method actually sends the SMS?
- Is the SMS request made before or after Token80 acquisition?
- Which token is passed to each call, and what are the exact headers,
  query parameters and request body?
- What does the UI/ViewModel await before accepting the four-digit code?

### Loymax URL
- Which dependency-registration method constructs ILoymaxLoyaltyApi?
- Which exact provider is passed to that registration?
- What URL does that provider return for Production?
- Is /ecom part of the base URL or the relative API route?
- Confirm the final URL by joining the registered base URL and route
  attribute; do not infer it from another API client.

### Receipt items
- Which identifier in a history row is passed to the details method?
- What is the exact details endpoint and request body?
- Which response DTO contains product rows?
- Which mapper converts those rows to UI/domain purchase items?
- Are item name, quantity, unit price, total price, discounts and barcode
  actually returned, or are some fields absent?

## Evidence rules

A search hit is only a lead. Read the full containing method and its callers.
If a report has no hits, check whether the managed assembly was successfully
extracted and decompiled. Never substitute a guessed route, host, request
field or token type for missing evidence.

Do not commit real phone numbers, SMS codes, access tokens, cookies, HAR/PCAP
captures, account responses or personal purchase receipts.
