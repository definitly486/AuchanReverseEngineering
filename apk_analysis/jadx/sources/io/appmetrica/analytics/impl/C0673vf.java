package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0673vf implements InterfaceC0604so {
    public final boolean a;

    public C0673vf(C0725xf c0725xf) {
        boolean z;
        List<C0699wf> list = c0725xf.b;
        if ((list instanceof Collection) && list.isEmpty()) {
            z = true;
        } else {
            Iterator<T> it = list.iterator();
            while (it.hasNext()) {
                if (((C0699wf) it.next()).c == EnumC0406l8.d) {
                    z = false;
                }
            }
            z = true;
        }
        this.a = z;
    }

    @Override // kotlin.jvm.functions.Function2
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<C0699wf> invoke(List<? extends C0699wf> list, Kf kf) {
        C0699wf c0699wf = new C0699wf(kf.a, kf.b, kf.e);
        if (!(list instanceof Collection) || !list.isEmpty()) {
            Iterator<T> it = list.iterator();
            while (it.hasNext()) {
                if (((C0699wf) it.next()).c == kf.e) {
                    if (c0699wf.c == EnumC0406l8.d && this.a) {
                        return CollectionsKt.plus(list, c0699wf);
                    }
                    return null;
                }
            }
        }
        return CollectionsKt.plus(list, c0699wf);
    }
}
