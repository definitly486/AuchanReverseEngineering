package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.util.SecretBigInteger;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.RestrictedApi;
import java.math.BigInteger;
import java.security.GeneralSecurityException;
import java.util.Optional;

/* JADX INFO: loaded from: classes2.dex */
public final class JwtRsaSsaPssPrivateKey extends JwtSignaturePrivateKey {
    private final SecretBigInteger d;
    private final SecretBigInteger dP;
    private final SecretBigInteger dQ;
    private final SecretBigInteger p;
    private final JwtRsaSsaPssPublicKey publicKey;
    private final SecretBigInteger q;
    private final SecretBigInteger qInv;

    public static class Builder {
        private static final int PRIME_CERTAINTY = 10;
        private Optional<SecretBigInteger> d;
        private Optional<SecretBigInteger> dP;
        private Optional<SecretBigInteger> dQ;
        private Optional<SecretBigInteger> p;
        private Optional<JwtRsaSsaPssPublicKey> publicKey;
        private Optional<SecretBigInteger> q;
        private Optional<SecretBigInteger> qInv;

        private Builder() {
            this.publicKey = Optional.empty();
            this.d = Optional.empty();
            this.p = Optional.empty();
            this.q = Optional.empty();
            this.dP = Optional.empty();
            this.dQ = Optional.empty();
            this.qInv = Optional.empty();
        }

        @CanIgnoreReturnValue
        public Builder setPublicKey(JwtRsaSsaPssPublicKey jwtRsaSsaPssPublicKey) {
            this.publicKey = Optional.of(jwtRsaSsaPssPublicKey);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPrimes(SecretBigInteger secretBigInteger, SecretBigInteger secretBigInteger2) {
            this.p = Optional.of(secretBigInteger);
            this.q = Optional.of(secretBigInteger2);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPrivateExponent(SecretBigInteger secretBigInteger) {
            this.d = Optional.of(secretBigInteger);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPrimeExponents(SecretBigInteger secretBigInteger, SecretBigInteger secretBigInteger2) {
            this.dP = Optional.of(secretBigInteger);
            this.dQ = Optional.of(secretBigInteger2);
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setCrtCoefficient(SecretBigInteger secretBigInteger) {
            this.qInv = Optional.of(secretBigInteger);
            return this;
        }

        @AccessesPartialKey
        public JwtRsaSsaPssPrivateKey build() throws GeneralSecurityException {
            if (!this.publicKey.isPresent()) {
                throw new GeneralSecurityException("Cannot build without a RSA SSA PSS public key");
            }
            if (!this.p.isPresent() || !this.q.isPresent()) {
                throw new GeneralSecurityException("Cannot build without prime factors");
            }
            if (!this.d.isPresent()) {
                throw new GeneralSecurityException("Cannot build without private exponent");
            }
            if (!this.dP.isPresent() || !this.dQ.isPresent()) {
                throw new GeneralSecurityException("Cannot build without prime exponents");
            }
            if (!this.qInv.isPresent()) {
                throw new GeneralSecurityException("Cannot build without CRT coefficient");
            }
            BigInteger publicExponent = this.publicKey.get().getParameters().getPublicExponent();
            BigInteger modulus = this.publicKey.get().getModulus();
            BigInteger bigInteger = this.p.get().getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger2 = this.q.get().getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger3 = this.d.get().getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger4 = this.dP.get().getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger5 = this.dQ.get().getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger6 = this.qInv.get().getBigInteger(InsecureSecretKeyAccess.get());
            if (!bigInteger.isProbablePrime(10)) {
                throw new GeneralSecurityException("p is not a prime");
            }
            if (!bigInteger2.isProbablePrime(10)) {
                throw new GeneralSecurityException("q is not a prime");
            }
            if (!bigInteger.multiply(bigInteger2).equals(modulus)) {
                throw new GeneralSecurityException("Prime p times prime q is not equal to the public key's modulus");
            }
            BigInteger bigInteger7 = BigInteger.ONE;
            BigInteger bigIntegerSubtract = bigInteger.subtract(bigInteger7);
            BigInteger bigIntegerSubtract2 = bigInteger2.subtract(bigInteger7);
            if (!publicExponent.multiply(bigInteger3).mod(bigIntegerSubtract.divide(bigIntegerSubtract.gcd(bigIntegerSubtract2)).multiply(bigIntegerSubtract2)).equals(bigInteger7)) {
                throw new GeneralSecurityException("D is invalid.");
            }
            if (!publicExponent.multiply(bigInteger4).mod(bigIntegerSubtract).equals(bigInteger7)) {
                throw new GeneralSecurityException("dP is invalid.");
            }
            if (!publicExponent.multiply(bigInteger5).mod(bigIntegerSubtract2).equals(bigInteger7)) {
                throw new GeneralSecurityException("dQ is invalid.");
            }
            if (!bigInteger2.multiply(bigInteger6).mod(bigInteger).equals(bigInteger7)) {
                throw new GeneralSecurityException("qInv is invalid.");
            }
            return new JwtRsaSsaPssPrivateKey(this.publicKey.get(), this.p.get(), this.q.get(), this.d.get(), this.dP.get(), this.dQ.get(), this.qInv.get());
        }
    }

    private JwtRsaSsaPssPrivateKey(JwtRsaSsaPssPublicKey jwtRsaSsaPssPublicKey, SecretBigInteger secretBigInteger, SecretBigInteger secretBigInteger2, SecretBigInteger secretBigInteger3, SecretBigInteger secretBigInteger4, SecretBigInteger secretBigInteger5, SecretBigInteger secretBigInteger6) {
        this.publicKey = jwtRsaSsaPssPublicKey;
        this.p = secretBigInteger;
        this.q = secretBigInteger2;
        this.d = secretBigInteger3;
        this.dP = secretBigInteger4;
        this.dQ = secretBigInteger5;
        this.qInv = secretBigInteger6;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePrivateKey, com.google.crypto.tink.Key
    public JwtRsaSsaPssParameters getParameters() {
        return this.publicKey.getParameters();
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePrivateKey, com.google.crypto.tink.PrivateKey
    public JwtRsaSsaPssPublicKey getPublicKey() {
        return this.publicKey;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBigInteger getPrimeP() {
        return this.p;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBigInteger getPrimeQ() {
        return this.q;
    }

    public SecretBigInteger getPrivateExponent() {
        return this.d;
    }

    public SecretBigInteger getPrimeExponentP() {
        return this.dP;
    }

    public SecretBigInteger getPrimeExponentQ() {
        return this.dQ;
    }

    public SecretBigInteger getCrtCoefficient() {
        return this.qInv;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof JwtRsaSsaPssPrivateKey)) {
            return false;
        }
        JwtRsaSsaPssPrivateKey jwtRsaSsaPssPrivateKey = (JwtRsaSsaPssPrivateKey) key;
        return jwtRsaSsaPssPrivateKey.publicKey.equalsKey(this.publicKey) && this.p.equalsSecretBigInteger(jwtRsaSsaPssPrivateKey.p) && this.q.equalsSecretBigInteger(jwtRsaSsaPssPrivateKey.q) && this.d.equalsSecretBigInteger(jwtRsaSsaPssPrivateKey.d) && this.dP.equalsSecretBigInteger(jwtRsaSsaPssPrivateKey.dP) && this.dQ.equalsSecretBigInteger(jwtRsaSsaPssPrivateKey.dQ) && this.qInv.equalsSecretBigInteger(jwtRsaSsaPssPrivateKey.qInv);
    }
}
