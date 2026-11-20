package com.google.crypto.tink;

import androidx.core.app.NotificationCompat;
import com.google.crypto.tink.internal.JsonParser;
import com.google.crypto.tink.proto.EncryptedKeyset;
import com.google.crypto.tink.proto.KeyData;
import com.google.crypto.tink.proto.KeyStatusType;
import com.google.crypto.tink.proto.Keyset;
import com.google.crypto.tink.proto.KeysetInfo;
import com.google.crypto.tink.proto.OutputPrefixType;
import com.google.crypto.tink.shaded.protobuf.ByteString;
import com.google.crypto.tink.subtle.Base64;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.InlineMe;
import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.Charset;
import java.nio.file.Path;

/* JADX INFO: loaded from: classes2.dex */
public final class JsonKeysetReader implements KeysetReader {
    private static final long MAX_KEY_ID = 4294967295L;
    private static final long MIN_KEY_ID = -2147483648L;
    private static final Charset UTF_8 = Charset.forName(com.bumptech.glide.load.Key.STRING_CHARSET_NAME);
    private final InputStream inputStream;
    private boolean urlSafeBase64 = false;

    private JsonKeysetReader(InputStream inputStream) {
        this.inputStream = inputStream;
    }

    public static JsonKeysetReader withInputStream(InputStream inputStream) {
        return new JsonKeysetReader(inputStream);
    }

    @InlineMe(imports = {"com.google.crypto.tink.JsonKeysetReader"}, replacement = "JsonKeysetReader.withString(input.toString())")
    @Deprecated
    public static JsonKeysetReader withJsonObject(Object obj) {
        return withString(obj.toString());
    }

    public static JsonKeysetReader withString(String str) {
        return new JsonKeysetReader(new ByteArrayInputStream(str.getBytes(UTF_8)));
    }

    @Deprecated
    public static JsonKeysetReader withBytes(byte[] bArr) {
        return new JsonKeysetReader(new ByteArrayInputStream(bArr));
    }

    @InlineMe(imports = {"com.google.crypto.tink.JsonKeysetReader", "java.io.FileInputStream"}, replacement = "JsonKeysetReader.withInputStream(new FileInputStream(file))")
    @Deprecated
    public static JsonKeysetReader withFile(File file) {
        return withInputStream(new FileInputStream(file));
    }

    @InlineMe(imports = {"com.google.crypto.tink.JsonKeysetReader", "java.io.File", "java.io.FileInputStream"}, replacement = "JsonKeysetReader.withInputStream(new FileInputStream(new File(path)))")
    @Deprecated
    public static JsonKeysetReader withPath(String str) {
        return withInputStream(new FileInputStream(new File(str)));
    }

    @InlineMe(imports = {"com.google.crypto.tink.JsonKeysetReader", "java.io.FileInputStream"}, replacement = "JsonKeysetReader.withInputStream(new FileInputStream(path.toFile()))")
    @Deprecated
    public static JsonKeysetReader withPath(Path path) {
        return withInputStream(new FileInputStream(path.toFile()));
    }

    @CanIgnoreReturnValue
    public JsonKeysetReader withUrlSafeBase64() {
        this.urlSafeBase64 = true;
        return this;
    }

    @Override // com.google.crypto.tink.KeysetReader
    public Keyset read() throws IOException {
        try {
            try {
                Keyset keysetKeysetFromJson = keysetFromJson(JsonParser.parse(new String(Util.readAll(this.inputStream), UTF_8)).getAsJsonObject());
                InputStream inputStream = this.inputStream;
                if (inputStream != null) {
                    inputStream.close();
                }
                return keysetKeysetFromJson;
            } catch (Throwable th) {
                InputStream inputStream2 = this.inputStream;
                if (inputStream2 != null) {
                    inputStream2.close();
                }
                throw th;
            }
        } catch (JsonParseException | IllegalStateException e) {
            throw new IOException(e);
        }
    }

