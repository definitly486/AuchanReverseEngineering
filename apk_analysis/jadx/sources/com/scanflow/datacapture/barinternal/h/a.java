package com.scanflow.datacapture.barinternal.h;

import android.content.SharedPreferences;
import androidx.lifecycle.MutableLiveData;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a extends MutableLiveData {
    public final String a;
    public final Object b;
    public final SharedPreferences c;
    public final SharedPreferences.OnSharedPreferenceChangeListener d;

    public a(String key, Object obj, SharedPreferences sharedPrefs) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(sharedPrefs, "sharedPrefs");
        this.a = key;
        this.b = obj;
        this.c = sharedPrefs;
        this.d = new SharedPreferences.OnSharedPreferenceChangeListener() { // from class: com.scanflow.datacapture.barinternal.h.a$$ExternalSyntheticLambda0
            @Override // android.content.SharedPreferences.OnSharedPreferenceChangeListener
            public final void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String str) {
                a.a(this.f$0, sharedPreferences, str);
            }
        };
    }

    public final Object a() {
        Object obj = this.b;
        if (obj instanceof Boolean) {
            return Boolean.valueOf(this.c.getBoolean(this.a, ((Boolean) obj).booleanValue()));
        }
        if (obj instanceof Integer) {
            return Integer.valueOf(this.c.getInt(this.a, ((Number) obj).intValue()));
        }
        if (obj instanceof Long) {
            return Long.valueOf(this.c.getLong(this.a, ((Number) obj).longValue()));
        }
        if (obj instanceof String) {
            String string = this.c.getString(this.a, (String) obj);
            return string == null ? (String) this.b : string;
        }
        if (obj instanceof Float) {
            return Float.valueOf(this.c.getFloat(this.a, ((Number) obj).floatValue()));
        }
        if (!(obj instanceof Set)) {
            throw new IllegalArgumentException("Unsupported SharedPreferences type. Currently supported types: [Boolean, Int, Long, Float, String, Set<String>]");
        }
        SharedPreferences sharedPreferences = this.c;
        String str = this.a;
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.collections.Set<kotlin.String>");
        return sharedPreferences.getStringSet(str, (Set) obj);
    }

    @Override // androidx.lifecycle.LiveData
    public final void onActive() {
        super.onActive();
        setValue(a());
        this.c.registerOnSharedPreferenceChangeListener(this.d);
    }

    @Override // androidx.lifecycle.LiveData
    public final void onInactive() {
        this.c.unregisterOnSharedPreferenceChangeListener(this.d);
        super.onInactive();
    }

    public static final void a(a aVar, SharedPreferences sharedPreferences, String str) {
        if (Intrinsics.areEqual(str, aVar.a)) {
            aVar.setValue(aVar.a());
        }
    }
}
