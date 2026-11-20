package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.KeyStatus;
import com.google.crypto.tink.KeysetHandle;
import com.google.crypto.tink.internal.BigIntegerEncoding;
import com.google.crypto.tink.internal.JsonParser;
import com.google.crypto.tink.subtle.Base64;
import com.google.crypto.tink.tinkkey.KeyAccess;
import com.google.errorprone.annotations.InlineMe;
import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import java.io.IOException;
import java.math.BigInteger;
import java.security.GeneralSecurityException;
import java.security.spec.ECPoint;
import java.util.Iterator;
import java.util.Optional;

/* JADX INFO: loaded from: classes2.dex */
public final class JwkSetConverter {
    public static String fromPublicKeysetHandle(KeysetHandle keysetHandle) throws GeneralSecurityException {
        KeysetHandle keysetHandleBuild = KeysetHandle.newBuilder(keysetHandle).build();
        JsonArray jsonArray = new JsonArray();
        for (int i = 0; i < keysetHandleBuild.size(); i++) {
            KeysetHandle.Entry at = keysetHandleBuild.getAt(i);
            if (at.getStatus() == KeyStatus.ENABLED) {
                Key key = at.getKey();
                if (key instanceof JwtEcdsaPublicKey) {
                    jsonArray.add(convertJwtEcdsaKey((JwtEcdsaPublicKey) key));
                } else if (key instanceof JwtRsaSsaPkcs1PublicKey) {
                    jsonArray.add(convertJwtRsaSsaPkcs1Key((JwtRsaSsaPkcs1PublicKey) key));
                } else if (key instanceof JwtRsaSsaPssPublicKey) {
                    jsonArray.add(convertJwtRsaSsaPssKey((JwtRsaSsaPssPublicKey) key));
                } else {
                    throw new GeneralSecurityException("unsupported key with parameters " + key.getParameters());
                }
            }
        }
        JsonObject jsonObject = new JsonObject();
        jsonObject.add("keys", jsonArray);
        return jsonObject.toString();
    }

    public static KeysetHandle toPublicKeysetHandle(String str) throws GeneralSecurityException {
        try {
            JsonObject asJsonObject = JsonParser.parse(str).getAsJsonObject();
            KeysetHandle.Builder builderNewBuilder = KeysetHandle.newBuilder();
            Iterator<JsonElement> it = asJsonObject.get("keys").getAsJsonArray().iterator();
            while (true) {
                if (it.hasNext()) {
                    JsonObject asJsonObject2 = it.next().getAsJsonObject();
                    String strSubstring = getStringItem(asJsonObject2, "alg").substring(0, 2);
                    strSubstring.getClass();
                    switch (strSubstring) {
                        case "ES":
                            builderNewBuilder.addEntry(KeysetHandle.importKey(convertToEcdsaKey(asJsonObject2)).withRandomId());
                            break;
                        case "PS":
                            builderNewBuilder.addEntry(KeysetHandle.importKey(convertToRsaSsaPssKey(asJsonObject2)).withRandomId());
                            break;
                        case "RS":
                            builderNewBuilder.addEntry(KeysetHandle.importKey(convertToRsaSsaPkcs1Key(asJsonObject2)).withRandomId());
                            break;
                        default:
                            throw new GeneralSecurityException("unexpected alg value: " + getStringItem(asJsonObject2, "alg"));
                    }
                } else {
                    if (builderNewBuilder.size() <= 0) {
                        throw new GeneralSecurityException("empty keyset");
                    }
                    builderNewBuilder.getAt(0).makePrimary();
                    return builderNewBuilder.build();
                }
            }
        } catch (IOException | IllegalStateException e) {
            throw new GeneralSecurityException("JWK set is invalid JSON", e);
        }
    }

