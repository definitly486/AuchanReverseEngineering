package com.google.crypto.tink.signature;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.util.SecretBigInteger;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.RestrictedApi;
import java.math.BigInteger;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public final class RsaSsaPkcs1PrivateKey extends SignaturePrivateKey {
    private final SecretBigInteger d;
    private final SecretBigInteger dP;
    private final SecretBigInteger dQ;
    private final SecretBigInteger p;
    private final RsaSsaPkcs1PublicKey publicKey;
    private final SecretBigInteger q;
    private final SecretBigInteger qInv;

    public static class Builder {
        private static final int PRIME_CERTAINTY = 10;
        private SecretBigInteger d;
        private SecretBigInteger dP;
        private SecretBigInteger dQ;
        private SecretBigInteger p;
        private RsaSsaPkcs1PublicKey publicKey;
        private SecretBigInteger q;
        private SecretBigInteger qInv;

        private Builder() {
            this.publicKey = null;
            this.d = null;
            this.p = null;
            this.q = null;
            this.dP = null;
            this.dQ = null;
            this.qInv = null;
        }

        @CanIgnoreReturnValue
        public Builder setPublicKey(RsaSsaPkcs1PublicKey rsaSsaPkcs1PublicKey) {
            this.publicKey = rsaSsaPkcs1PublicKey;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPrimes(SecretBigInteger secretBigInteger, SecretBigInteger secretBigInteger2) {
            this.p = secretBigInteger;
            this.q = secretBigInteger2;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPrivateExponent(SecretBigInteger secretBigInteger) {
            this.d = secretBigInteger;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setPrimeExponents(SecretBigInteger secretBigInteger, SecretBigInteger secretBigInteger2) {
            this.dP = secretBigInteger;
            this.dQ = secretBigInteger2;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setCrtCoefficient(SecretBigInteger secretBigInteger) {
            this.qInv = secretBigInteger;
            return this;
        }

        @AccessesPartialKey
        public RsaSsaPkcs1PrivateKey build() throws GeneralSecurityException {
            RsaSsaPkcs1PublicKey rsaSsaPkcs1PublicKey = this.publicKey;
            if (rsaSsaPkcs1PublicKey == null) {
                throw new GeneralSecurityException("Cannot build without a RSA SSA PKCS1 public key");
            }
            if (this.p == null || this.q == null) {
                throw new GeneralSecurityException("Cannot build without prime factors");
            }
            if (this.d == null) {
                throw new GeneralSecurityException("Cannot build without private exponent");
            }
            if (this.dP == null || this.dQ == null) {
                throw new GeneralSecurityException("Cannot build without prime exponents");
            }
            if (this.qInv == null) {
                throw new GeneralSecurityException("Cannot build without CRT coefficient");
            }
            BigInteger publicExponent = rsaSsaPkcs1PublicKey.getParameters().getPublicExponent();
            BigInteger modulus = this.publicKey.getModulus();
            BigInteger bigInteger = this.p.getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger2 = this.q.getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger3 = this.d.getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger4 = this.dP.getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger5 = this.dQ.getBigInteger(InsecureSecretKeyAccess.get());
            BigInteger bigInteger6 = this.qInv.getBigInteger(InsecureSecretKeyAccess.get());
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
            return new RsaSsaPkcs1PrivateKey(this.publicKey, this.p, this.q, this.d, this.dP, this.dQ, this.qInv);
        }
    }

    private RsaSsaPkcs1PrivateKey(RsaSsaPkcs1PublicKey rsaSsaPkcs1PublicKey, SecretBigInteger secretBigInteger, SecretBigInteger secretBigInteger2, SecretBigInteger secretBigInteger3, SecretBigInteger secretBigInteger4, SecretBigInteger secretBigInteger5, SecretBigInteger secretBigInteger6) {
        this.publicKey = rsaSsaPkcs1PublicKey;
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

    @Override // com.google.crypto.tink.signature.SignaturePrivateKey, com.google.crypto.tink.Key
    public RsaSsaPkcs1Parameters getParameters() {
        return this.publicKey.getParameters();
    }

    @Override // com.google.crypto.tink.signature.SignaturePrivateKey, com.google.crypto.tink.PrivateKey
    public RsaSsaPkcs1PublicKey getPublicKey() {
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
        if (!(key instanceof RsaSsaPkcs1PrivateKey)) {
            return false;
        }
        RsaSsaPkcs1PrivateKey rsaSsaPkcs1PrivateKey = (RsaSsaPkcs1PrivateKey) key;
        return rsaSsaPkcs1PrivateKey.publicKey.equalsKey(this.publicKey) && this.p.equalsSecretBigInteger(rsaSsaPkcs1PrivateKey.p) && this.q.equalsSecretBigInteger(rsaSsaPkcs1PrivateKey.q) && this.d.equalsSecretBigInteger(rsaSsaPkcs1PrivateKey.d) && this.dP.equalsSecretBigInteger(rsaSsaPkcs1PrivateKey.dP) && this.dQ.equalsSecretBigInteger(rsaSsaPkcs1PrivateKey.dQ) && this.qInv.equalsSecretBigInteger(rsaSsaPkcs1PrivateKey.qInv);
    }
}
