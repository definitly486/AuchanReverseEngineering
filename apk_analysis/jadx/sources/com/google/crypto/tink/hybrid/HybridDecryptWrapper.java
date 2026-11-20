package com.google.crypto.tink.hybrid;

import com.google.crypto.tink.HybridDecrypt;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.hybrid.internal.LegacyFullHybridDecrypt;
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
import com.google.crypto.tink.util.Bytes;
import java.security.GeneralSecurityException;

/* JADX INFO: loaded from: classes2.dex */
public class HybridDecryptWrapper implements PrimitiveWrapper<HybridDecrypt, HybridDecrypt> {
    private static final HybridDecryptWrapper WRAPPER = new HybridDecryptWrapper();
    private static final PrimitiveConstructor<LegacyProtoKey, HybridDecrypt> LEGACY_PRIMITIVE_CONSTRUCTOR = PrimitiveConstructor.create(new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.hybrid.HybridDecryptWrapper$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
        public final Object constructPrimitive(Key key) {
            return LegacyFullHybridDecrypt.create((LegacyProtoKey) key);
        }
    }, LegacyProtoKey.class, HybridDecrypt.class);

    private static class HybridDecryptWithId {
        public final HybridDecrypt hybridDecrypt;
        public final int id;

        public HybridDecryptWithId(HybridDecrypt hybridDecrypt, int i) {
            this.hybridDecrypt = hybridDecrypt;
            this.id = i;
        }
    }

    private static Bytes getOutputPrefix(Key key) throws GeneralSecurityException {
        if (key instanceof HybridPrivateKey) {
            return ((HybridPrivateKey) key).getOutputPrefix();
        }
        if (key instanceof LegacyProtoKey) {
            return ((LegacyProtoKey) key).getOutputPrefix();
        }
        throw new GeneralSecurityException("Cannot get output prefix for key of class " + key.getClass().getName() + " with parameters " + key.getParameters());
    }

    private static class WrappedHybridDecrypt implements HybridDecrypt {
        private final PrefixMap<HybridDecryptWithId> allHybridDecrypts;
        private final MonitoringClient.Logger decLogger;

        public WrappedHybridDecrypt(PrefixMap<HybridDecryptWithId> prefixMap, MonitoringClient.Logger logger) {
            this.allHybridDecrypts = prefixMap;
            this.decLogger = logger;
        }

        @Override // com.google.crypto.tink.HybridDecrypt
        public byte[] decrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
            for (HybridDecryptWithId hybridDecryptWithId : this.allHybridDecrypts.getAllWithMatchingPrefix(bArr)) {
                try {
                    byte[] bArrDecrypt = hybridDecryptWithId.hybridDecrypt.decrypt(bArr, bArr2);
                    this.decLogger.log(hybridDecryptWithId.id, bArr.length);
                    return bArrDecrypt;
                } catch (GeneralSecurityException unused) {
                }
            }
            this.decLogger.logFailure();
            throw new GeneralSecurityException("decryption failed");
        }
    }

    HybridDecryptWrapper() {
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public HybridDecrypt wrap(PrimitiveSet<HybridDecrypt> primitiveSet) throws GeneralSecurityException {
        MonitoringClient.Logger loggerCreateLogger;
        PrefixMap.Builder builder = new PrefixMap.Builder();
        KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
        for (int i = 0; i < keysetHandle.size(); i++) {
            KeysetHandleInterface.Entry at = keysetHandle.getAt(i);
            builder.put(getOutputPrefix(at.getKey()), new HybridDecryptWithId(primitiveSet.getPrimitiveForEntry(at), at.getId()));
        }
        if (!primitiveSet.getAnnotations().isEmpty()) {
            loggerCreateLogger = MutableMonitoringRegistry.globalInstance().getMonitoringClient().createLogger(keysetHandle, primitiveSet.getAnnotations(), "hybrid_decrypt", "decrypt");
        } else {
            loggerCreateLogger = MonitoringUtil.DO_NOTHING_LOGGER;
        }
        return new WrappedHybridDecrypt(builder.build(), loggerCreateLogger);
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<HybridDecrypt> getPrimitiveClass() {
        return HybridDecrypt.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<HybridDecrypt> getInputPrimitiveClass() {
        return HybridDecrypt.class;
    }

    public static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveConstructor(LEGACY_PRIMITIVE_CONSTRUCTOR);
    }

    public static void registerToInternalPrimitiveRegistry(PrimitiveRegistry.Builder builder) throws GeneralSecurityException {
        builder.registerPrimitiveWrapper(WRAPPER);
    }
}
