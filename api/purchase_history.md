# Purchase history API

Source-level findings:

- The decompiled interface declares a relative route for `LoyaltyHistory`.
- The request sends the `X-Token-CMD` header using the Token80 value obtained
  through the application's token service.
- The history service maps `LoymaxHistoryResponseDto` into purchase models.
- Filter id `2` is identified as purchases; filter id `6` as stamp operations
  in the reverse-engineering notes. Verify against the request-building code.

The final URL must be determined from the dependency registration for
`ILoymaxLoyaltyApi`. Do not assume `/ecom` belongs in the route or base URL
until the exact provider used by that client has been identified.

The request body, pagination and receipt-detail request must be verified
against `LoyaltyProgramPurchasesHistoryService.cs` and the related DTOs.
A history record is not necessarily an itemized receipt.