    @AccessesPartialKey
    private static JsonObject convertJwtEcdsaKey(JwtEcdsaPublicKey jwtEcdsaPublicKey) throws GeneralSecurityException {
        String str;
        String str2;
        int i;
        JwtEcdsaParameters.Algorithm algorithm = jwtEcdsaPublicKey.getParameters().getAlgorithm();
        if (algorithm.equals(JwtEcdsaParameters.Algorithm.ES256)) {
            str = "ES256";
            str2 = "P-256";
            i = 32;
        } else if (algorithm.equals(JwtEcdsaParameters.Algorithm.ES384)) {
            str = "ES384";
            str2 = "P-384";
            i = 48;
        } else if (algorithm.equals(JwtEcdsaParameters.Algorithm.ES512)) {
            str = "ES512";
            str2 = "P-521";
            i = 66;
        } else {
            throw new GeneralSecurityException("unknown algorithm");
        }
        JsonObject jsonObject = new JsonObject();
        jsonObject.addProperty("kty", "EC");
        jsonObject.addProperty("crv", str2);
        BigInteger affineX = jwtEcdsaPublicKey.getPublicPoint().getAffineX();
        BigInteger affineY = jwtEcdsaPublicKey.getPublicPoint().getAffineY();
        jsonObject.addProperty("x", Base64.urlSafeEncode(BigIntegerEncoding.toBigEndianBytesOfFixedLength(affineX, i)));
        jsonObject.addProperty("y", Base64.urlSafeEncode(BigIntegerEncoding.toBigEndianBytesOfFixedLength(affineY, i)));
        jsonObject.addProperty("use", "sig");
        jsonObject.addProperty("alg", str);
        JsonArray jsonArray = new JsonArray();
        jsonArray.add("verify");
        jsonObject.add("key_ops", jsonArray);
        Optional<String> kid = jwtEcdsaPublicKey.getKid();
        if (kid.isPresent()) {
            jsonObject.addProperty("kid", kid.get());
        }
        return jsonObject;
    }

    private static byte[] base64urlUInt(BigInteger bigInteger) {
        if (bigInteger.equals(BigInteger.ZERO)) {
            return new byte[]{0};
        }
        return BigIntegerEncoding.toUnsignedBigEndianBytes(bigInteger);
    }

    @AccessesPartialKey
    private static JsonObject convertJwtRsaSsaPkcs1Key(JwtRsaSsaPkcs1PublicKey jwtRsaSsaPkcs1PublicKey) {
        String standardName = jwtRsaSsaPkcs1PublicKey.getParameters().getAlgorithm().getStandardName();
        JsonObject jsonObject = new JsonObject();
        jsonObject.addProperty("kty", "RSA");
        jsonObject.addProperty("n", Base64.urlSafeEncode(base64urlUInt(jwtRsaSsaPkcs1PublicKey.getModulus())));
        jsonObject.addProperty("e", Base64.urlSafeEncode(base64urlUInt(jwtRsaSsaPkcs1PublicKey.getParameters().getPublicExponent())));
        jsonObject.addProperty("use", "sig");
        jsonObject.addProperty("alg", standardName);
        JsonArray jsonArray = new JsonArray();
        jsonArray.add("verify");
        jsonObject.add("key_ops", jsonArray);
        Optional<String> kid = jwtRsaSsaPkcs1PublicKey.getKid();
        if (kid.isPresent()) {
            jsonObject.addProperty("kid", kid.get());
        }
        return jsonObject;
    }

    @AccessesPartialKey
    private static JsonObject convertJwtRsaSsaPssKey(JwtRsaSsaPssPublicKey jwtRsaSsaPssPublicKey) {
        String standardName = jwtRsaSsaPssPublicKey.getParameters().getAlgorithm().getStandardName();
        JsonObject jsonObject = new JsonObject();
        jsonObject.addProperty("kty", "RSA");
        jsonObject.addProperty("n", Base64.urlSafeEncode(base64urlUInt(jwtRsaSsaPssPublicKey.getModulus())));
        jsonObject.addProperty("e", Base64.urlSafeEncode(base64urlUInt(jwtRsaSsaPssPublicKey.getParameters().getPublicExponent())));
        jsonObject.addProperty("use", "sig");
        jsonObject.addProperty("alg", standardName);
        JsonArray jsonArray = new JsonArray();
        jsonArray.add("verify");
        jsonObject.add("key_ops", jsonArray);
        Optional<String> kid = jwtRsaSsaPssPublicKey.getKid();
        if (kid.isPresent()) {
            jsonObject.addProperty("kid", kid.get());
        }
        return jsonObject;
    }

    private static String getStringItem(JsonObject jsonObject, String str) throws GeneralSecurityException {
        if (!jsonObject.has(str)) {
            throw new GeneralSecurityException(str + " not found");
        }
        if (!jsonObject.get(str).isJsonPrimitive() || !jsonObject.get(str).getAsJsonPrimitive().isString()) {
            throw new GeneralSecurityException(str + " is not a string");
        }
        return jsonObject.get(str).getAsString();
    }

    private static void expectStringItem(JsonObject jsonObject, String str, String str2) throws GeneralSecurityException {
        String stringItem = getStringItem(jsonObject, str);
        if (stringItem.equals(str2)) {
            return;
        }
        throw new GeneralSecurityException("unexpected " + str + " value: " + stringItem);
    }

