package io.appmetrica.analytics.impl;

import android.os.Parcel;
import android.os.Parcelable;
import io.appmetrica.analytics.coreapi.internal.identifiers.IdentifierStatus;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qa, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0539qa implements Parcelable {
    public static final C0512pa CREATOR = new C0512pa();
    public final Boolean a;
    public final IdentifierStatus b;
    public final String c;

    public C0539qa(Boolean bool, IdentifierStatus identifierStatus, String str) {
        this.a = bool;
        this.b = identifierStatus;
        this.c = str;
    }

    @Override // android.os.Parcelable
    public final int describeContents() {
        return 0;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof C0539qa)) {
            return false;
        }
        C0539qa c0539qa = (C0539qa) obj;
        return Intrinsics.areEqual(this.a, c0539qa.a) && this.b == c0539qa.b && Intrinsics.areEqual(this.c, c0539qa.c);
    }

    public final int hashCode() {
        Boolean bool = this.a;
        int iHashCode = (this.b.hashCode() + ((bool == null ? 0 : bool.hashCode()) * 31)) * 31;
        String str = this.c;
        return iHashCode + (str != null ? str.hashCode() : 0);
    }

    public final String toString() {
        return "FeaturesInternal(sslPinning=" + this.a + ", status=" + this.b + ", errorExplanation=" + this.c + ')';
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        parcel.writeValue(this.a);
        parcel.writeString(this.b.getValue());
        parcel.writeString(this.c);
    }

    public C0539qa() {
        this(null, IdentifierStatus.UNKNOWN, null);
    }
}
