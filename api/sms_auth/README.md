# SMS authentication investigation

This directory contains search indexes generated from the decompiled app.
A grep hit is only a lead: it is not proof that the code belongs to the
interactive SMS login flow.

## Investigation order

1. Start with `auth_endpoint_search.txt` and `endpoint_literals_search.txt`.
   Locate the API interface declarations and their HTTP attributes.
2. Find the ViewModel/command/page that starts login. Follow the command into
   the authentication service; this establishes the actual call order.
3. Follow the phone-check request. Record HTTP method, relative route, query
   parameters, headers and response DTO.
4. Follow the SMS-send request. Determine whether the phone is sent as JSON,
   form data or query parameters, and whether a challenge/hash/device ID is
   required. Do not infer these fields from names alone.
5. Follow the code-confirmation request. Record the exact request DTO, route,
   response DTO and error mapping.
6. Follow token creation/refresh. Determine whether `/lk/clientauth/token`
   is called before or after SMS confirmation and how the resulting token is
   associated with the authenticated phone/account.
7. Follow token persistence. Identify whether the app uses SecureStorage,
   Preferences, cookies or an in-memory token service. Never copy real values.
8. Compare managed C# findings with `android_layer_search.txt` and
   `aot_sms_strings_search.txt` when the managed call chain is incomplete.

## Evidence table to complete manually

| Stage | Evidence to record |
|---|---|
| Phone pre-check | method, full URL after resolving the correct base URL, query/body, response |
| SMS dispatch | method, route, body, required headers, response/challenge |
| SMS confirmation | method, route, body, response/error cases |
| Token acquisition | route, order in flow, token response fields |
| Token storage | storage API and key names only; never real values |
| Authenticated API call | how the token is attached to subsequent requests |

## Important

- The existing notes mention `GET /lk/clientauth/token` and
  `GET /lk/clientprofile/checkphone?needHash=False`; their role in the
  complete SMS flow is not yet proven by these strings alone.
- Do not assume that `checkphone` sends an SMS. It may only check the phone
  or return a hash/challenge.
- Do not guess missing routes, request fields, headers or token semantics.
- Do not commit phone numbers, SMS codes, tokens, cookies, HAR/PCAP captures,
  or real account responses.
