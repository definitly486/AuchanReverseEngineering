package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Nd {
    public final List a;
    public final long b;

    public Nd(List list, long j) {
        this.a = list;
        this.b = j;
    }

    public final String a() {
        JSONObject jSONObject;
        try {
            JSONObject jSONObject2 = new JSONObject();
            List<C0671vd> list = this.a;
            ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(list, 10));
            for (C0671vd c0671vd : list) {
                c0671vd.getClass();
                try {
                    jSONObject = new JSONObject();
                    jSONObject.put("moduleName", c0671vd.a);
                    jSONObject.put("loaded", c0671vd.b);
                } catch (Throwable unused) {
                    jSONObject = new JSONObject();
                }
                arrayList.add(jSONObject);
            }
            jSONObject2.put("modulesStatus", new JSONArray((Collection) arrayList));
            jSONObject2.put("lastSendTime", this.b);
            return jSONObject2.toString();
        } catch (Throwable unused2) {
            return "";
        }
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Nd)) {
            return false;
        }
        Nd nd = (Nd) obj;
        return Intrinsics.areEqual(this.a, nd.a) && this.b == nd.b;
    }

    public final int hashCode() {
        return Long.hashCode(this.b) + (this.a.hashCode() * 31);
    }

    public final String toString() {
        return "ModulesStatus(modulesStatus=" + this.a + ", lastSendTime=" + this.b + ')';
    }
}