    private static void validateUseIsSig(JsonObject jsonObject) throws GeneralSecurityException {
        if (jsonObject.has("use")) {
            expectStringItem(jsonObject, "use", "sig");
        }
    }

    private static void validateKeyOpsIsVerify(JsonObject jsonObject) throws GeneralSecurityException {
        if (jsonObject.has("key_ops")) {
            if (!jsonObject.get("key_ops").isJsonArray()) {
                throw new GeneralSecurityException("key_ops is not an array");
            }
            JsonArray asJsonArray = jsonObject.get("key_ops").getAsJsonArray();
            if (asJsonArray.size() != 1) {
                throw new GeneralSecurityException("key_ops must contain exactly one element");
            }
            if (!asJsonArray.get(0).isJsonPrimitive() || !asJsonArray.get(0).getAsJsonPrimitive().isString()) {
                throw new GeneralSecurityException("key_ops is not a string");
            }
            if (asJsonArray.get(0).getAsString().equals("verify")) {
                return;
            }
            throw new GeneralSecurityException("unexpected keyOps value: " + asJsonArray.get(0).getAsString());
        }
    }

    @AccessesPartialKey
    private static JwtRsaSsaPkcs1PublicKey convertToRsaSsaPkcs1Key(JsonObject jsonObject) throws GeneralSecurityException {
        JwtRsaSsaPkcs1Parameters.Algorithm algorithm;
        String stringItem = getStringItem(jsonObject, "alg");
        stringItem.getClass();
        switch (stringItem) {
            case "RS256":
                algorithm = JwtRsaSsaPkcs1Parameters.Algorithm.RS256;
                break;
            case "RS384":
                algorithm = JwtRsaSsaPkcs1Parameters.Algorithm.RS384;
                break;
            case "RS512":
                algorithm = JwtRsaSsaPkcs1Parameters.Algorithm.RS512;
                break;
            default:
                throw new GeneralSecurityException("Unknown Rsa Algorithm: " + getStringItem(jsonObject, "alg"));
        }
        if (jsonObject.has("p") || jsonObject.has("q") || jsonObject.has("dp") || jsonObject.has("dq") || jsonObject.has("d") || jsonObject.has("qi")) {
            throw new UnsupportedOperationException("importing RSA private keys is not implemented");
        }
        expectStringItem(jsonObject, "kty", "RSA");
        validateUseIsSig(jsonObject);
        validateKeyOpsIsVerify(jsonObject);
        BigInteger bigInteger = new BigInteger(1, Base64.urlSafeDecode(getStringItem(jsonObject, "e")));
        BigInteger bigInteger2 = new BigInteger(1, Base64.urlSafeDecode(getStringItem(jsonObject, "n")));
        if (jsonObject.has("kid")) {
            return JwtRsaSsaPkcs1PublicKey.builder().setParameters(JwtRsaSsaPkcs1Parameters.builder().setModulusSizeBits(bigInteger2.bitLength()).setPublicExponent(bigInteger).setAlgorithm(algorithm).setKidStrategy(JwtRsaSsaPkcs1Parameters.KidStrategy.CUSTOM).build()).setModulus(bigInteger2).setCustomKid(getStringItem(jsonObject, "kid")).build();
        }
        return JwtRsaSsaPkcs1PublicKey.builder().setParameters(JwtRsaSsaPkcs1Parameters.builder().setModulusSizeBits(bigInteger2.bitLength()).setPublicExponent(bigInteger).setAlgorithm(algorithm).setKidStrategy(JwtRsaSsaPkcs1Parameters.KidStrategy.IGNORED).build()).setModulus(bigInteger2).build();
    }

