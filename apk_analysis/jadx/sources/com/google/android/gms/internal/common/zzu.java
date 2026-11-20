package com.google.android.gms.internal.common;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
final class zzu extends zzx {
    final /* synthetic */ zzp zza;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    zzu(zzy zzyVar, CharSequence charSequence, zzp zzpVar) {
        super(zzyVar, charSequence);
        this.zza = zzpVar;
    }

    @Override // com.google.android.gms.internal.common.zzx
    final int zzc(int i) {
        CharSequence charSequence = ((zzx) this).zzb;
        int length = charSequence.length();
        zzt.zzc(i, length, "index");
        while (i < length) {
            if (this.zza.zza(charSequence.charAt(i))) {
                return i;
            }
            i++;
        }
        return -1;
    }

    @Override // com.google.android.gms.internal.common.zzx
    final int zzd(int i) {
        return i + 1;
    }
}
