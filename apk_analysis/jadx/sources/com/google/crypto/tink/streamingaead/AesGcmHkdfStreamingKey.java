package com.google.crypto.tink.streamingaead;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.util.SecretBytes;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public final class AesGcmHkdfStreamingKey extends StreamingAeadKey {
    private final SecretBytes initialKeymaterial;
    private final AesGcmHkdfStreamingParameters parameters;

    private AesGcmHkdfStreamingKey(AesGcmHkdfStreamingParameters aesGcmHkdfStreamingParameters, SecretBytes secretBytes) {
        this.parameters = aesGcmHkdfStreamingParameters;
        this.initialKeymaterial = secretBytes;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static AesGcmHkdfStreamingKey create(AesGcmHkdfStreamingParameters aesGcmHkdfStreamingParameters, SecretBytes secretBytes) throws GeneralSecurityException {
        if (aesGcmHkdfStreamingParameters.getKeySizeBytes() != secretBytes.size()) {
            throw new GeneralSecurityException("Key size mismatch");
        }
        return new AesGcmHkdfStreamingKey(aesGcmHkdfStreamingParameters, secretBytes);
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBytes getInitialKeyMaterial() {
        return this.initialKeymaterial;
    }

    @Override // com.google.crypto.tink.streamingaead.StreamingAeadKey, com.google.crypto.tink.Key
    public AesGcmHkdfStreamingParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof AesGcmHkdfStreamingKey)) {
            return false;
        }
        AesGcmHkdfStreamingKey aesGcmHkdfStreamingKey = (AesGcmHkdfStreamingKey) key;
        return aesGcmHkdfStreamingKey.parameters.equals(this.parameters) && aesGcmHkdfStreamingKey.initialKeymaterial.equalsSecretBytes(this.initialKeymaterial);
    }
}
