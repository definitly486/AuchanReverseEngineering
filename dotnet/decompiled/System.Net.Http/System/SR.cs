using System.Resources;
using FxResources.System.Net.Http;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = true;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string net_http_httpmethod_format_error => "net_http_httpmethod_format_error";

	internal static string net_http_reasonphrase_format_error => "net_http_reasonphrase_format_error";

	internal static string net_http_copyto_array_too_small => "net_http_copyto_array_too_small";

	internal static string net_http_headers_not_found => "net_http_headers_not_found";

	internal static string net_http_headers_single_value_header => "net_http_headers_single_value_header";

	internal static string net_http_headers_invalid_header_name => "net_http_headers_invalid_header_name";

	internal static string net_http_headers_invalid_value => "net_http_headers_invalid_value";

	internal static string net_http_headers_not_allowed_header_name => "net_http_headers_not_allowed_header_name";

	internal static string net_http_headers_invalid_host_header => "net_http_headers_invalid_host_header";

	internal static string net_http_headers_invalid_range => "net_http_headers_invalid_range";

	internal static string net_http_headers_no_newlines_no_nul => "net_http_headers_no_newlines_no_nul";

	internal static string net_http_content_buffersize_exceeded => "net_http_content_buffersize_exceeded";

	internal static string net_http_content_no_task_returned => "net_http_content_no_task_returned";

	internal static string net_http_content_stream_already_read => "net_http_content_stream_already_read";

	internal static string net_http_content_readonly_stream => "net_http_content_readonly_stream";

	internal static string net_http_content_writeonly_stream => "net_http_content_writeonly_stream";

	internal static string net_http_content_invalid_charset => "net_http_content_invalid_charset";

	internal static string net_http_content_stream_copy_error => "net_http_content_stream_copy_error";

	internal static string net_http_content_read_as_stream_has_task => "net_http_content_read_as_stream_has_task";

	internal static string net_http_client_request_already_sent => "net_http_client_request_already_sent";

	internal static string net_http_operation_started => "net_http_operation_started";

	internal static string net_http_client_execution_error => "net_http_client_execution_error";

	internal static string net_http_client_absolute_baseaddress_required => "net_http_client_absolute_baseaddress_required";

	internal static string net_http_client_invalid_requesturi => "net_http_client_invalid_requesturi";

	internal static string net_http_unsupported_requesturi_scheme => "net_http_unsupported_requesturi_scheme";

	internal static string net_http_parser_invalid_base64_string => "net_http_parser_invalid_base64_string";

	internal static string net_http_handler_noresponse => "net_http_handler_noresponse";

	internal static string net_http_message_not_success_statuscode => "net_http_message_not_success_statuscode";

	internal static string net_http_message_not_success_statuscode_reason => "net_http_message_not_success_statuscode_reason";

	internal static string net_http_content_field_too_long => "net_http_content_field_too_long";

	internal static string net_http_log_headers_no_newlines => "net_http_log_headers_no_newlines";

	internal static string net_http_log_headers_invalid_quality => "net_http_log_headers_invalid_quality";

	internal static string net_http_handler_not_assigned => "net_http_handler_not_assigned";

	internal static string net_http_invalid_enable_first => "net_http_invalid_enable_first";

	internal static string net_http_content_buffersize_limit => "net_http_content_buffersize_limit";

	internal static string net_http_chunked_not_allowed_with_empty_content => "net_http_chunked_not_allowed_with_empty_content";

	internal static string net_http_value_must_be_greater_than_or_equal => "net_http_value_must_be_greater_than_or_equal";

	internal static string net_http_invalid_response => "net_http_invalid_response";

	internal static string net_http_request_content_length_mismatch => "net_http_request_content_length_mismatch";

	internal static string net_http_invalid_response_premature_eof => "net_http_invalid_response_premature_eof";

	internal static string net_http_invalid_response_missing_frame => "net_http_invalid_response_missing_frame";

	internal static string net_http_invalid_response_premature_eof_bytecount => "net_http_invalid_response_premature_eof_bytecount";

	internal static string net_http_invalid_response_chunk_header_invalid => "net_http_invalid_response_chunk_header_invalid";

	internal static string net_http_invalid_response_chunk_extension_invalid => "net_http_invalid_response_chunk_extension_invalid";

	internal static string net_http_invalid_response_chunk_terminator_invalid => "net_http_invalid_response_chunk_terminator_invalid";

	internal static string net_http_invalid_response_status_line => "net_http_invalid_response_status_line";

	internal static string net_http_invalid_response_status_code => "net_http_invalid_response_status_code";

	internal static string net_http_invalid_response_status_reason => "net_http_invalid_response_status_reason";

	internal static string net_http_invalid_response_multiple_status_codes => "net_http_invalid_response_multiple_status_codes";

	internal static string net_http_invalid_response_header_line => "net_http_invalid_response_header_line";

	internal static string net_http_invalid_response_header_name => "net_http_invalid_response_header_name";

	internal static string net_http_request_aborted => "net_http_request_aborted";

	internal static string net_http_invalid_response_pseudo_header_in_trailer => "net_http_invalid_response_pseudo_header_in_trailer";

	internal static string net_http_request_headers_exceeded_length => "net_http_request_headers_exceeded_length";

	internal static string net_http_response_headers_exceeded_length => "net_http_response_headers_exceeded_length";

	internal static string ObjectDisposed_StreamClosed => "ObjectDisposed_StreamClosed";

	internal static string net_http_invalid_proxy_scheme => "net_http_invalid_proxy_scheme";

	internal static string net_http_request_invalid_char_encoding => "net_http_request_invalid_char_encoding";

	internal static string net_http_ssl_connection_failed => "net_http_ssl_connection_failed";

	internal static string net_http_unsupported_chunking => "net_http_unsupported_chunking";

	internal static string net_http_unsupported_version => "net_http_unsupported_version";

	internal static string IO_SeekBeforeBegin => "IO_SeekBeforeBegin";

	internal static string net_ssl_http2_requires_tls12 => "net_ssl_http2_requires_tls12";

	internal static string net_http_request_no_host => "net_http_request_no_host";

	internal static string net_http_http2_connection_error => "net_http_http2_connection_error";

	internal static string net_http_http2_connection_close => "net_http_http2_connection_close";

	internal static string net_http_http2_stream_error => "net_http_http2_stream_error";

	internal static string net_http_http3_stream_error => "net_http_http3_stream_error";

	internal static string net_http_http2_connection_not_established => "net_http_http2_connection_not_established";

	internal static string net_http_http2_invalidinitialstreamwindowsize => "net_http_http2_invalidinitialstreamwindowsize";

	internal static string net_http_http2_frame_limit_exceeded => "net_http_http2_frame_limit_exceeded";

	internal static string net_http_authconnectionfailure => "net_http_authconnectionfailure";

	internal static string net_http_authvalidationfailure => "net_http_authvalidationfailure";

	internal static string net_http_hpack_huffman_decode_failed => "net_http_hpack_huffman_decode_failed";

	internal static string net_http_hpack_incomplete_header_block => "net_http_hpack_incomplete_header_block";

	internal static string net_http_hpack_late_dynamic_table_size_update => "net_http_hpack_late_dynamic_table_size_update";

	internal static string net_http_hpack_bad_integer => "net_http_hpack_bad_integer";

	internal static string net_http_disposed_while_in_use => "net_http_disposed_while_in_use";

	internal static string net_http_hpack_large_table_size_update => "net_http_hpack_large_table_size_update";

	internal static string net_http_server_shutdown => "net_http_server_shutdown";

	internal static string net_http_hpack_invalid_index => "net_http_hpack_invalid_index";

	internal static string net_http_hpack_unexpected_end => "net_http_hpack_unexpected_end";

	internal static string net_http_headers_exceeded_length => "net_http_headers_exceeded_length";

	internal static string net_http_invalid_header_name => "net_http_invalid_header_name";

	internal static string net_http_http3_connection_error => "net_http_http3_connection_error";

	internal static string net_http_http3_connection_close => "net_http_http3_connection_close";

	internal static string net_http_http3_connection_quic_error => "net_http_http3_connection_quic_error";

	internal static string net_http_retry_on_older_version => "net_http_retry_on_older_version";

	internal static string net_http_content_write_larger_than_content_length => "net_http_content_write_larger_than_content_length";

	internal static string net_http_qpack_no_dynamic_table => "net_http_qpack_no_dynamic_table";

	internal static string net_http_request_timedout => "net_http_request_timedout";

	internal static string net_http_connect_timedout => "net_http_connect_timedout";

	internal static string net_http_missing_sync_implementation => "net_http_missing_sync_implementation";

	internal static string net_http_http2_sync_not_supported => "net_http_http2_sync_not_supported";

	internal static string net_http_upgrade_not_enabled_sync => "net_http_upgrade_not_enabled_sync";

	internal static string net_http_requested_version_cannot_establish => "net_http_requested_version_cannot_establish";

	internal static string net_http_requested_version_server_refused => "net_http_requested_version_server_refused";

	internal static string net_http_exception_during_plaintext_filter => "net_http_exception_during_plaintext_filter";

	internal static string net_http_null_from_connect_callback => "net_http_null_from_connect_callback";

	internal static string net_http_null_from_plaintext_filter => "net_http_null_from_plaintext_filter";

	internal static string net_socks_auth_failed => "net_socks_auth_failed";

	internal static string net_socks_bad_address_type => "net_socks_bad_address_type";

	internal static string net_socks_connection_failed => "net_socks_connection_failed";

	internal static string net_socks_ipv6_notsupported => "net_socks_ipv6_notsupported";

	internal static string net_socks_no_auth_method => "net_socks_no_auth_method";

	internal static string net_socks_no_ipv4_address => "net_socks_no_ipv4_address";

	internal static string net_socks_unexpected_version => "net_socks_unexpected_version";

	internal static string net_socks_string_too_long => "net_socks_string_too_long";

	internal static string net_socks_auth_required => "net_socks_auth_required";

	internal static string net_http_proxy_tunnel_returned_failure_status_code => "net_http_proxy_tunnel_returned_failure_status_code";

	internal static string net_http_proxy_tunnel_error => "net_http_proxy_tunnel_error";

	internal static string net_http_chunk_too_large => "net_http_chunk_too_large";

	internal static string net_unsupported_extended_connect => "net_unsupported_extended_connect";

	internal static string net_ping_request_timed_out => "net_ping_request_timed_out";

	private static bool GetUsingResourceKeysSwitchValue()
	{
		return true;
	}

	internal static bool UsingResourceKeys()
	{
		return true;
	}

	private static string GetResourceString(string resourceKey)
	{
		_ = 1;
		return resourceKey;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray2<object> buffer = default(global::_003C_003Ey__InlineArray2<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 1) = p1;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<object>, object>(in buffer, 2));
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray3<object> buffer = default(global::_003C_003Ey__InlineArray3<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 1) = p1;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 2) = p2;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<object>, object>(in buffer, 3));
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = p1;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = p2;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = p3;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray2<object> buffer = default(global::_003C_003Ey__InlineArray2<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<object>, object>(ref buffer, 1) = p1;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<object>, object>(in buffer, 2));
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
	{
		_ = 1;
		global::_003C_003Ey__InlineArray3<object> buffer = default(global::_003C_003Ey__InlineArray3<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 0) = resourceFormat;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 1) = p1;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 2) = p2;
		return string.Join(", ", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<object>, object>(in buffer, 3));
	}
}
