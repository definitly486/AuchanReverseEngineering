package io.appmetrica.analytics.impl;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0671vd {
    public final String a;
    public final boolean b;

    public C0671vd(String str, boolean z) {
        this.a = str;
        this.b = z;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof C0671vd)) {
            return false;
        }
        C0671vd c0671vd = (C0671vd) obj;
        return Intrinsics.areEqual(this.a, c0671vd.a) && this.b == c0671vd.b;
    }

    public final int hashCode() {
        return Boolean.hashCode(this.b) + (this.a.hashCode() * 31);
    }

    public final String toString() {
        return "ModuleStatus(moduleName=" + this.a + ", loaded=" + this.b + ')';
    }
}
