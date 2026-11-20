package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.internal.EllipticCurvesUtil;
import com.google.crypto.tink.util.SecretBigInteger;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.RestrictedApi;
import java.math.BigInteger;
import java.security.GeneralSecurityException;
import java.security.spec.ECPoint;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class JwtEcdsaPrivateKey extends JwtSignaturePrivateKey {
    public final SecretBigInteger privateKeyValue;
    public final JwtEcdsaPublicKey publicKey;

    private static void validatePrivateValue(BigInteger bigInteger, ECPoint eCPoint, JwtEcdsaParameters.Algorithm algorithm) throws GeneralSecurityException {
        BigInteger order = algorithm.getECParameterSpec().getOrder();
        if (bigInteger.signum() <= 0 || bigInteger.compareTo(order) >= 0) {
            throw new GeneralSecurityException("Invalid private value");
        }
        if (!EllipticCurvesUtil.multiplyByGenerator(bigInteger, algorithm.getECParameterSpec()).equals(eCPoint)) {
            throw new GeneralSecurityException("Invalid private value");
        }
    }

    @AccessesPartialKey
    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static JwtEcdsaPrivateKey create(JwtEcdsaPublicKey jwtEcdsaPublicKey, SecretBigInteger secretBigInteger) throws GeneralSecurityException {
        validatePrivateValue(secretBigInteger.getBigInteger(InsecureSecretKeyAccess.get()), jwtEcdsaPublicKey.getPublicPoint(), jwtEcdsaPublicKey.getParameters().getAlgorithm());
        return new JwtEcdsaPrivateKey(jwtEcdsaPublicKey, secretBigInteger);
    }

    private JwtEcdsaPrivateKey(JwtEcdsaPublicKey jwtEcdsaPublicKey, SecretBigInteger secretBigInteger) {
        this.publicKey = jwtEcdsaPublicKey;
        this.privateKeyValue = secretBigInteger;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public SecretBigInteger getPrivateValue() {
        return this.privateKeyValue;
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePrivateKey, com.google.crypto.tink.Key
    public JwtEcdsaParameters getParameters() {
        return this.publicKey.getParameters();
    }

    @Override // com.google.crypto.tink.jwt.JwtSignaturePrivateKey, com.google.crypto.tink.PrivateKey
    public JwtEcdsaPublicKey getPublicKey() {
        return this.publicKey;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof JwtEcdsaPrivateKey)) {
            return false;
        }
        JwtEcdsaPrivateKey jwtEcdsaPrivateKey = (JwtEcdsaPrivateKey) key;
        return jwtEcdsaPrivateKey.publicKey.equalsKey(this.publicKey) && this.privateKeyValue.equalsSecretBigInteger(jwtEcdsaPrivateKey.privateKeyValue);
    }
}
