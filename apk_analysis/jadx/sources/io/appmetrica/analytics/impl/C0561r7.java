package io.appmetrica.analytics.impl;

import java.io.File;
import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.r7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0561r7 {
    public final InterfaceC0121a7 a;
    public final ArrayList b;

    public C0561r7(File file) {
        ArrayList arrayList = new ArrayList();
        this.b = arrayList;
        if (file != null) {
            this.a = new Le(file, new C0224e7());
            arrayList.add(new Le(file, new Fe()));
        } else {
            this.a = new C0147b7(new C0224e7());
        }
        arrayList.add(new C0147b7(new Fe()));
    }
}
