package io.appmetrica.analytics.screenshot.impl;

import android.os.Parcel;
import android.os.Parcelable;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.z, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0811z implements Parcelable {
    public static final C0810y CREATOR = new C0810y();
    public final boolean a;

    public C0811z(boolean z) {
        this.a = z;
    }

    public final boolean a() {
        return this.a;
    }

    @Override // android.os.Parcelable
    public final int describeContents() {
        return 0;
    }

    public final String toString() {
        return "ParcelableApiCaptorConfig(enabled=" + this.a + ')';
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        parcel.writeByte(this.a ? (byte) 1 : (byte) 0);
    }

    public C0811z(e0 e0Var) {
        this(e0Var.a());
    }
}
