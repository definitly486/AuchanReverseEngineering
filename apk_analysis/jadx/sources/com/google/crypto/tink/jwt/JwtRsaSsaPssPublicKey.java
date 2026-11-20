package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.subtle.Base64;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.RestrictedApi;
import java.math.BigInteger;
import java.nio.ByteBuffer;
import java.security.GeneralSecurityException;
import java.util.Optional;

/* JADX INFO: loaded from: classes2.dex */
public final class JwtRsaSsaPssPublicKey extends JwtSignaturePublicKey {
    private final Optional<Integer> idRequirement;
    private final Optional<String> kid;
    private final BigInteger modulus;
    private final JwtRsaSsaPssParameters parameters;

    public static class Builder {
        private Optional<String> customKid;
        private Optional<Integer> idRequirement;
        private Optional<BigInteger> modulus;
        private Optional<JwtRsaSsaPssParameters> parameters;

        private Builder() {
            this.parameters = Optional.empty();
            this.modulus = Optional.empty();
            this.idRequirement = Optional.empty();
            this.customKid = Optional.empty();
        }

        @CanIgnoreReturnValue
        public Builder setParameters(JwtRsaSsaPssParameters jwtRsaSsaPssParameters) {
            this.parameters = Optional.of(jwtRsaSsaPssParameters);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setModulus(BigInteger bigInteger) {
            this.modulus = Optional.of(bigInteger);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setIdRequirement(Integer num) {
            this.idRequirement = Optional.of(num);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setCustomKid(String str) {
            this.customKid = Optional.of(str);
            return this;
        }

        private Optional<String> computeKid() throws GeneralSecurityException {
            if (this.parameters.get().getKidStrategy().equals(JwtRsaSsaPssParameters.KidStrategy.BASE64_ENCODED_KEY_ID)) {
                if (this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid must not be set for KidStrategy BASE64_ENCODED_KEY_ID");
                }
                return Optional.of(Base64.urlSafeEncode(ByteBuffer.allocate(4).putInt(this.idRequirement.get().intValue()).array()));
            }
            if (this.parameters.get().getKidStrategy().equals(JwtRsaSsaPssParameters.KidStrategy.CUSTOM)) {
                if (!this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid needs to be set for KidStrategy CUSTOM");
                }
                return this.customKid;
            }
            if (this.parameters.get().getKidStrategy().equals(JwtRsaSsaPssParameters.KidStrategy.IGNORED)) {
                if (this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid must not be set for KidStrategy IGNORED");
                }
                return Optional.empty();
            }
            throw new IllegalStateException("Unknown kid strategy");
        }

        public JwtRsaSsaPssPublicKey build() throws GeneralSecurityException {
            if (!this.parameters.isPresent()) {
                throw new GeneralSecurityException("Cannot build without parameters");
            }
            if (!this.modulus.isPresent()) {
                throw new GeneralSecurityException("Cannot build without modulus");
            }
            int iBitLength = this.modulus.get().bitLength();
            int modulusSizeBits = this.parameters.get().getModulusSizeBits();
            if (iBitLength != modulusSizeBits) {
                throw new GeneralSecurityException("Got modulus size " + iBitLength + ", but parameters requires modulus size " + modulusSizeBits);
            }
            if (this.parameters.get().hasIdRequirement() && !this.idRequirement.isPresent()) {
                throw new GeneralSecurityException("Cannot create key without ID requirement with parameters with ID requirement");
            }
            if (!this.parameters.get().hasIdRequirement() && this.idRequirement.isPresent()) {
                throw new GeneralSecurityException("Cannot create key with ID requirement with parameters without ID requirement");
            }
            return new JwtRsaSsaPssPublicKey(this.parameters.get(), this.modulus.get(), this.idRequirement, computeKid());
        }
    }

    private JwtRsaSsaPssPublicKey(JwtRsaSsaPssParameters jwtRsaSsaPssParameters, BigInteger bigInteger, Optional<Integer> optional, Optional<String> optional2) {
        this.parameters = jwtRsaSsaPssParameters;
        this.modulus = bigInteger;
        this.idRequirement = optional;
        this.kid = optional2;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public BigInteger getModulus() {
        return this.modulus;
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePublicKey
    public Optional<String> getKid() {
        return this.kid;
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePublicKey, com.google.crypto.tink.Key
    public JwtRsaSsaPssParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return this.idRequirement.orElse(null);
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof JwtRsaSsaPssPublicKey)) {
            return false;
        }
        JwtRsaSsaPssPublicKey jwtRsaSsaPssPublicKey = (JwtRsaSsaPssPublicKey) key;
        return jwtRsaSsaPssPublicKey.parameters.equals(this.parameters) && jwtRsaSsaPssPublicKey.modulus.equals(this.modulus) && jwtRsaSsaPssPublicKey.kid.equals(this.kid) && jwtRsaSsaPssPublicKey.idRequirement.equals(this.idRequirement);
    }
}
