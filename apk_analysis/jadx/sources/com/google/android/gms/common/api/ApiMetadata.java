package com.google.android.gms.common.api;

import android.os.Parcel;
import android.os.Parcelable;
import com.google.android.gms.common.annotation.KeepForSdk;
import com.google.android.gms.common.internal.Objects;
import com.google.android.gms.common.internal.safeparcel.AbstractSafeParcelable;
import com.google.android.gms.common.internal.safeparcel.SafeParcelWriter;
import com.google.android.gms.common.internal.safeparcel.SafeParcelable;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
@KeepForSdk
@SafeParcelable.Class(creator = "ApiMetadataCreator")
public final class ApiMetadata extends AbstractSafeParcelable {
    public static final ApiMetadata zza;

    @SafeParcelable.Field(getter = "getComplianceOptions", id = 1)
    private final ComplianceOptions zzc;
    private boolean zzd;
    public static final Parcelable.Creator<ApiMetadata> CREATOR = zza.zza();
    private static final ApiMetadata zzb = newBuilder().build();

    /* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
    @KeepForSdk
    public static final class Builder {
        private ComplianceOptions zza;
        private boolean zzb;

        @KeepForSdk
        public ApiMetadata build() {
            ApiMetadata apiMetadata = new ApiMetadata(this.zza);
            apiMetadata.zza(this.zzb);
            return apiMetadata;
        }

        @KeepForSdk
        public Builder setComplianceOptions(ComplianceOptions complianceOptions) {
            this.zza = complianceOptions;
            return this;
        }

        final /* synthetic */ Builder zza(boolean z) {
            this.zzb = true;
            return this;
        }
    }

    static {
        Builder builderNewBuilder = newBuilder();
        builderNewBuilder.zza(true);
        zza = builderNewBuilder.build();
    }

    @SafeParcelable.Constructor
    ApiMetadata(@SafeParcelable.Param(id = 1) ComplianceOptions complianceOptions) {
        this.zzc = complianceOptions;
    }

    @KeepForSdk
    public static final ApiMetadata fromComplianceOptions(ComplianceOptions complianceOptions) {
        Builder builderNewBuilder = newBuilder();
        builderNewBuilder.setComplianceOptions(complianceOptions);
        return builderNewBuilder.build();
    }

    @KeepForSdk
    public static final ApiMetadata getEmptyInstance() {
        return zzb;
    }

    @KeepForSdk
    public static Builder newBuilder() {
        return new Builder();
    }

    public final boolean equals(Object obj) {
        if (!(obj instanceof ApiMetadata)) {
            return false;
        }
        ApiMetadata apiMetadata = (ApiMetadata) obj;
        return Objects.equal(this.zzc, apiMetadata.zzc) && this.zzd == apiMetadata.zzd;
    }

    public final int hashCode() {
        return Objects.hashCode(this.zzc, Boolean.valueOf(this.zzd));
    }

    public final String toString() {
        String strValueOf = String.valueOf(this.zzc);
        StringBuilder sb = new StringBuilder(strValueOf.length() + 31);
        sb.append("ApiMetadata(complianceOptions=");
        sb.append(strValueOf);
        sb.append(")");
        return sb.toString();
    }

    @Override // android.os.Parcelable
    public final void writeToParcel(Parcel parcel, int i) {
        if (this.zzd) {
            parcel.setDataPosition(parcel.dataPosition() - 4);
            parcel.setDataSize(parcel.dataSize() - 4);
        } else {
            parcel.writeInt(-204102970);
            int iBeginObjectHeader = SafeParcelWriter.beginObjectHeader(parcel);
            SafeParcelWriter.writeParcelable(parcel, 1, this.zzc, i, false);
            SafeParcelWriter.finishObjectHeader(parcel, iBeginObjectHeader);
        }
    }

    final /* synthetic */ void zza(boolean z) {
        this.zzd = z;
    }
}
