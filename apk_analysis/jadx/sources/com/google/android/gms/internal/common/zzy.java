package com.google.android.gms.internal.common;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: compiled from: com.google.android.gms:play-services-basement@@18.7.1 */
/* JADX INFO: loaded from: classes.dex */
public final class zzy {
    private final zzp zza;
    private final boolean zzb;
    private final zzw zzc;

    private zzy(zzw zzwVar, boolean z, zzp zzpVar, int i) {
        this.zzc = zzwVar;
        this.zzb = z;
        this.zza = zzpVar;
    }

    public static zzy zza(zzp zzpVar) {
        return new zzy(new zzw(zzpVar), false, zzo.zza, Integer.MAX_VALUE);
    }

    public final zzy zzb() {
        return new zzy(this.zzc, true, this.zza, Integer.MAX_VALUE);
    }

    public final Iterable zzc(CharSequence charSequence) {
        return new zzv(this, charSequence);
    }

    final /* synthetic */ Iterator zze(CharSequence charSequence) {
        return this.zzc.zza(this, charSequence);
    }

    final /* synthetic */ zzp zzf() {
        return this.zza;
    }

    final /* synthetic */ boolean zzg() {
        return this.zzb;
    }

    public final List zzd(CharSequence charSequence) {
        charSequence.getClass();
        Iterator itZza = this.zzc.zza(this, charSequence);
        ArrayList arrayList = new ArrayList();
        while (itZza.hasNext()) {
            arrayList.add((String) itZza.next());
        }
        return Collections.unmodifiableList(arrayList);
    }
}
