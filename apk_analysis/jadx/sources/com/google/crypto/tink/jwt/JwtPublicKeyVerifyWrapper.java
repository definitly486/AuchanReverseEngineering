package com.google.crypto.tink.jwt;

import com.google.crypto.tink.internal.KeysetHandleInterface;
import com.google.crypto.tink.internal.MonitoringClient;
import com.google.crypto.tink.internal.MonitoringUtil;
import com.google.crypto.tink.internal.MutableMonitoringRegistry;
import com.google.crypto.tink.internal.MutablePrimitiveRegistry;
import com.google.crypto.tink.internal.PrimitiveSet;
import com.google.crypto.tink.internal.PrimitiveWrapper;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes2.dex */
class JwtPublicKeyVerifyWrapper implements PrimitiveWrapper<JwtPublicKeyVerify, JwtPublicKeyVerify> {
    private static final JwtPublicKeyVerifyWrapper WRAPPER = new JwtPublicKeyVerifyWrapper();

    JwtPublicKeyVerifyWrapper() {
    }

    private static class JwtPublicKeyVerifyWithId {
        final int id;
        final JwtPublicKeyVerify verify;

        JwtPublicKeyVerifyWithId(JwtPublicKeyVerify jwtPublicKeyVerify, int i) {
            this.verify = jwtPublicKeyVerify;
            this.id = i;
        }
    }

    @Immutable
    private static class WrappedJwtPublicKeyVerify implements JwtPublicKeyVerify {
        private final List<JwtPublicKeyVerifyWithId> allVerifiers;
        private final MonitoringClient.Logger logger;

        public WrappedJwtPublicKeyVerify(MonitoringClient.Logger logger, List<JwtPublicKeyVerifyWithId> list) {
            this.logger = logger;
            this.allVerifiers = list;
        }

        @Override // com.google.crypto.tink.jwt.JwtPublicKeyVerify
        public VerifiedJwt verifyAndDecode(String str, JwtValidator jwtValidator) throws GeneralSecurityException {
            GeneralSecurityException generalSecurityException = null;
            for (JwtPublicKeyVerifyWithId jwtPublicKeyVerifyWithId : this.allVerifiers) {
                try {
                    VerifiedJwt verifiedJwtVerifyAndDecode = jwtPublicKeyVerifyWithId.verify.verifyAndDecode(str, jwtValidator);
                    this.logger.log(jwtPublicKeyVerifyWithId.id, 1L);
                    return verifiedJwtVerifyAndDecode;
                } catch (GeneralSecurityException e) {
                    if (e instanceof JwtInvalidException) {
                        generalSecurityException = e;
                    }
                }
            }
            this.logger.logFailure();
            if (generalSecurityException != null) {
                throw generalSecurityException;
            }
            throw new GeneralSecurityException("invalid JWT");
        }
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public JwtPublicKeyVerify wrap(PrimitiveSet<JwtPublicKeyVerify> primitiveSet) {
        MonitoringClient.Logger loggerCreateLogger;
        KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
        ArrayList arrayList = new ArrayList(keysetHandle.size());
        for (int i = 0; i < keysetHandle.size(); i++) {
            KeysetHandleInterface.Entry at = keysetHandle.getAt(i);
            arrayList.add(new JwtPublicKeyVerifyWithId(primitiveSet.getPrimitiveForEntry(at), at.getId()));
        }
        if (!primitiveSet.getAnnotations().isEmpty()) {
            loggerCreateLogger = MutableMonitoringRegistry.globalInstance().getMonitoringClient().createLogger(keysetHandle, primitiveSet.getAnnotations(), "jwtverify", "verify");
        } else {
            loggerCreateLogger = MonitoringUtil.DO_NOTHING_LOGGER;
        }
        return new WrappedJwtPublicKeyVerify(loggerCreateLogger, arrayList);
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<JwtPublicKeyVerify> getPrimitiveClass() {
        return JwtPublicKeyVerify.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<JwtPublicKeyVerify> getInputPrimitiveClass() {
        return JwtPublicKeyVerify.class;
    }

    public static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
    }
}
