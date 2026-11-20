package io.appmetrica.analytics.idsync.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class F implements Converter {
    public final String a = "request_state";
    public final String b = "type";
    public final String c = "last_attempt";
    public final String d = "prev_attempt_result";

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final String fromModel(List<E> list) throws JSONException {
        Collection collectionEmptyList;
        JSONObject jSONObject;
        JSONObject jSONObject2 = new JSONObject();
        String str = this.a;
        if (list != null) {
            collectionEmptyList = new ArrayList(CollectionsKt.collectionSizeOrDefault(list, 10));
            for (E e : list) {
                try {
                    jSONObject = new JSONObject();
                    jSONObject.put(this.b, e.a);
                    jSONObject.put(this.c, e.b);
                    jSONObject.put(this.d, e.c.a);
                } catch (Throwable unused) {
                    jSONObject = new JSONObject();
                }
                collectionEmptyList.add(jSONObject);
            }
        } else {
            collectionEmptyList = CollectionsKt.emptyList();
        }
        jSONObject2.put(str, new JSONArray(collectionEmptyList));
        return jSONObject2.toString();
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final List<E> toModel(String str) {
        JSONArray jSONArrayOptJSONArray;
        E eA;
        try {
            ArrayList arrayList = new ArrayList();
            if (str != null && (jSONArrayOptJSONArray = new JSONObject(str).optJSONArray(this.a)) != null) {
                int length = jSONArrayOptJSONArray.length();
                for (int i = 0; i < length; i++) {
                    JSONObject jSONObjectOptJSONObject = jSONArrayOptJSONArray.optJSONObject(i);
                    if (jSONObjectOptJSONObject != null && (eA = a(jSONObjectOptJSONObject)) != null) {
                        arrayList.add(eA);
                    }
                }
            }
            return arrayList;
        } catch (Throwable unused) {
            return CollectionsKt.emptyList();
        }
    }

    public final E a(JSONObject jSONObject) {
        A a;
        try {
            String string = jSONObject.getString(this.b);
            long j = jSONObject.getLong(this.c);
            z zVar = A.b;
            String string2 = jSONObject.getString(this.d);
            zVar.getClass();
            A[] aArrValues = A.values();
            int length = aArrValues.length;
            int i = 0;
            while (true) {
                if (i >= length) {
                    a = null;
                    break;
                }
                a = aArrValues[i];
                if (Intrinsics.areEqual(a.a, string2)) {
                    break;
                }
                i++;
            }
            if (a == null) {
                a = A.NONE;
            }
            return new E(string, j, a);
        } catch (Throwable unused) {
            return null;
        }
    }
}
