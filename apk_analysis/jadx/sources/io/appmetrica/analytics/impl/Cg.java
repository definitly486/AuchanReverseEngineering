package io.appmetrica.analytics.impl;

import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class Cg implements Eg {
    public final String a;
    public final Throwable b;

    public Cg(String str, Throwable th) {
        this.a = str;
        this.b = th;
    }

    @Override // io.appmetrica.analytics.impl.Eg
    public final C0674vg a() {
        return null;
    }

    public final String b() {
        return this.a;
    }

    public final Throwable c() {
        return this.b;
    }

    public final String toString() {
        return "Failure(message='" + this.a + "', throwable=" + this.b + ')';
    }

    public /* synthetic */ Cg(String str, Throwable th, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(str, (i & 2) != 0 ? null : th);
    }
}
