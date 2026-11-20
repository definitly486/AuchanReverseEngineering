package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;
import io.appmetrica.analytics.coreutils.internal.encryption.AESEncrypter;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.dn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0215dn extends AbstractC0343in {
    @Override // io.appmetrica.analytics.impl.AbstractC0343in
    public final IBinaryDataHelper a(Context context) {
        return Ka.I.B().b(context);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0343in
    public final IBinaryDataHelper b(Context context) {
        IBinaryDataHelper iBinaryDataHelperA;
        Pk pkB = Ka.I.B();
        synchronized (pkB) {
            iBinaryDataHelperA = pkB.a(context);
        }
        return iBinaryDataHelperA;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0343in
    public final ProtobufStateStorage a(Context context, IBinaryDataHelper iBinaryDataHelper) {
        byte[] bArrA;
        byte[] bArrA2;
        P3 p3 = new P3();
        try {
            bArrA = AbstractC0332ib.a(context.getPackageName());
        } catch (Throwable unused) {
            bArrA = new byte[16];
        }
        try {
            bArrA2 = AbstractC0332ib.a(new StringBuilder(context.getPackageName()).reverse().toString());
        } catch (Throwable unused2) {
            bArrA2 = new byte[16];
        }
        return new C0311hg("clids_info", iBinaryDataHelper, new T8(p3, new AESEncrypter(AESEncrypter.DEFAULT_ALGORITHM, bArrA, bArrA2)), new K3());
    }
}
