# Authentication research

Known endpoints:

GET /lk/clientauth/token

GET /lk/clientprofile/checkphone?needHash=False

The application uses Token80 in the X-Token-CMD header
for the loyalty history API.

SMS request and verification sequence:
Not yet fully established. The decompilation script generates additional
indexes under `api/sms_auth/` for phone checks, SMS dispatch, code confirmation,
HTTP request construction, DTO serialization, Android entry points and AOT
string literals. Follow the calling ViewModel/service chain before treating
any endpoint or field as confirmed.

Known route strings are leads, not a complete authentication protocol:
- GET /lk/clientauth/token
- GET /lk/clientprofile/checkphone?needHash=False

Do not assume that `checkphone` sends an SMS. Establish the separate SMS-send
and code-confirmation operations from their call sites and request DTOs.

Do not store real phone numbers, SMS codes, tokens or cookies here.
