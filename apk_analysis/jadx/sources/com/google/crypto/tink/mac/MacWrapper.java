package com.google.crypto.tink.mac;

import com.google.crypto.tink.Key;
import com.google.crypto.tink.Mac;
import com.google.crypto.tink.internal.KeysetHandleInterface;
import com.google.crypto.tink.internal.LegacyProtoKey;
import com.google.crypto.tink.internal.MonitoringClient;
import com.google.crypto.tink.internal.MonitoringUtil;
import com.google.crypto.tink.internal.MutableMonitoringRegistry;
import com.google.crypto.tink.internal.MutablePrimitiveRegistry;
import com.google.crypto.tink.internal.PrefixMap;
import com.google.crypto.tink.internal.PrimitiveConstructor;
import com.google.crypto.tink.internal.PrimitiveRegistry;
import com.google.crypto.tink.internal.PrimitiveSet;
import com.google.crypto.tink.internal.PrimitiveWrapper;
import com.google.crypto.tink.mac.internal.LegacyFullMac;
import com.google.crypto.tink.util.Bytes;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public class MacWrapper implements PrimitiveWrapper<Mac, Mac> {
    private static final MacWrapper WRAPPER = new MacWrapper();
    private static final PrimitiveConstructor<LegacyProtoKey, Mac> LEGACY_FULL_MAC_PRIMITIVE_CONSTRUCTOR = PrimitiveConstructor.create(new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.mac.MacWrapper$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
        public final Object constructPrimitive(Key key) {
            return LegacyFullMac.create((LegacyProtoKey) key);
        }
    }, LegacyProtoKey.class, Mac.class);

    private static class MacWithId {
        public final int id;
        public final Mac mac;

        public MacWithId(Mac mac, int i) {
            this.mac = mac;
            this.id = i;
        }
    }

    private static Bytes getOutputPrefix(Key key) throws GeneralSecurityException {
        if (key instanceof MacKey) {
            return ((MacKey) key).getOutputPrefix();
        }
        if (key instanceof LegacyProtoKey) {
            return ((LegacyProtoKey) key).getOutputPrefix();
        }
        throw new GeneralSecurityException("Cannot get output prefix for key of class " + key.getClass().getName() + " with parameters " + key.getParameters());
    }

    private static class WrappedMac implements Mac {
        private final PrefixMap<MacWithId> allMacs;
        private final MonitoringClient.Logger computeLogger;
        private final MacWithId primary;
        private final MonitoringClient.Logger verifyLogger;

        private WrappedMac(MacWithId macWithId, PrefixMap<MacWithId> prefixMap, MonitoringClient.Logger logger, MonitoringClient.Logger logger2) {
            this.primary = macWithId;
            this.allMacs = prefixMap;
            this.computeLogger = logger;
            this.verifyLogger = logger2;
        }

        @Override // com.google.crypto.tink.Mac
        public byte[] computeMac(byte[] bArr) throws GeneralSecurityException {
            try {
                byte[] bArrComputeMac = this.primary.mac.computeMac(bArr);
                this.computeLogger.log(this.primary.id, bArr.length);
                return bArrComputeMac;
            } catch (GeneralSecurityException e) {
                this.computeLogger.logFailure();
                throw e;
            }
        }

        @Override // com.google.crypto.tink.Mac
        public void verifyMac(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
            for (MacWithId macWithId : this.allMacs.getAllWithMatchingPrefix(bArr)) {
                try {
                    macWithId.mac.verifyMac(bArr, bArr2);
                    this.verifyLogger.log(macWithId.id, bArr2.length);
                    return;
                } catch (GeneralSecurityException unused) {
                }
            }
            this.verifyLogger.logFailure();
            throw new GeneralSecurityException("invalid MAC");
        }
    }

    MacWrapper() {
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Mac wrap(PrimitiveSet<Mac> primitiveSet) throws GeneralSecurityException {
        MonitoringClient.Logger logger;
        MonitoringClient.Logger loggerCreateLogger;
        PrefixMap.Builder builder = new PrefixMap.Builder();
        KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
        for (int i = 0; i < keysetHandle.size(); i++) {
            KeysetHandleInterface.Entry at = keysetHandle.getAt(i);
            builder.put(getOutputPrefix(at.getKey()), new MacWithId(primitiveSet.getPrimitiveForEntry(at), at.getId()));
        }
        if (!primitiveSet.getAnnotations().isEmpty()) {
            MonitoringClient monitoringClient = MutableMonitoringRegistry.globalInstance().getMonitoringClient();
            MonitoringClient.Logger loggerCreateLogger2 = monitoringClient.createLogger(keysetHandle, primitiveSet.getAnnotations(), "mac", "compute");
            loggerCreateLogger = monitoringClient.createLogger(keysetHandle, primitiveSet.getAnnotations(), "mac", "verify");
            logger = loggerCreateLogger2;
        } else {
            logger = MonitoringUtil.DO_NOTHING_LOGGER;
            loggerCreateLogger = logger;
        }
        return new WrappedMac(new MacWithId(primitiveSet.getPrimitiveForEntry(keysetHandle.getPrimary()), keysetHandle.getPrimary().getId()), builder.build(), logger, loggerCreateLogger);
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<Mac> getPrimitiveClass() {
        return Mac.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<Mac> getInputPrimitiveClass() {
        return Mac.class;
    }

    static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveConstructor(LEGACY_FULL_MAC_PRIMITIVE_CONSTRUCTOR);
    }

    public static void registerToInternalPrimitiveRegistry(PrimitiveRegistry.Builder builder) throws GeneralSecurityException {
        builder.registerPrimitiveWrapper(WRAPPER);
    }
}
