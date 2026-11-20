package io.appmetrica.analytics.impl;

import android.app.Activity;
import java.util.WeakHashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0528q {
    public final WeakHashMap a = new WeakHashMap();

    public final boolean a(Activity activity, EnumC0501p enumC0501p) {
        if (activity != null && this.a.get(activity) == enumC0501p) {
            return false;
        }
        if (activity == null) {
            return true;
        }
        this.a.put(activity, enumC0501p);
        return true;
    }
}
