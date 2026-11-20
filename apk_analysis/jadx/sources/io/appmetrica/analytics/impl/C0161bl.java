package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.bl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0161bl {
    public final C0264fl a;
    public final Map b;

    public C0161bl(Context context, C0274g5 c0274g5) {
        c0274g5.a();
        C0264fl c0264fl = new C0264fl(context, c0274g5);
        this.a = c0264fl;
        this.b = MapsKt.toMutableMap(c0264fl.a());
    }
}
