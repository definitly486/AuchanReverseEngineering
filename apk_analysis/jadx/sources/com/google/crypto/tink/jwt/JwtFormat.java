package com.google.crypto.tink.jwt;

import com.google.crypto.tink.internal.Util;
import com.google.crypto.tink.proto.OutputPrefixType;
import com.google.crypto.tink.subtle.Base64;
import com.google.gson.JsonObject;
import java.nio.ByteBuffer;
import java.nio.charset.CharacterCodingException;
import java.security.InvalidAlgorithmParameterException;
import java.util.Optional;

/* JADX INFO: loaded from: classes2.dex */
final class JwtFormat {
    static boolean isValidUrlsafeBase64Char(char c) {
        if (c >= 'a' && c <= 'z') {
            return true;
        }
        if (c < 'A' || c > 'Z') {
            return (c >= '0' && c <= '9') || c == '-' || c == '_';
        }
        return true;
    }

    static class Parts {
        String header;
        String payload;
        byte[] signatureOrMac;
        String unsignedCompact;

        Parts(String str, byte[] bArr, String str2, String str3) {
            this.unsignedCompact = str;
            this.signatureOrMac = bArr;
            this.header = str2;
            this.payload = str3;
        }
    }

    private JwtFormat() {
    }

    static void validateUtf8(byte[] bArr) throws JwtInvalidException {
        try {
            Util.UTF_8.newDecoder().decode(ByteBuffer.wrap(bArr));
        } catch (CharacterCodingException e) {
            throw new JwtInvalidException(e.getMessage());
        }
    }

    static byte[] strictUrlSafeDecode(String str) throws JwtInvalidException {
        for (int i = 0; i < str.length(); i++) {
            if (!isValidUrlsafeBase64Char(str.charAt(i))) {
                throw new JwtInvalidException("invalid encoding");
            }
        }
        try {
            return Base64.urlSafeDecode(str);
        } catch (IllegalArgumentException e) {
            throw new JwtInvalidException("invalid encoding: " + e);
        }
    }

    private static void validateAlgorithm(String str) throws InvalidAlgorithmParameterException {
        str.getClass();
        switch (str) {
            case "ES256":
            case "ES384":
            case "ES512":
            case "HS256":
            case "HS384":
            case "HS512":
            case "PS256":
            case "PS384":
            case "PS512":
            case "RS256":
            case "RS384":
            case "RS512":
                return;
            default:
                throw new InvalidAlgorithmParameterException("invalid algorithm: " + str);
        }
    }

    static String createHeader(String str, Optional<String> optional, Optional<String> optional2) throws InvalidAlgorithmParameterException {
        validateAlgorithm(str);
        JsonObject jsonObject = new JsonObject();
        if (optional2.isPresent()) {
            jsonObject.addProperty("kid", optional2.get());
        }
        jsonObject.addProperty("alg", str);
        if (optional.isPresent()) {
            jsonObject.addProperty("typ", optional.get());
        }
        return Base64.urlSafeEncode(jsonObject.toString().getBytes(Util.UTF_8));
    }

    private static void validateKidInHeader(String str, JsonObject jsonObject) throws JwtInvalidException {
        if (!getStringHeader(jsonObject, "kid").equals(str)) {
            throw new JwtInvalidException("invalid kid in header");
        }
    }

    static void validateHeader(JsonObject jsonObject, String str, Optional<String> optional, boolean z) throws JwtInvalidException, InvalidAlgorithmParameterException {
        String stringHeader = getStringHeader(jsonObject, "alg");
        if (!stringHeader.equals(str)) {
            throw new InvalidAlgorithmParameterException(String.format("invalid algorithm; expected %s, got %s", str, stringHeader));
        }
        if (jsonObject.has("crit")) {
            throw new JwtInvalidException("all tokens with crit headers are rejected");
        }
        boolean zHas = jsonObject.has("kid");
        if (zHas || !z) {
            if (!zHas && !z) {
                throw new JwtInvalidException("missing kid in header");
            }
            if (optional.isPresent() && !getStringHeader(jsonObject, "kid").equals(optional.get())) {
                throw new JwtInvalidException("invalid kid in header");
            }
        }
    }

    static void validateHeader(String str, Optional<String> optional, Optional<String> optional2, JsonObject jsonObject) throws JwtInvalidException, InvalidAlgorithmParameterException {
        validateAlgorithm(str);
        String stringHeader = getStringHeader(jsonObject, "alg");
        if (!stringHeader.equals(str)) {
            throw new InvalidAlgorithmParameterException(String.format("invalid algorithm; expected %s, got %s", str, stringHeader));
        }
        if (jsonObject.has("crit")) {
            throw new JwtInvalidException("all tokens with crit headers are rejected");
        }
        if (optional.isPresent() && optional2.isPresent()) {
            throw new JwtInvalidException("custom_kid can only be set for RAW keys.");
        }
        boolean zHas = jsonObject.has("kid");
        if (optional.isPresent()) {
            if (!zHas) {
                throw new JwtInvalidException("missing kid in header");
            }
            validateKidInHeader(optional.get(), jsonObject);
        }
        if (optional2.isPresent() && zHas) {
            validateKidInHeader(optional2.get(), jsonObject);
        }
    }

