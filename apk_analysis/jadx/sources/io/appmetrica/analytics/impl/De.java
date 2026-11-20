package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import java.lang.reflect.Field;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class De {
    public static final V9 a(De de, EnumC0227ea enumC0227ea, Object obj) {
        int i;
        de.getClass();
        V9 v9 = new V9();
        switch (enumC0227ea.ordinal()) {
            case 0:
                i = 0;
                break;
            case 1:
                i = 1;
                break;
            case 2:
                i = 2;
                break;
            case 3:
                i = 3;
                break;
            case 4:
                i = 4;
                break;
            case 5:
                i = 5;
                break;
            case 6:
                i = 6;
                break;
            default:
                throw new NoWhenBranchMatchedException();
        }
        v9.a = i;
        Ee.b.getClass();
        JSONObject jSONObject = new JSONObject();
        for (Field field : obj.getClass().getFields()) {
            try {
                jSONObject.put(field.getName(), field.get(obj));
            } catch (Throwable unused) {
            }
        }
        v9.b = jSONObject.toString().getBytes(Charsets.UTF_8);
        return v9;
    }
}
