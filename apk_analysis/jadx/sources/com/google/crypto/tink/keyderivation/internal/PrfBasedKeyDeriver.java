package com.google.crypto.tink.keyderivation.internal;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.InsecureSecretKeyAccess;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.internal.MutableKeyDerivationRegistry;
import com.google.crypto.tink.internal.MutablePrimitiveRegistry;
import com.google.crypto.tink.keyderivation.PrfBasedKeyDerivationKey;
import com.google.crypto.tink.subtle.prf.StreamingPrf;
import com.google.errorprone.annotations.Immutable;

/* JADX INFO: loaded from: classes2.dex */
@Immutable
public final class PrfBasedKeyDeriver implements KeyDeriver {
    final PrfBasedKeyDerivationKey key;
    final StreamingPrf prf;

    private PrfBasedKeyDeriver(StreamingPrf streamingPrf, PrfBasedKeyDerivationKey prfBasedKeyDerivationKey) {
        this.prf = streamingPrf;
        this.key = prfBasedKeyDerivationKey;
    }

    @AccessesPartialKey
    public static KeyDeriver create(PrfBasedKeyDerivationKey prfBasedKeyDerivationKey) {
        PrfBasedKeyDeriver prfBasedKeyDeriver = new PrfBasedKeyDeriver((StreamingPrf) MutablePrimitiveRegistry.globalInstance().getPrimitive(prfBasedKeyDerivationKey.getPrfKey(), StreamingPrf.class), prfBasedKeyDerivationKey);
        prfBasedKeyDeriver.deriveKey(new byte[]{1});
        return prfBasedKeyDeriver;
    }

    @Override // com.google.crypto.tink.keyderivation.internal.KeyDeriver
    @AccessesPartialKey
    public Key deriveKey(byte[] bArr) {
        return MutableKeyDerivationRegistry.globalInstance().createKeyFromRandomness(this.key.getParameters().getDerivedKeyParameters(), this.prf.computePrf(bArr), this.key.getIdRequirementOrNull(), InsecureSecretKeyAccess.get());
    }
}
