package com.google.crypto.tink.prf;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.util.SecretBytes;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class AesCmacPrfKey extends PrfKey {
    private final SecretBytes keyBytes;
    private final AesCmacPrfParameters parameters;

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return null;
    }

    private AesCmacPrfKey(AesCmacPrfParameters aesCmacPrfParameters, SecretBytes secretBytes) {
        this.parameters = aesCmacPrfParameters;
        this.keyBytes = secretBytes;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static AesCmacPrfKey create(AesCmacPrfParameters aesCmacPrfParameters, SecretBytes secretBytes) throws GeneralSecurityException {
        if (aesCmacPrfParameters.getKeySizeBytes() != secretBytes.size()) {
            throw new GeneralSecurityException("Key size mismatch");
        }
        return new AesCmacPrfKey(aesCmacPrfParameters, secretBytes);
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBytes getKeyBytes() {
        return this.keyBytes;
    }

    @Override // com.google.crypto.tink.prf.PrfKey, com.google.crypto.tink.Key
    public AesCmacPrfParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof AesCmacPrfKey)) {
            return false;
        }
        AesCmacPrfKey aesCmacPrfKey = (AesCmacPrfKey) key;
        return aesCmacPrfKey.parameters.equals(this.parameters) && aesCmacPrfKey.keyBytes.equalsSecretBytes(this.keyBytes);
    }
}
