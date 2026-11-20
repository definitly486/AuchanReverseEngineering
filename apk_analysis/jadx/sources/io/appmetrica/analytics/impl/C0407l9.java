package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.l9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0407l9 {
    public final C0355j9 a;
    public final C0381k9 b;
    public final IBinaryDataHelper c;

    public C0407l9(Context context, C0274g5 c0274g5) {
        this(new C0381k9(), new C0355j9(), Ka.k().B().a(context, c0274g5));
    }

    public C0407l9(C0381k9 c0381k9, C0355j9 c0355j9, IBinaryDataHelper iBinaryDataHelper) {
        this.b = c0381k9;
        this.a = c0355j9;
        this.c = iBinaryDataHelper;
    }
}
