package com.google.crypto.tink.streamingaead;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.util.SecretBytes;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public final class AesCtrHmacStreamingKey extends StreamingAeadKey {
    private final SecretBytes initialKeymaterial;
    private final AesCtrHmacStreamingParameters parameters;

    private AesCtrHmacStreamingKey(AesCtrHmacStreamingParameters aesCtrHmacStreamingParameters, SecretBytes secretBytes) {
        this.parameters = aesCtrHmacStreamingParameters;
        this.initialKeymaterial = secretBytes;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static AesCtrHmacStreamingKey create(AesCtrHmacStreamingParameters aesCtrHmacStreamingParameters, SecretBytes secretBytes) throws GeneralSecurityException {
        if (aesCtrHmacStreamingParameters.getKeySizeBytes() != secretBytes.size()) {
            throw new GeneralSecurityException("Key size mismatch");
        }
        return new AesCtrHmacStreamingKey(aesCtrHmacStreamingParameters, secretBytes);
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBytes getInitialKeyMaterial() {
        return this.initialKeymaterial;
    }

    @Override // com.google.crypto.tink.streamingaead.StreamingAeadKey, com.google.crypto.tink.Key
    public AesCtrHmacStreamingParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof AesCtrHmacStreamingKey)) {
            return false;
        }
        AesCtrHmacStreamingKey aesCtrHmacStreamingKey = (AesCtrHmacStreamingKey) key;
        return aesCtrHmacStreamingKey.parameters.equals(this.parameters) && aesCtrHmacStreamingKey.initialKeymaterial.equalsSecretBytes(this.initialKeymaterial);
    }
}