    @Override // com.google.crypto.tink.KeysetReader
    public EncryptedKeyset readEncrypted() throws IOException {
        try {
            try {
                EncryptedKeyset encryptedKeysetEncryptedKeysetFromJson = encryptedKeysetFromJson(JsonParser.parse(new String(Util.readAll(this.inputStream), UTF_8)).getAsJsonObject());
                InputStream inputStream = this.inputStream;
                if (inputStream != null) {
                    inputStream.close();
                }
                return encryptedKeysetEncryptedKeysetFromJson;
            } catch (Throwable th) {
                InputStream inputStream2 = this.inputStream;
                if (inputStream2 != null) {
                    inputStream2.close();
                }
                throw th;
            }
        } catch (JsonParseException | IllegalStateException e) {
            throw new IOException(e);
        }
    }

    private static int getKeyId(JsonElement jsonElement) throws IOException {
        if (!jsonElement.isJsonPrimitive()) {
            throw new IOException("invalid key id: not a JSON primitive");
        }
        if (!jsonElement.getAsJsonPrimitive().isNumber()) {
            throw new IOException("invalid key id: not a JSON number");
        }
        try {
            long parsedNumberAsLongOrThrow = JsonParser.getParsedNumberAsLongOrThrow(jsonElement.getAsJsonPrimitive().getAsNumber());
            if (parsedNumberAsLongOrThrow > MAX_KEY_ID || parsedNumberAsLongOrThrow < MIN_KEY_ID) {
                throw new IOException("invalid key id");
            }
            return (int) parsedNumberAsLongOrThrow;
        } catch (NumberFormatException e) {
            throw new IOException(e);
        }
    }

    private Keyset keysetFromJson(JsonObject jsonObject) {
        if (!jsonObject.has("key")) {
            throw new JsonParseException("invalid keyset: no key");
        }
        JsonElement jsonElement = jsonObject.get("key");
        if (!jsonElement.isJsonArray()) {
            throw new JsonParseException("invalid keyset: key must be an array");
        }
        JsonArray asJsonArray = jsonElement.getAsJsonArray();
        if (asJsonArray.size() == 0) {
            throw new JsonParseException("invalid keyset: key is empty");
        }
        Keyset.Builder builderNewBuilder = Keyset.newBuilder();
        if (jsonObject.has("primaryKeyId")) {
            builderNewBuilder.setPrimaryKeyId(getKeyId(jsonObject.get("primaryKeyId")));
        }
        for (int i = 0; i < asJsonArray.size(); i++) {
            builderNewBuilder.addKey(keyFromJson(asJsonArray.get(i).getAsJsonObject()));
        }
        return builderNewBuilder.build();
    }

    private EncryptedKeyset encryptedKeysetFromJson(JsonObject jsonObject) {
        byte[] bArrDecode;
        validateEncryptedKeyset(jsonObject);
        if (this.urlSafeBase64) {
            bArrDecode = Base64.urlSafeDecode(jsonObject.get("encryptedKeyset").getAsString());
        } else {
            bArrDecode = Base64.decode(jsonObject.get("encryptedKeyset").getAsString());
        }
        if (jsonObject.has("keysetInfo")) {
            return EncryptedKeyset.newBuilder().setEncryptedKeyset(ByteString.copyFrom(bArrDecode)).setKeysetInfo(keysetInfoFromJson(jsonObject.getAsJsonObject("keysetInfo"))).build();
        }
        return EncryptedKeyset.newBuilder().setEncryptedKeyset(ByteString.copyFrom(bArrDecode)).build();
    }

    private Keyset.Key keyFromJson(JsonObject jsonObject) {
        if (!jsonObject.has("keyData") || !jsonObject.has(NotificationCompat.CATEGORY_STATUS) || !jsonObject.has("keyId") || !jsonObject.has("outputPrefixType")) {
            throw new JsonParseException("invalid key");
        }
        JsonElement jsonElement = jsonObject.get("keyData");
        if (!jsonElement.isJsonObject()) {
            throw new JsonParseException("invalid key: keyData must be an object");
        }
        return Keyset.Key.newBuilder().setStatus(getStatus(jsonObject.get(NotificationCompat.CATEGORY_STATUS).getAsString())).setKeyId(getKeyId(jsonObject.get("keyId"))).setOutputPrefixType(getOutputPrefixType(jsonObject.get("outputPrefixType").getAsString())).setKeyData(keyDataFromJson(jsonElement.getAsJsonObject())).build();
    }

