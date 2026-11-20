package com.google.crypto.tink.aead;

import com.google.crypto.tink.Aead;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.aead.internal.LegacyFullAead;
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
public class AeadWrapper implements PrimitiveWrapper<Aead, Aead> {
    private static final AeadWrapper WRAPPER = new AeadWrapper();
    private static final PrimitiveConstructor<LegacyProtoKey, Aead> LEGACY_FULL_AEAD_PRIMITIVE_CONSTRUCTOR = PrimitiveConstructor.create(new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.aead.AeadWrapper$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
        public final Object constructPrimitive(Key key) {
            return LegacyFullAead.create((LegacyProtoKey) key);
        }
    }, LegacyProtoKey.class, Aead.class);

    private static class AeadWithId {
        public final Aead aead;
        public final int id;

        public AeadWithId(Aead aead, int i) {
            this.aead = aead;
            this.id = i;
        }
    }

    private static Bytes getOutputPrefix(Key key) throws GeneralSecurityException {
        if (key instanceof AeadKey) {
            return ((AeadKey) key).getOutputPrefix();
        }
        if (key instanceof LegacyProtoKey) {
            return ((LegacyProtoKey) key).getOutputPrefix();
        }
        throw new GeneralSecurityException("Cannot get output prefix for key of class " + key.getClass().getName() + " with parameters " + key.getParameters());
    }

    private static class WrappedAead implements Aead {
        private final PrefixMap<AeadWithId> allAeads;
        private final MonitoringClient.Logger decLogger;
        private final MonitoringClient.Logger encLogger;
        private final AeadWithId primary;

        private WrappedAead(AeadWithId aeadWithId, PrefixMap<AeadWithId> prefixMap, MonitoringClient.Logger logger, MonitoringClient.Logger logger2) {
            this.primary = aeadWithId;
            this.allAeads = prefixMap;
            this.encLogger = logger;
            this.decLogger = logger2;
        }

        @Override // com.google.crypto.tink.Aead
        public byte[] encrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
            try {
                byte[] bArrEncrypt = this.primary.aead.encrypt(bArr, bArr2);
                this.encLogger.log(this.primary.id, bArr.length);
                return bArrEncrypt;
            } catch (GeneralSecurityException e) {
                this.encLogger.logFailure();
                throw e;
            }
        }

        @Override // com.google.crypto.tink.Aead
        public byte[] decrypt(byte[] bArr, byte[] bArr2) throws GeneralSecurityException {
            for (AeadWithId aeadWithId : this.allAeads.getAllWithMatchingPrefix(bArr)) {
                try {
                    byte[] bArrDecrypt = aeadWithId.aead.decrypt(bArr, bArr2);
                    this.decLogger.log(aeadWithId.id, bArr.length);
                    return bArrDecrypt;
                } catch (GeneralSecurityException unused) {
                }
            }
            this.decLogger.logFailure();
            throw new GeneralSecurityException("decryption failed");
        }
    }

    AeadWrapper() {
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Aead wrap(PrimitiveSet<Aead> primitiveSet) throws GeneralSecurityException {
        MonitoringClient.Logger logger;
        MonitoringClient.Logger loggerCreateLogger;
        PrefixMap.Builder builder = new PrefixMap.Builder();
        KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
        for (int i = 0; i < keysetHandle.size(); i++) {
            KeysetHandleInterface.Entry at = keysetHandle.getAt(i);
            builder.put(getOutputPrefix(at.getKey()), new AeadWithId(primitiveSet.getPrimitiveForEntry(at), at.getId()));
        }
        if (!primitiveSet.getAnnotations().isEmpty()) {
            MonitoringClient monitoringClient = MutableMonitoringRegistry.globalInstance().getMonitoringClient();
            MonitoringClient.Logger loggerCreateLogger2 = monitoringClient.createLogger(keysetHandle, primitiveSet.getAnnotations(), "aead", "encrypt");
            loggerCreateLogger = monitoringClient.createLogger(keysetHandle, primitiveSet.getAnnotations(), "aead", "decrypt");
            logger = loggerCreateLogger2;
        } else {
            logger = MonitoringUtil.DO_NOTHING_LOGGER;
            loggerCreateLogger = logger;
        }
        return new WrappedAead(new AeadWithId(primitiveSet.getPrimitiveForEntry(keysetHandle.getPrimary()), keysetHandle.getPrimary().getId()), builder.build(), logger, loggerCreateLogger);
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<Aead> getPrimitiveClass() {
        return Aead.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<Aead> getInputPrimitiveClass() {
        return Aead.class;
    }

    public static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveConstructor(LEGACY_FULL_AEAD_PRIMITIVE_CONSTRUCTOR);
    }

    public static void registerToInternalPrimitiveRegistry(PrimitiveRegistry.Builder builder) throws GeneralSecurityException {
        builder.registerPrimitiveWrapper(WRAPPER);
    }
}
