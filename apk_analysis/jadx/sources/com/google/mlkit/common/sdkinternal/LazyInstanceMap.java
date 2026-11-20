package com.google.mlkit.common.sdkinternal;

import com.google.android.gms.common.annotation.KeepForSdk;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: compiled from: com.google.mlkit:common@@18.11.0 */
/* JADX INFO: loaded from: classes3.dex */
@KeepForSdk
public abstract class LazyInstanceMap<K, V> {
    private final Map zza = new HashMap();

    @KeepForSdk
    protected abstract V create(K k);

    @KeepForSdk
    public V get(K k) {
        synchronized (this.zza) {
            try {
                if (this.zza.containsKey(k)) {
                    return (V) this.zza.get(k);
                }
                V vCreate = create(k);
                this.zza.put(k, vCreate);
                return vCreate;
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
