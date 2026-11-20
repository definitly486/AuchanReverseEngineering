package io.appmetrica.analytics.screenshot.internal.config;

import android.os.Parcel;
import android.os.Parcelable;
import io.appmetrica.analytics.screenshot.impl.D;
import io.appmetrica.analytics.screenshot.impl.g0;
import io.appmetrica.analytics.screenshot.impl.h0;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class ParcelableRemoteScreenshotConfig implements Parcelable {
    public static final CREATOR CREATOR = new CREATOR(null);
    private final boolean a;
    private final D b;

    public static final class CREATOR implements Parcelable.Creator<ParcelableRemoteScreenshotConfig> {
        public /* synthetic */ CREATOR(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private CREATOR() {
        }

        /* JADX WARN: Can't rename method to resolve collision */
        @Override // android.os.Parcelable.Creator
        public ParcelableRemoteScreenshotConfig createFromParcel(Parcel parcel) {
            return new ParcelableRemoteScreenshotConfig(parcel);
        }

        /* JADX WARN: Can't rename method to resolve collision */
        @Override // android.os.Parcelable.Creator
        public ParcelableRemoteScreenshotConfig[] newArray(int i) {
            return new ParcelableRemoteScreenshotConfig[i];
        }
    }

    public ParcelableRemoteScreenshotConfig(boolean z, D d) {
        this.a = z;
        this.b = d;
    }

    @Override // android.os.Parcelable
    public int describeContents() {
        return 0;
    }

    public final D getConfig$screenshot_release() {
        return this.b;
    }

    public final boolean getEnabled() {
        return this.a;
    }

    public String toString() {
        return "ParcelableRemoteScreenshotConfig(enabled=" + this.a + ", config=" + this.b + ')';
    }

    @Override // android.os.Parcelable
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeByte(this.a ? (byte) 1 : (byte) 0);
        parcel.writeParcelable(this.b, i);
    }

    public ParcelableRemoteScreenshotConfig() {
        this(new g0());
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public ParcelableRemoteScreenshotConfig(g0 g0Var) {
        boolean zB = g0Var.b();
        h0 h0VarA = g0Var.a();
        this(zB, h0VarA != null ? new D(h0VarA) : null);
    }

    public ParcelableRemoteScreenshotConfig(Parcel parcel) {
        this(parcel.readByte() != 0, (D) parcel.readParcelable(D.class.getClassLoader()));
    }
}