    static Optional<String> getTypeHeader(JsonObject jsonObject) {
        if (jsonObject.has("typ")) {
            return Optional.of(getStringHeader(jsonObject, "typ"));
        }
        return Optional.empty();
    }

    static String getStringHeader(JsonObject jsonObject, String str) throws JwtInvalidException {
        if (!jsonObject.has(str)) {
            throw new JwtInvalidException("header " + str + " does not exist");
        }
        if (!jsonObject.get(str).isJsonPrimitive() || !jsonObject.get(str).getAsJsonPrimitive().isString()) {
            throw new JwtInvalidException("header " + str + " is not a string");
        }
        return jsonObject.get(str).getAsString();
    }

    static String decodeHeader(String str) throws JwtInvalidException {
        byte[] bArrStrictUrlSafeDecode = strictUrlSafeDecode(str);
        validateUtf8(bArrStrictUrlSafeDecode);
        return new String(bArrStrictUrlSafeDecode, Util.UTF_8);
    }

    static String encodePayload(String str) {
        return Base64.urlSafeEncode(str.getBytes(Util.UTF_8));
    }

    static String decodePayload(String str) throws JwtInvalidException {
        byte[] bArrStrictUrlSafeDecode = strictUrlSafeDecode(str);
        validateUtf8(bArrStrictUrlSafeDecode);
        return new String(bArrStrictUrlSafeDecode, Util.UTF_8);
    }

    static String encodeSignature(byte[] bArr) {
        return Base64.urlSafeEncode(bArr);
    }

    static byte[] decodeSignature(String str) {
        return strictUrlSafeDecode(str);
    }

    static Optional<String> getKid(int i, OutputPrefixType outputPrefixType) throws JwtInvalidException {
        if (outputPrefixType == OutputPrefixType.RAW) {
            return Optional.empty();
        }
        if (outputPrefixType == OutputPrefixType.TINK) {
            return Optional.of(Base64.urlSafeEncode(ByteBuffer.allocate(4).putInt(i).array()));
        }
        throw new JwtInvalidException("unsupported output prefix type");
    }

    static Optional<Integer> getKeyId(String str) {
        byte[] bArrUrlSafeDecode = Base64.urlSafeDecode(str);
        if (bArrUrlSafeDecode.length != 4) {
            return Optional.empty();
        }
        return Optional.of(Integer.valueOf(ByteBuffer.wrap(bArrUrlSafeDecode).getInt()));
    }

    static Parts splitSignedCompact(String str) throws JwtInvalidException {
        validateASCII(str);
        int iLastIndexOf = str.lastIndexOf(46);
        if (iLastIndexOf < 0) {
            throw new JwtInvalidException("only tokens in JWS compact serialization format are supported");
        }
        String strSubstring = str.substring(0, iLastIndexOf);
        byte[] bArrDecodeSignature = decodeSignature(str.substring(iLastIndexOf + 1));
        int iIndexOf = strSubstring.indexOf(46);
        if (iIndexOf < 0) {
            throw new JwtInvalidException("only tokens in JWS compact serialization format are supported");
        }
        String strSubstring2 = strSubstring.substring(0, iIndexOf);
        String strSubstring3 = strSubstring.substring(iIndexOf + 1);
        if (strSubstring3.indexOf(46) > 0) {
            throw new JwtInvalidException("only tokens in JWS compact serialization format are supported");
        }
        return new Parts(strSubstring, bArrDecodeSignature, decodeHeader(strSubstring2), decodePayload(strSubstring3));
    }

    static String createUnsignedCompact(String str, Optional<String> optional, RawJwt rawJwt) {
        String jsonPayload = rawJwt.getJsonPayload();
        return createHeader(str, rawJwt.hasTypeHeader() ? Optional.of(rawJwt.getTypeHeader()) : Optional.empty(), optional) + "." + encodePayload(jsonPayload);
    }

    static String createSignedCompact(String str, byte[] bArr) {
        return str + "." + encodeSignature(bArr);
    }

    static void validateASCII(String str) throws JwtInvalidException {
        for (int i = 0; i < str.length(); i++) {
            if ((str.charAt(i) & 128) > 0) {
                throw new JwtInvalidException("Non ascii character");
            }
        }
    }
}
