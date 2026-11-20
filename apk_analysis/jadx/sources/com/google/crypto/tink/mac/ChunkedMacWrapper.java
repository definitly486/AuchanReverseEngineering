package com.google.crypto.tink.mac;

import com.google.crypto.tink.Key;
import com.google.crypto.tink.internal.KeysetHandleInterface;
import com.google.crypto.tink.internal.LegacyProtoKey;
import com.google.crypto.tink.internal.MutablePrimitiveRegistry;
import com.google.crypto.tink.internal.PrefixMap;
import com.google.crypto.tink.internal.PrimitiveRegistry;
import com.google.crypto.tink.internal.PrimitiveSet;
import com.google.crypto.tink.internal.PrimitiveWrapper;
import com.google.crypto.tink.util.Bytes;
import com.google.errorprone.annotations.Immutable;
import java.nio.ByteBuffer;
import java.security.GeneralSecurityException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes2.dex */
public class ChunkedMacWrapper implements PrimitiveWrapper<ChunkedMac, ChunkedMac> {
    private static final ChunkedMacWrapper WRAPPER = new ChunkedMacWrapper();

    private static Bytes getOutputPrefix(Key key) throws GeneralSecurityException {
        if (key instanceof MacKey) {
            return ((MacKey) key).getOutputPrefix();
        }
        if (key instanceof LegacyProtoKey) {
            return ((LegacyProtoKey) key).getOutputPrefix();
        }
        throw new GeneralSecurityException("Cannot get output prefix for key of class " + key.getClass().getName() + " with parameters " + key.getParameters());
    }

    private static class WrappedChunkedMacVerification implements ChunkedMacVerification {
        private final List<ChunkedMacVerification> verifications;

        private WrappedChunkedMacVerification(List<ChunkedMacVerification> list) {
            this.verifications = list;
        }

        @Override // com.google.crypto.tink.mac.ChunkedMacVerification
        public void update(ByteBuffer byteBuffer) {
            ByteBuffer byteBufferDuplicate = byteBuffer.duplicate();
            byteBufferDuplicate.mark();
            for (ChunkedMacVerification chunkedMacVerification : this.verifications) {
                byteBufferDuplicate.reset();
                chunkedMacVerification.update(byteBufferDuplicate);
            }
            byteBuffer.position(byteBuffer.limit());
        }

        @Override // com.google.crypto.tink.mac.ChunkedMacVerification
        public void verifyMac() throws GeneralSecurityException {
            GeneralSecurityException generalSecurityException = new GeneralSecurityException("MAC verification failed for all suitable keys in keyset");
            Iterator<ChunkedMacVerification> it = this.verifications.iterator();
            while (it.hasNext()) {
                try {
                    it.next().verifyMac();
                    return;
                } catch (GeneralSecurityException e) {
                    generalSecurityException.addSuppressed(e);
                }
            }
            throw generalSecurityException;
        }
    }

    @Immutable
    private static class WrappedChunkedMac implements ChunkedMac {
        private final PrefixMap<ChunkedMac> allChunkedMacs;
        private final ChunkedMac primaryChunkedMac;

        private WrappedChunkedMac(PrefixMap<ChunkedMac> prefixMap, ChunkedMac chunkedMac) {
            this.allChunkedMacs = prefixMap;
            this.primaryChunkedMac = chunkedMac;
        }

        @Override // com.google.crypto.tink.mac.ChunkedMac
        public ChunkedMacComputation createComputation() {
            return this.primaryChunkedMac.createComputation();
        }

        @Override // com.google.crypto.tink.mac.ChunkedMac
        public ChunkedMacVerification createVerification(byte[] bArr) {
            ArrayList arrayList = new ArrayList();
            Iterator<ChunkedMac> it = this.allChunkedMacs.getAllWithMatchingPrefix(bArr).iterator();
            while (it.hasNext()) {
                arrayList.add(it.next().createVerification(bArr));
            }
            return new WrappedChunkedMacVerification(arrayList);
        }
    }

    private ChunkedMacWrapper() {
    }

    /* JADX WARN: Can't rename method to resolve collision */
    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public ChunkedMac wrap(PrimitiveSet<ChunkedMac> primitiveSet) throws GeneralSecurityException {
        if (primitiveSet == null) {
            throw new GeneralSecurityException("primitive set must be non-null");
        }
        KeysetHandleInterface keysetHandle = primitiveSet.getKeysetHandle();
        KeysetHandleInterface.Entry primary = keysetHandle.getPrimary();
        if (primary == null) {
            throw new GeneralSecurityException("no primary in primitive set");
        }
        PrefixMap.Builder builder = new PrefixMap.Builder();
        for (int i = 0; i < keysetHandle.size(); i++) {
            KeysetHandleInterface.Entry at = keysetHandle.getAt(i);
            builder.put(getOutputPrefix(at.getKey()), primitiveSet.getPrimitiveForEntry(at));
        }
        return new WrappedChunkedMac(builder.build(), primitiveSet.getPrimitiveForEntry(primary));
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<ChunkedMac> getPrimitiveClass() {
        return ChunkedMac.class;
    }

    @Override // com.google.crypto.tink.internal.PrimitiveWrapper
    public Class<ChunkedMac> getInputPrimitiveClass() {
        return ChunkedMac.class;
    }

    static void register() {
        MutablePrimitiveRegistry.globalInstance().registerPrimitiveWrapper(WRAPPER);
    }

    public static void registerToInternalPrimitiveRegistry(PrimitiveRegistry.Builder builder) throws GeneralSecurityException {
        builder.registerPrimitiveWrapper(WRAPPER);
    }
}
