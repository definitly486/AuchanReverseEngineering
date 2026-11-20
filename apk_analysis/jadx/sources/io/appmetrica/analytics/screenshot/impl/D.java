package io.appmetrica.analytics.screenshot.impl;

import android.os.Parcel;
import android.os.Parcelable;

/* JADX INFO: loaded from: classes3.dex */
public final class D implements Parcelable {
    public static final C CREATOR = new C();
    public final C0811z a;
    public final F b;
    public final B c;

    public D(C0811z c0811z, F f, B b) {
        this.a = c0811z;
        this.b = f;
        this.c = b;
    }

    public final C0811z a() {
        return this.a;
    }

    public final B b() {
        return this.c;
    }

    public final F c() {
        return this.b;
    }

    @Override // android.os.Parcelable
    public final int describeContents() {
        return 0;
    }

    public final String toString() {
        return "ParcelableScreenshotConfig(apiCaptorConfig=" + this.a + ", serviceCaptorConfig=" + this.b + ", contentObserverCaptorConfig=" + this.c + ')';
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        parcel.writeParcelable(this.a, i);
        parcel.writeParcelable(this.b, i);
        parcel.writeParcelable(this.c, i);
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public D(h0 h0Var) {
        e0 e0VarA = h0Var.a();
        C0811z c0811z = e0VarA != null ? new C0811z(e0VarA) : null;
        i0 i0VarC = h0Var.c();
        F f = i0VarC != null ? new F(i0VarC) : null;
        f0 f0VarB = h0Var.b();
        this(c0811z, f, f0VarB != null ? new B(f0VarB) : null);
    }
}
