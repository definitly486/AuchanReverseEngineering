package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.subtle.Base64;
import com.google.crypto.tink.util.SecretBytes;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.RestrictedApi;
import java.nio.ByteBuffer;
import java.security.GeneralSecurityException;
import java.util.Optional;

/* JADX INFO: loaded from: classes2.dex */
public class JwtHmacKey extends JwtMacKey {
    private final Optional<Integer> idRequirement;
    private final SecretBytes key;
    private final Optional<String> kid;
    private final JwtHmacParameters parameters;

    public static class Builder {
        private Optional<String> customKid;
        private Optional<Integer> idRequirement;
        private Optional<SecretBytes> keyBytes;
        private Optional<JwtHmacParameters> parameters;

        private Builder() {
            this.parameters = Optional.empty();
            this.keyBytes = Optional.empty();
            this.idRequirement = Optional.empty();
            this.customKid = Optional.empty();
        }

        @CanIgnoreReturnValue
        public Builder setParameters(JwtHmacParameters jwtHmacParameters) {
            this.parameters = Optional.of(jwtHmacParameters);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setKeyBytes(SecretBytes secretBytes) {
            this.keyBytes = Optional.of(secretBytes);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setIdRequirement(int i) {
            this.idRequirement = Optional.of(Integer.valueOf(i));
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setCustomKid(String str) {
            this.customKid = Optional.of(str);
            return this;
        }

        private Optional<String> computeKid() throws GeneralSecurityException {
            if (this.parameters.get().getKidStrategy().equals(JwtHmacParameters.KidStrategy.BASE64_ENCODED_KEY_ID)) {
                byte[] bArrArray = ByteBuffer.allocate(4).putInt(this.idRequirement.get().intValue()).array();
                if (this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid must not be set for KidStrategy BASE64_ENCODED_KEY_ID");
                }
                return Optional.of(Base64.urlSafeEncode(bArrArray));
            }
            if (this.parameters.get().getKidStrategy().equals(JwtHmacParameters.KidStrategy.CUSTOM)) {
                if (!this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid needs to be set for KidStrategy CUSTOM");
                }
                return this.customKid;
            }
            if (this.parameters.get().getKidStrategy().equals(JwtHmacParameters.KidStrategy.IGNORED)) {
                if (this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid must not be set for KidStrategy IGNORED");
                }
                return Optional.empty();
            }
            throw new IllegalStateException("Unknown kid strategy");
        }

        public JwtHmacKey build() throws GeneralSecurityException {
            if (!this.parameters.isPresent()) {
                throw new GeneralSecurityException("Parameters are required");
            }
            if (!this.keyBytes.isPresent()) {
                throw new GeneralSecurityException("KeyBytes are required");
            }
            if (this.parameters.get().getKeySizeBytes() != this.keyBytes.get().size()) {
                throw new GeneralSecurityException("Key size mismatch");
            }
            if (this.parameters.get().hasIdRequirement() && !this.idRequirement.isPresent()) {
                throw new GeneralSecurityException("Cannot create key without ID requirement with parameters with ID requirement");
            }
            if (!this.parameters.get().hasIdRequirement() && this.idRequirement.isPresent()) {
                throw new GeneralSecurityException("Cannot create key with ID requirement with parameters without ID requirement");
            }
            return new JwtHmacKey(this.parameters.get(), this.keyBytes.get(), this.idRequirement, computeKid());
        }
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    private JwtHmacKey(JwtHmacParameters jwtHmacParameters, SecretBytes secretBytes, Optional<Integer> optional, Optional<String> optional2) {
        this.parameters = jwtHmacParameters;
        this.key = secretBytes;
        this.idRequirement = optional;
        this.kid = optional2;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBytes getKeyBytes() {
        return this.key;
    }

    @Override // com.google.crypto.tink.jwt.JwtMacKey
    public Optional<String> getKid() {
        return this.kid;
    }

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return this.idRequirement.orElse(null);
    }

    @Override // com.google.crypto.tink.jwt.JwtMacKey, com.google.crypto.tink.Key
    public JwtHmacParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof JwtHmacKey)) {
            return false;
        }
        JwtHmacKey jwtHmacKey = (JwtHmacKey) key;
        return jwtHmacKey.parameters.equals(this.parameters) && jwtHmacKey.key.equalsSecretBytes(this.key) && jwtHmacKey.kid.equals(this.kid) && jwtHmacKey.idRequirement.equals(this.idRequirement);
    }
}