    @AccessesPartialKey
    private static JwtRsaSsaPssPublicKey convertToRsaSsaPssKey(JsonObject jsonObject) throws GeneralSecurityException {
        JwtRsaSsaPssParameters.Algorithm algorithm;
        String stringItem = getStringItem(jsonObject, "alg");
        stringItem.getClass();
        switch (stringItem) {
            case "PS256":
                algorithm = JwtRsaSsaPssParameters.Algorithm.PS256;
                break;
            case "PS384":
                algorithm = JwtRsaSsaPssParameters.Algorithm.PS384;
                break;
            case "PS512":
                algorithm = JwtRsaSsaPssParameters.Algorithm.PS512;
                break;
            default:
                throw new GeneralSecurityException("Unknown Rsa Algorithm: " + getStringItem(jsonObject, "alg"));
        }
        if (jsonObject.has("p") || jsonObject.has("q") || jsonObject.has("dq") || jsonObject.has("dq") || jsonObject.has("d") || jsonObject.has("qi")) {
            throw new UnsupportedOperationException("importing RSA private keys is not implemented");
        }
        expectStringItem(jsonObject, "kty", "RSA");
        validateUseIsSig(jsonObject);
        validateKeyOpsIsVerify(jsonObject);
        BigInteger bigInteger = new BigInteger(1, Base64.urlSafeDecode(getStringItem(jsonObject, "e")));
        BigInteger bigInteger2 = new BigInteger(1, Base64.urlSafeDecode(getStringItem(jsonObject, "n")));
        if (jsonObject.has("kid")) {
            return JwtRsaSsaPssPublicKey.builder().setParameters(JwtRsaSsaPssParameters.builder().setModulusSizeBits(bigInteger2.bitLength()).setPublicExponent(bigInteger).setAlgorithm(algorithm).setKidStrategy(JwtRsaSsaPssParameters.KidStrategy.CUSTOM).build()).setModulus(bigInteger2).setCustomKid(getStringItem(jsonObject, "kid")).build();
        }
        return JwtRsaSsaPssPublicKey.builder().setParameters(JwtRsaSsaPssParameters.builder().setModulusSizeBits(bigInteger2.bitLength()).setPublicExponent(bigInteger).setAlgorithm(algorithm).setKidStrategy(JwtRsaSsaPssParameters.KidStrategy.IGNORED).build()).setModulus(bigInteger2).build();
    }

    @AccessesPartialKey
    private static JwtEcdsaPublicKey convertToEcdsaKey(JsonObject jsonObject) throws GeneralSecurityException {
        JwtEcdsaParameters.Algorithm algorithm;
        String stringItem = getStringItem(jsonObject, "alg");
        stringItem.getClass();
        switch (stringItem) {
            case "ES256":
                expectStringItem(jsonObject, "crv", "P-256");
                algorithm = JwtEcdsaParameters.Algorithm.ES256;
                break;
            case "ES384":
                expectStringItem(jsonObject, "crv", "P-384");
                algorithm = JwtEcdsaParameters.Algorithm.ES384;
                break;
            case "ES512":
                expectStringItem(jsonObject, "crv", "P-521");
                algorithm = JwtEcdsaParameters.Algorithm.ES512;
                break;
            default:
                throw new GeneralSecurityException("Unknown Ecdsa Algorithm: " + getStringItem(jsonObject, "alg"));
        }
        if (jsonObject.has("d")) {
            throw new UnsupportedOperationException("importing ECDSA private keys is not implemented");
        }
        expectStringItem(jsonObject, "kty", "EC");
        validateUseIsSig(jsonObject);
        validateKeyOpsIsVerify(jsonObject);
        ECPoint eCPoint = new ECPoint(new BigInteger(1, Base64.urlSafeDecode(getStringItem(jsonObject, "x"))), new BigInteger(1, Base64.urlSafeDecode(getStringItem(jsonObject, "y"))));
        if (jsonObject.has("kid")) {
            return JwtEcdsaPublicKey.builder().setParameters(JwtEcdsaParameters.builder().setKidStrategy(JwtEcdsaParameters.KidStrategy.CUSTOM).setAlgorithm(algorithm).build()).setPublicPoint(eCPoint).setCustomKid(getStringItem(jsonObject, "kid")).build();
        }
        return JwtEcdsaPublicKey.builder().setParameters(JwtEcdsaParameters.builder().setKidStrategy(JwtEcdsaParameters.KidStrategy.IGNORED).setAlgorithm(algorithm).build()).setPublicPoint(eCPoint).build();
    }

    @InlineMe(imports = {"com.google.crypto.tink.jwt.JwkSetConverter"}, replacement = "JwkSetConverter.fromPublicKeysetHandle(handle)")
    @Deprecated
    public static String fromKeysetHandle(KeysetHandle keysetHandle, KeyAccess keyAccess) {
        return fromPublicKeysetHandle(keysetHandle);
    }

    @InlineMe(imports = {"com.google.crypto.tink.jwt.JwkSetConverter"}, replacement = "JwkSetConverter.toPublicKeysetHandle(jwkSet)")
    @Deprecated
    public static KeysetHandle toKeysetHandle(String str, KeyAccess keyAccess) {
        return toPublicKeysetHandle(str);
    }

    private JwkSetConverter() {
    }
}
