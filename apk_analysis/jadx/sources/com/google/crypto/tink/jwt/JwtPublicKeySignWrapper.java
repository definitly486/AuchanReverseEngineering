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

/* JADX INFO: loaded from: classes2.dex */
class JwtPublicKeySignWrapper implements PrimitiveWrapper<JwtPublicKeySign, JwtPublicKeySign> {
    private static final JwtPublicKeySignWrapper WRAPPER = new JwtPublicKeySignWrapper();

    JwtPublicKeySignWrapper() {
    }

    @Immutable
    private static class WrappedJwtPublicKeySign implements JwtPublicKeySign {
        private final MonitoringClient.Logger logger;
        private final JwtPublicKeySign primary;
        private final int primaryKeyId;

        public WrappedJwtPublicKeySign(PrimitiveSet<JwtPublicKeySign> primitiveSet) {
            KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
            this.primary = primitiveSet.getPrimitiveForEntry(keysetHandle.getPrimary());
            this.primaryKeyId = keysetHandle.getPrimary().getId();
            if (!primitiveSet.getAnnotations().isEmpty()) {
                this.logger = MutableMonitoringRegistry.globalInstance().getMonitoringClient().createLogger(keysetHandle, primitiveSet.getAnnotations(), "jwtsign", "sign");
            } else {
                this.logger = MonitoringUtil.DO_NOTHING_LOGGER;
            }
        }

        @Override // com.google.crypto.tink.jwt.JwtPublicKeySign
        public String signAndEncode(RawJwt rawJwt) throws GeneralSecurityException {
            try {
                String strSignAndEncode = this.primary.signAndEncode(rawJwt);
                this.logger.log(this.primaryKeyId, 1L);
                return strSignAndEncode;
            } catch (GeneralSecurityException e) {
                this.logger.logFailure();
                throw e;
            }
        }
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public JwtPublicKeySign wrap(PrimitiveSet<JwtPublicKeySign> primitiveSet) {
        return new WrappedJwtPublicKeySign(primitiveSet);
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<JwtPublicKeySign> getPrimitiveClass() {
        return JwtPublicKeySign.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<JwtPublicKeySign> getInputPrimitiveClass() {
        return JwtPublicKeySign.class;
    }

    public static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
    }
}
