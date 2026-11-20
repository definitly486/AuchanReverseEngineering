package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class T2 implements Ko {
    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(Object obj) {
        C0734xo[] c0734xoArr = ((Ao) obj).a;
        return (c0734xoArr == null || c0734xoArr.length == 0) ? new Io(this, false, "attributes list is empty") : new Io(this, true, "");
    }
}
