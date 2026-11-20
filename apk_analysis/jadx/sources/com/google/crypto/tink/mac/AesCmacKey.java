package com.google.crypto.tink.mac;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.internal.OutputPrefixUtil;
import com.google.crypto.tink.util.Bytes;
import com.google.crypto.tink.util.SecretBytes;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;
import java.util.Objects;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class AesCmacKey extends MacKey {
    private final SecretBytes aesKeyBytes;
    private final Integer idRequirement;
    private final Bytes outputPrefix;
    private final AesCmacParameters parameters;

    public static class Builder {
        private SecretBytes aesKeyBytes;
        private Integer idRequirement;
        private AesCmacParameters parameters;

        private Builder() {
            this.parameters = null;
            this.aesKeyBytes = null;
            this.idRequirement = null;
        }

        @CanIgnoreReturnValue
        public Builder setParameters(AesCmacParameters aesCmacParameters) {
            this.parameters = aesCmacParameters;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setAesKeyBytes(SecretBytes secretBytes) {
            this.aesKeyBytes = secretBytes;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setIdRequirement(Integer num) {
            this.idRequirement = num;
            return this;
        }

        private Bytes getOutputPrefix() {
            if (this.parameters.getVariant() == AesCmacParameters.Variant.NO_PREFIX) {
                return OutputPrefixUtil.EMPTY_PREFIX;
            }
            if (this.parameters.getVariant() == AesCmacParameters.Variant.LEGACY || this.parameters.getVariant() == AesCmacParameters.Variant.CRUNCHY) {
                return OutputPrefixUtil.getLegacyOutputPrefix(this.idRequirement.intValue());
            }
            if (this.parameters.getVariant() == AesCmacParameters.Variant.TINK) {
                return OutputPrefixUtil.getTinkOutputPrefix(this.idRequirement.intValue());
            }
            throw new IllegalStateException("Unknown AesCmacParametersParameters.Variant: " + this.parameters.getVariant());
        }

        public AesCmacKey build() throws GeneralSecurityException {
            AesCmacParameters aesCmacParameters = this.parameters;
            if (aesCmacParameters == null || this.aesKeyBytes == null) {
                throw new GeneralSecurityException("Cannot build without parameters and/or key material");
            }
            if (aesCmacParameters.getKeySizeBytes() != this.aesKeyBytes.size()) {
                throw new GeneralSecurityException("Key size mismatch");
            }
            if (this.parameters.hasIdRequirement() && this.idRequirement == null) {
                throw new GeneralSecurityException("Cannot create key without ID requirement with parameters with ID requirement");
            }
            if (!this.parameters.hasIdRequirement() && this.idRequirement != null) {
                throw new GeneralSecurityException("Cannot create key with ID requirement with parameters without ID requirement");
            }
            return new AesCmacKey(this.parameters, this.aesKeyBytes, getOutputPrefix(), this.idRequirement);
        }
    }

    private AesCmacKey(AesCmacParameters aesCmacParameters, SecretBytes secretBytes, Bytes bytes, Integer num) {
        this.parameters = aesCmacParameters;
        this.aesKeyBytes = secretBytes;
        this.outputPrefix = bytes;
        this.idRequirement = num;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBytes getAesKey() {
        return this.aesKeyBytes;
    }

    @Override // com.google.crypto.tink.mac.MacKey
    public Bytes getOutputPrefix() {
        return this.outputPrefix;
    }

    @Override // com.google.crypto.tink.mac.MacKey, com.google.crypto.tink.Key
    public AesCmacParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return this.idRequirement;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof AesCmacKey)) {
            return false;
        }
        AesCmacKey aesCmacKey = (AesCmacKey) key;
        return aesCmacKey.parameters.equals(this.parameters) && aesCmacKey.aesKeyBytes.equalsSecretBytes(this.aesKeyBytes) && Objects.equals(aesCmacKey.idRequirement, this.idRequirement);
    }
}
