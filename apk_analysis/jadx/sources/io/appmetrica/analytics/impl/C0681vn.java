package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0681vn implements InterfaceC0631u {
    public final C0683w b;
    public final C0657v a = new C0657v();
    public final Lazy c = LazyKt.lazy(new C0655un(this));

    public C0681vn(Context context) {
        this.b = new C0683w(context);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0631u
    public final Map<String, String> a(Map<String, String> map) {
        map.putAll((Map) this.c.getValue());
        return map;
    }
}
