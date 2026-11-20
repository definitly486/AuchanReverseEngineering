package com.google.crypto.tink.streamingaead;

import com.google.crypto.tink.internal.TinkBugException;

/* JADX INFO: loaded from: classes2.dex */
public final class PredefinedStreamingAeadParameters {
    public static final AesCtrHmacStreamingParameters AES128_CTR_HMAC_SHA256_4KB = (AesCtrHmacStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda0
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return PredefinedStreamingAeadParameters.$r8$lambda$fXFnkFiYyBSGfzWmnlvozCnrFO4();
        }
    });
    public static final AesCtrHmacStreamingParameters AES128_CTR_HMAC_SHA256_1MB = (AesCtrHmacStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda1
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return PredefinedStreamingAeadParameters.$r8$lambda$nJ4rLQRQ2ttBCQzLXXnvTx5ttPg();
        }
    });
    public static final AesCtrHmacStreamingParameters AES256_CTR_HMAC_SHA256_4KB = (AesCtrHmacStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda2
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return PredefinedStreamingAeadParameters.m409$r8$lambda$uNgSZ4NO1X78lijL4EW39ekGs();
        }
    });
    public static final AesCtrHmacStreamingParameters AES256_CTR_HMAC_SHA256_1MB = (AesCtrHmacStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda3
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return PredefinedStreamingAeadParameters.$r8$lambda$sGfquEqnaSSdrDXax1WkCrdYI58();
        }
    });
    public static final AesGcmHkdfStreamingParameters AES128_GCM_HKDF_4KB = (AesGcmHkdfStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda4
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return AesGcmHkdfStreamingParameters.builder().setKeySizeBytes(16).setDerivedAesGcmKeySizeBytes(16).setHkdfHashType(AesGcmHkdfStreamingParameters.HashType.SHA256).setCiphertextSegmentSizeBytes(4096).build();
        }
    });
    public static final AesGcmHkdfStreamingParameters AES128_GCM_HKDF_1MB = (AesGcmHkdfStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda5
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return AesGcmHkdfStreamingParameters.builder().setKeySizeBytes(16).setDerivedAesGcmKeySizeBytes(16).setHkdfHashType(AesGcmHkdfStreamingParameters.HashType.SHA256).setCiphertextSegmentSizeBytes(1048576).build();
        }
    });
    public static final AesGcmHkdfStreamingParameters AES256_GCM_HKDF_4KB = (AesGcmHkdfStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda6
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return AesGcmHkdfStreamingParameters.builder().setKeySizeBytes(32).setDerivedAesGcmKeySizeBytes(32).setHkdfHashType(AesGcmHkdfStreamingParameters.HashType.SHA256).setCiphertextSegmentSizeBytes(4096).build();
        }
    });
    public static final AesGcmHkdfStreamingParameters AES256_GCM_HKDF_1MB = (AesGcmHkdfStreamingParameters) TinkBugException.exceptionIsBug(new TinkBugException.ThrowingSupplier() { // from class: com.google.crypto.tink.streamingaead.PredefinedStreamingAeadParameters$$ExternalSyntheticLambda7
        @Override // com.google.crypto.tink.internal.TinkBugException.ThrowingSupplier
        public final Object get() {
            return AesGcmHkdfStreamingParameters.builder().setKeySizeBytes(32).setDerivedAesGcmKeySizeBytes(32).setHkdfHashType(AesGcmHkdfStreamingParameters.HashType.SHA256).setCiphertextSegmentSizeBytes(1048576).build();
        }
    });

    public static /* synthetic */ AesCtrHmacStreamingParameters $r8$lambda$fXFnkFiYyBSGfzWmnlvozCnrFO4() {
        AesCtrHmacStreamingParameters.Builder derivedKeySizeBytes = AesCtrHmacStreamingParameters.builder().setKeySizeBytes(16).setDerivedKeySizeBytes(16);
        AesCtrHmacStreamingParameters.HashType hashType = AesCtrHmacStreamingParameters.HashType.SHA256;
        return derivedKeySizeBytes.setHkdfHashType(hashType).setHmacHashType(hashType).setHmacTagSizeBytes(32).setCiphertextSegmentSizeBytes(4096).build();
    }

    public static /* synthetic */ AesCtrHmacStreamingParameters $r8$lambda$nJ4rLQRQ2ttBCQzLXXnvTx5ttPg() {
        AesCtrHmacStreamingParameters.Builder derivedKeySizeBytes = AesCtrHmacStreamingParameters.builder().setKeySizeBytes(16).setDerivedKeySizeBytes(16);
        AesCtrHmacStreamingParameters.HashType hashType = AesCtrHmacStreamingParameters.HashType.SHA256;
        return derivedKeySizeBytes.setHkdfHashType(hashType).setHmacHashType(hashType).setHmacTagSizeBytes(32).setCiphertextSegmentSizeBytes(1048576).build();
    }

    /* JADX INFO: renamed from: $r8$lambda$uNgSZ4N--O1X78lijL4EW39ekGs, reason: not valid java name */
    public static /* synthetic */ AesCtrHmacStreamingParameters m409$r8$lambda$uNgSZ4NO1X78lijL4EW39ekGs() {
        AesCtrHmacStreamingParameters.Builder derivedKeySizeBytes = AesCtrHmacStreamingParameters.builder().setKeySizeBytes(32).setDerivedKeySizeBytes(32);
        AesCtrHmacStreamingParameters.HashType hashType = AesCtrHmacStreamingParameters.HashType.SHA256;
        return derivedKeySizeBytes.setHkdfHashType(hashType).setHmacHashType(hashType).setHmacTagSizeBytes(32).setCiphertextSegmentSizeBytes(4096).build();
    }

    public static /* synthetic */ AesCtrHmacStreamingParameters $r8$lambda$sGfquEqnaSSdrDXax1WkCrdYI58() {
        AesCtrHmacStreamingParameters.Builder derivedKeySizeBytes = AesCtrHmacStreamingParameters.builder().setKeySizeBytes(32).setDerivedKeySizeBytes(32);
        AesCtrHmacStreamingParameters.HashType hashType = AesCtrHmacStreamingParameters.HashType.SHA256;
        return derivedKeySizeBytes.setHkdfHashType(hashType).setHmacHashType(hashType).setHmacTagSizeBytes(32).setCiphertextSegmentSizeBytes(1048576).build();
    }

    private PredefinedStreamingAeadParameters() {
    }
}
