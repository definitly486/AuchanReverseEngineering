package com.google.crypto.tink.prf;

import com.google.crypto.tink.Key;
import com.google.crypto.tink.internal.KeysetHandleInterface;
import com.google.crypto.tink.internal.LegacyProtoKey;
import com.google.crypto.tink.internal.MonitoringClient;
import com.google.crypto.tink.internal.MonitoringUtil;
import com.google.crypto.tink.internal.MutableMonitoringRegistry;
import com.google.crypto.tink.internal.MutablePrimitiveRegistry;
import com.google.crypto.tink.internal.PrimitiveConstructor;
import com.google.crypto.tink.internal.PrimitiveRegistry;
import com.google.crypto.tink.internal.PrimitiveSet;
import com.google.crypto.tink.internal.PrimitiveWrapper;
import com.google.crypto.tink.prf.internal.LegacyFullPrf;
import com.google.errorprone.annotations.Immutable;
import java.security.GeneralSecurityException;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public class PrfSetWrapper implements PrimitiveWrapper<Prf, PrfSet> {
    private static final PrfSetWrapper WRAPPER = new PrfSetWrapper();
    private static final PrimitiveConstructor<LegacyProtoKey, Prf> LEGACY_FULL_PRF_PRIMITIVE_CONSTRUCTOR = PrimitiveConstructor.create(new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.prf.PrfSetWrapper$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
        public final Object constructPrimitive(Key key) {
            return LegacyFullPrf.create((LegacyProtoKey) key);
        }
    }, LegacyProtoKey.class, Prf.class);

    private static class WrappedPrfSet extends PrfSet {
        private final Map<Integer, Prf> keyIdToPrfMap;
        private final int primaryKeyId;

        @Immutable
        private static class PrfWithMonitoring implements Prf {
            private final int keyId;
            private final MonitoringClient.Logger logger;
            private final Prf prf;

            @Override // com.google.crypto.tink.prf.Prf
            public byte[] compute(byte[] bArr, int i) throws GeneralSecurityException {
                try {
                    byte[] bArrCompute = this.prf.compute(bArr, i);
                    this.logger.log(this.keyId, bArr.length);
                    return bArrCompute;
                } catch (GeneralSecurityException e) {
                    this.logger.logFailure();
                    throw e;
                }
            }

            public PrfWithMonitoring(Prf prf, int i, MonitoringClient.Logger logger) {
                this.prf = prf;
                this.keyId = i;
                this.logger = logger;
            }
        }

        private WrappedPrfSet(Map<Integer, Prf> map, int i) {
            this.keyIdToPrfMap = map;
            this.primaryKeyId = i;
        }

        @Override // com.google.crypto.tink.prf.PrfSet
        public int getPrimaryId() {
            return this.primaryKeyId;
        }

        @Override // com.google.crypto.tink.prf.PrfSet
        public Map<Integer, Prf> getPrfs() {
            return this.keyIdToPrfMap;
        }
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public PrfSet wrap(PrimitiveSet<Prf> primitiveSet) throws GeneralSecurityException {
        MonitoringClient.Logger loggerCreateLogger;
        KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
        if (!primitiveSet.getAnnotations().isEmpty()) {
            loggerCreateLogger = MutableMonitoringRegistry.globalInstance().getMonitoringClient().createLogger(keysetHandle, primitiveSet.getAnnotations(), "prf", "compute");
        } else {
            loggerCreateLogger = MonitoringUtil.DO_NOTHING_LOGGER;
        }
        HashMap map = new HashMap();
        for (int i = 0; i < keysetHandle.size(); i++) {
            KeysetHandleInterface.Entry at = keysetHandle.getAt(i);
            if ((at.getKey() instanceof LegacyProtoKey) && ((LegacyProtoKey) at.getKey()).getOutputPrefix().size() != 0) {
                throw new GeneralSecurityException("Cannot build PrfSet with keys with non-empty output prefix");
            }
            map.put(Integer.valueOf(at.getId()), new WrappedPrfSet.PrfWithMonitoring(primitiveSet.getPrimitiveForEntry(at), at.getId(), loggerCreateLogger));
        }
        return new WrappedPrfSet(map, keysetHandle.getPrimary().getId());
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<PrfSet> getPrimitiveClass() {
        return PrfSet.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<Prf> getInputPrimitiveClass() {
        return Prf.class;
    }

    public static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveConstructor(LEGACY_FULL_PRF_PRIMITIVE_CONSTRUCTOR);
    }

    public static void registerToInternalPrimitiveRegistry(PrimitiveRegistry.Builder builder) throws GeneralSecurityException {
        builder.registerPrimitiveWrapper(WRAPPER);
    }
}
