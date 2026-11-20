package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0278g9 {
    public final int a;
    public final C0407l9 b;
    public C0330i9 c;

    public C0278g9(C0407l9 c0407l9, int i) {
        this.a = i;
        this.b = c0407l9;
    }

    public final void a() {
        C0330i9 c0330i9;
        C0407l9 c0407l9 = this.b;
        c0407l9.getClass();
        try {
            byte[] bArr = c0407l9.c.get("event_hashes");
            if (bArr == null || bArr.length == 0) {
                C0355j9 c0355j9 = c0407l9.a;
                c0407l9.b.getClass();
                O9 o9 = new O9();
                c0355j9.getClass();
                c0330i9 = new C0330i9(o9.a, o9.b, o9.c, CollectionUtils.hashSetFromIntArray(o9.d));
            } else {
                C0355j9 c0355j10 = c0407l9.a;
                O9 state = c0407l9.b.toState(bArr);
                c0355j10.getClass();
                c0330i9 = new C0330i9(state.a, state.b, state.c, CollectionUtils.hashSetFromIntArray(state.d));
            }
        } catch (Throwable unused) {
            C0355j9 c0355j11 = c0407l9.a;
            c0407l9.b.getClass();
            O9 o10 = new O9();
            c0355j11.getClass();
            c0330i9 = new C0330i9(o10.a, o10.b, o10.c, CollectionUtils.hashSetFromIntArray(o10.d));
        }
        this.c = c0330i9;
        int i = c0330i9.c;
        int i2 = this.a;
        if (i != i2) {
            c0330i9.c = i2;
            c0330i9.d = 0;
            C0407l9 c0407l10 = this.b;
            IBinaryDataHelper iBinaryDataHelper = c0407l10.c;
            C0381k9 c0381k9 = c0407l10.b;
            c0407l10.a.getClass();
            iBinaryDataHelper.insert("event_hashes", c0381k9.toByteArray(C0355j9.a(c0330i9)));
        }
    }
}
