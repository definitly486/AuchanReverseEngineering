package com.google.crypto.tink.prf;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.util.SecretBytes;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class HmacPrfKey extends PrfKey {
    private final SecretBytes keyBytes;
    private final HmacPrfParameters parameters;

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return null;
    }

    public static final class Builder {
        private SecretBytes keyBytes;
        private HmacPrfParameters parameters;

        private Builder() {
            this.parameters = null;
            this.keyBytes = null;
        }

        @CanIgnoreReturnValue
        public Builder setParameters(HmacPrfParameters hmacPrfParameters) {
            this.parameters = hmacPrfParameters;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setKeyBytes(SecretBytes secretBytes) {
            this.keyBytes = secretBytes;
            return this;
        }

        public HmacPrfKey build() throws GeneralSecurityException {
            HmacPrfParameters hmacPrfParameters = this.parameters;
            if (hmacPrfParameters == null || this.keyBytes == null) {
                throw new GeneralSecurityException("Cannot build without parameters and/or key material");
            }
            if (hmacPrfParameters.getKeySizeBytes() != this.keyBytes.size()) {
                throw new GeneralSecurityException("Key size mismatch");
            }
            return new HmacPrfKey(this.parameters, this.keyBytes);
        }
    }

    private HmacPrfKey(HmacPrfParameters hmacPrfParameters, SecretBytes secretBytes) {
        this.parameters = hmacPrfParameters;
        this.keyBytes = secretBytes;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBytes getKeyBytes() {
        return this.keyBytes;
    }

    @Override // com.google.crypto.tink.prf.PrfKey, com.google.crypto.tink.Key
    public HmacPrfParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof HmacPrfKey)) {
            return false;
        }
        HmacPrfKey hmacPrfKey = (HmacPrfKey) key;
        return hmacPrfKey.parameters.equals(this.parameters) && hmacPrfKey.keyBytes.equalsSecretBytes(this.keyBytes);
    }
}