    private static KeysetInfo keysetInfoFromJson(JsonObject jsonObject) {
        KeysetInfo.Builder builderNewBuilder = KeysetInfo.newBuilder();
        if (jsonObject.has("primaryKeyId")) {
            builderNewBuilder.setPrimaryKeyId(getKeyId(jsonObject.get("primaryKeyId")));
        }
        if (jsonObject.has("keyInfo")) {
            JsonArray asJsonArray = jsonObject.getAsJsonArray("keyInfo");
            for (int i = 0; i < asJsonArray.size(); i++) {
                builderNewBuilder.addKeyInfo(keyInfoFromJson(asJsonArray.get(i).getAsJsonObject()));
            }
        }
        return builderNewBuilder.build();
    }

    private static KeysetInfo.KeyInfo keyInfoFromJson(JsonObject jsonObject) {
        return KeysetInfo.KeyInfo.newBuilder().setStatus(getStatus(jsonObject.get(NotificationCompat.CATEGORY_STATUS).getAsString())).setKeyId(getKeyId(jsonObject.get("keyId"))).setOutputPrefixType(getOutputPrefixType(jsonObject.get("outputPrefixType").getAsString())).setTypeUrl(jsonObject.get("typeUrl").getAsString()).build();
    }

    private KeyData keyDataFromJson(JsonObject jsonObject) {
        byte[] bArrDecode;
        if (!jsonObject.has("typeUrl") || !jsonObject.has("value") || !jsonObject.has("keyMaterialType")) {
            throw new JsonParseException("invalid keyData");
        }
        if (this.urlSafeBase64) {
            bArrDecode = Base64.urlSafeDecode(jsonObject.get("value").getAsString());
        } else {
            bArrDecode = Base64.decode(jsonObject.get("value").getAsString());
        }
        return KeyData.newBuilder().setTypeUrl(jsonObject.get("typeUrl").getAsString()).setValue(ByteString.copyFrom(bArrDecode)).setKeyMaterialType(getKeyMaterialType(jsonObject.get("keyMaterialType").getAsString())).build();
    }

    private static KeyStatusType getStatus(String str) {
        str.getClass();
        switch (str) {
            case "ENABLED":
                return KeyStatusType.ENABLED;
            case "DESTROYED":
                return KeyStatusType.DESTROYED;
            case "DISABLED":
                return KeyStatusType.DISABLED;
            default:
                throw new JsonParseException("unknown status: " + str);
        }
    }

    private static OutputPrefixType getOutputPrefixType(String str) {
        str.getClass();
        switch (str) {
            case "LEGACY":
                return OutputPrefixType.LEGACY;
            case "RAW":
                return OutputPrefixType.RAW;
            case "TINK":
                return OutputPrefixType.TINK;
            case "CRUNCHY":
                return OutputPrefixType.CRUNCHY;
            default:
                throw new JsonParseException("unknown output prefix type: " + str);
        }
    }

    private static KeyData.KeyMaterialType getKeyMaterialType(String str) {
        str.getClass();
        switch (str) {
            case "REMOTE":
                return KeyData.KeyMaterialType.REMOTE;
            case "SYMMETRIC":
                return KeyData.KeyMaterialType.SYMMETRIC;
            case "ASYMMETRIC_PRIVATE":
                return KeyData.KeyMaterialType.ASYMMETRIC_PRIVATE;
            case "ASYMMETRIC_PUBLIC":
                return KeyData.KeyMaterialType.ASYMMETRIC_PUBLIC;
            default:
                throw new JsonParseException("unknown key material type: " + str);
        }
    }

    private static void validateEncryptedKeyset(JsonObject jsonObject) {
        if (!jsonObject.has("encryptedKeyset")) {
            throw new JsonParseException("invalid encrypted keyset");
        }
    }
}
