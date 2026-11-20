package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.internal.EllipticCurvesUtil;
import com.google.crypto.tink.subtle.Base64;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.RestrictedApi;
import java.nio.ByteBuffer;
import java.security.GeneralSecurityException;
import java.security.spec.ECPoint;
import java.util.Optional;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class JwtEcdsaPublicKey extends JwtSignaturePublicKey {
    private final Optional<Integer> idRequirement;
    private final Optional<String> kid;
    private final JwtEcdsaParameters parameters;
    private final ECPoint publicPoint;

    public static class Builder {
        private Optional<String> customKid;
        private Optional<Integer> idRequirement;
        private Optional<JwtEcdsaParameters> parameters;
        private Optional<ECPoint> publicPoint;

        private Builder() {
            this.parameters = Optional.empty();
            this.publicPoint = Optional.empty();
            this.idRequirement = Optional.empty();
            this.customKid = Optional.empty();
        }

        @CanIgnoreReturnValue
        public Builder setParameters(JwtEcdsaParameters jwtEcdsaParameters) {
            this.parameters = Optional.of(jwtEcdsaParameters);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPublicPoint(ECPoint eCPoint) {
            this.publicPoint = Optional.of(eCPoint);
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
            if (this.parameters.get().getKidStrategy().equals(JwtEcdsaParameters.KidStrategy.BASE64_ENCODED_KEY_ID)) {
                if (this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid must not be set for KidStrategy BASE64_ENCODED_KEY_ID");
                }
                return Optional.of(Base64.urlSafeEncode(ByteBuffer.allocate(4).putInt(this.idRequirement.get().intValue()).array()));
            }
            if (this.parameters.get().getKidStrategy().equals(JwtEcdsaParameters.KidStrategy.CUSTOM)) {
                if (!this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid needs to be set for KidStrategy CUSTOM");
                }
                return this.customKid;
            }
            if (this.parameters.get().getKidStrategy().equals(JwtEcdsaParameters.KidStrategy.IGNORED)) {
                if (this.customKid.isPresent()) {
                    throw new GeneralSecurityException("customKid must not be set for KidStrategy IGNORED");
                }
                return Optional.empty();
            }
            throw new IllegalStateException("Unknown kid strategy");
        }

        public JwtEcdsaPublicKey build() throws GeneralSecurityException {
            if (!this.parameters.isPresent()) {
                throw new GeneralSecurityException("Cannot build without parameters");
            }
            if (!this.publicPoint.isPresent()) {
                throw new GeneralSecurityException("Cannot build without public point");
            }
            EllipticCurvesUtil.checkPointOnCurve(this.publicPoint.get(), this.parameters.get().getAlgorithm().getECParameterSpec().getCurve());
            if (this.parameters.get().hasIdRequirement() && !this.idRequirement.isPresent()) {
                throw new GeneralSecurityException("Cannot create key without ID requirement with parameters with ID requirement");
            }
            if (!this.parameters.get().hasIdRequirement() && this.idRequirement.isPresent()) {
                throw new GeneralSecurityException("Cannot create key with ID requirement with parameters without ID requirement");
            }
            return new JwtEcdsaPublicKey(this.parameters.get(), this.publicPoint.get(), computeKid(), this.idRequirement);
        }
    }

    private JwtEcdsaPublicKey(JwtEcdsaParameters jwtEcdsaParameters, ECPoint eCPoint, Optional<String> optional, Optional<Integer> optional2) {
        this.parameters = jwtEcdsaParameters;
        this.publicPoint = eCPoint;
        this.kid = optional;
        this.idRequirement = optional2;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public ECPoint getPublicPoint() {
        return this.publicPoint;
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePublicKey
    public Optional<String> getKid() {
        return this.kid;
    }

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return this.idRequirement.orElse(null);
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePublicKey, com.google.crypto.tink.Key
    public JwtEcdsaParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof JwtEcdsaPublicKey)) {
            return false;
        }
        JwtEcdsaPublicKey jwtEcdsaPublicKey = (JwtEcdsaPublicKey) key;
        return jwtEcdsaPublicKey.parameters.equals(this.parameters) && jwtEcdsaPublicKey.publicPoint.equals(this.publicPoint) && jwtEcdsaPublicKey.kid.equals(this.kid);
    }
}
