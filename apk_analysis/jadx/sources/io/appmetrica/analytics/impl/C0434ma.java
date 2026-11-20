package io.appmetrica.analytics.impl;

import com.google.mediapipe.framework.AssetCacheDbHelper;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ma, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0434ma {
    public final String a;
    public final int b;
    public final boolean c;

    public C0434ma(JSONObject jSONObject) {
        this.a = jSONObject.getString("name");
        this.c = jSONObject.getBoolean("required");
        this.b = jSONObject.optInt(AssetCacheDbHelper.AssetCacheEntry.COLUMN_NAME_VERSION, -1);
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj != null && C0434ma.class == obj.getClass()) {
            C0434ma c0434ma = (C0434ma) obj;
            if (this.b != c0434ma.b || this.c != c0434ma.c) {
                return false;
            }
            String str = this.a;
            String str2 = c0434ma.a;
            if (str != null) {
                return str.equals(str2);
            }
            if (str2 == null) {
                return true;
            }
        }
        return false;
    }

    public final int hashCode() {
        String str = this.a;
        return ((((str != null ? str.hashCode() : 0) * 31) + this.b) * 31) + (this.c ? 1 : 0);
    }

    public C0434ma(String str, int i, boolean z) {
        this.a = str;
        this.b = i;
        this.c = z;
    }
}
