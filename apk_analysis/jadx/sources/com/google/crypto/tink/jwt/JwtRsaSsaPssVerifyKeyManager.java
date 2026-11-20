package com.google.crypto.tink.jwt;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.PublicKeyVerify;
import com.google.crypto.tink.internal.PrimitiveConstructor;
import com.google.crypto.tink.signature.RsaSsaPssParameters;
import com.google.crypto.tink.signature.RsaSsaPssPublicKey;
import com.google.crypto.tink.subtle.RsaSsaPssVerifyJce;
import com.google.gson.JsonObject;
import java.nio.charset.StandardCharsets;
import java.security.GeneralSecurityException;
import java.security.InvalidAlgorithmParameterException;

/* JADX INFO: loaded from: classes2.dex */
final class JwtRsaSsaPssVerifyKeyManager {
    static final PrimitiveConstructor<JwtRsaSsaPssPublicKey, JwtPublicKeyVerify> PRIMITIVE_CONSTRUCTOR = PrimitiveConstructor.create(new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.jwt.JwtRsaSsaPssVerifyKeyManager$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
        public final Object constructPrimitive(Key key) {
            return JwtRsaSsaPssVerifyKeyManager.createFullPrimitive((JwtRsaSsaPssPublicKey) key);
        }
    }, JwtRsaSsaPssPublicKey.class, JwtPublicKeyVerify.class);

    private static RsaSsaPssParameters.HashType hashTypeForAlgorithm(JwtRsaSsaPssParameters.Algorithm algorithm) throws GeneralSecurityException {
        if (algorithm.equals(JwtRsaSsaPssParameters.Algorithm.PS256)) {
            return RsaSsaPssParameters.HashType.SHA256;
        }
        if (algorithm.equals(JwtRsaSsaPssParameters.Algorithm.PS384)) {
            return RsaSsaPssParameters.HashType.SHA384;
        }
        if (algorithm.equals(JwtRsaSsaPssParameters.Algorithm.PS512)) {
            return RsaSsaPssParameters.HashType.SHA512;
        }
        throw new GeneralSecurityException("unknown algorithm " + algorithm);
    }

    static final int saltLengthForPssAlgorithm(JwtRsaSsaPssParameters.Algorithm algorithm) throws GeneralSecurityException {
        if (algorithm.equals(JwtRsaSsaPssParameters.Algorithm.PS256)) {
            return 32;
        }
        if (algorithm.equals(JwtRsaSsaPssParameters.Algorithm.PS384)) {
            return 48;
        }
        if (algorithm.equals(JwtRsaSsaPssParameters.Algorithm.PS512)) {
            return 64;
        }
        throw new GeneralSecurityException("unknown algorithm " + algorithm);
    }

    @AccessesPartialKey
    static RsaSsaPssPublicKey toRsaSsaPssPublicKey(JwtRsaSsaPssPublicKey jwtRsaSsaPssPublicKey) throws GeneralSecurityException {
        return RsaSsaPssPublicKey.builder().setParameters(RsaSsaPssParameters.builder().setModulusSizeBits(jwtRsaSsaPssPublicKey.getParameters().getModulusSizeBits()).setPublicExponent(jwtRsaSsaPssPublicKey.getParameters().getPublicExponent()).setSigHashType(hashTypeForAlgorithm(jwtRsaSsaPssPublicKey.getParameters().getAlgorithm())).setMgf1HashType(hashTypeForAlgorithm(jwtRsaSsaPssPublicKey.getParameters().getAlgorithm())).setSaltLengthBytes(saltLengthForPssAlgorithm(jwtRsaSsaPssPublicKey.getParameters().getAlgorithm())).setVariant(RsaSsaPssParameters.Variant.NO_PREFIX).build()).setModulus(jwtRsaSsaPssPublicKey.getModulus()).build();
    }

    static JwtPublicKeyVerify createFullPrimitive(final JwtRsaSsaPssPublicKey jwtRsaSsaPssPublicKey) {
        final PublicKeyVerify publicKeyVerifyCreate = RsaSsaPssVerifyJce.create(toRsaSsaPssPublicKey(jwtRsaSsaPssPublicKey));
        return new JwtPublicKeyVerify() { // from class: com.google.crypto.tink.jwt.JwtRsaSsaPssVerifyKeyManager.1
            @Override // com.google.crypto.tink.jwt.JwtPublicKeyVerify
            public VerifiedJwt verifyAndDecode(String str, JwtValidator jwtValidator) throws JwtInvalidException, InvalidAlgorithmParameterException {
                JwtFormat.Parts partsSplitSignedCompact = JwtFormat.splitSignedCompact(str);
                publicKeyVerifyCreate.verify(partsSplitSignedCompact.signatureOrMac, partsSplitSignedCompact.unsignedCompact.getBytes(StandardCharsets.US_ASCII));
                JsonObject json = JsonUtil.parseJson(partsSplitSignedCompact.header);
                JwtFormat.validateHeader(json, jwtRsaSsaPssPublicKey.getParameters().getAlgorithm().getStandardName(), jwtRsaSsaPssPublicKey.getKid(), jwtRsaSsaPssPublicKey.getParameters().allowKidAbsent());
                return jwtValidator.validate(RawJwt.fromJsonPayload(JwtFormat.getTypeHeader(json), partsSplitSignedCompact.payload));
            }
        };
    }

    static String getKeyType() {
        return "type.googleapis.com/google.crypto.tink.JwtRsaSsaPssPublicKey";
    }

    private JwtRsaSsaPssVerifyKeyManager() {
    }
}
