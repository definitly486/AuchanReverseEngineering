package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.w5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0689w5 implements To {
    public final List a;

    public C0689w5(List<? extends Pair> list) {
        this.a = list;
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void a(String str) {
        Iterator it = this.a.iterator();
        while (it.hasNext()) {
            ((To) ((Pair) it.next()).getSecond()).a(str);
        }
    }

    @Override // io.appmetrica.analytics.impl.To
    public final String b() {
        Iterator it = this.a.iterator();
        while (it.hasNext()) {
            String strB = ((To) ((Pair) it.next()).getSecond()).b();
            if (strB != null && strB.length() > 0) {
                return strB;
            }
        }
        return null;
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void flushAsync() {
        Iterator it = this.a.iterator();
        while (it.hasNext()) {
            ((To) ((Pair) it.next()).getSecond()).flushAsync();
        }
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void a() {
        Iterator it = this.a.iterator();
        while (it.hasNext()) {
            ((To) ((Pair) it.next()).getSecond()).a();
        }
    }
}
