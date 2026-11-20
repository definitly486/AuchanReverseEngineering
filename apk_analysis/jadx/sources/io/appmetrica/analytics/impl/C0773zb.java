package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.zb, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0773zb {
    public static final V9 a(C0773zb c0773zb, EnumC0227ea enumC0227ea, JSONObject jSONObject) {
        int i;
        c0773zb.getClass();
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
        v9.b = jSONObject.toString().getBytes(Charsets.UTF_8);
        return v9;
    }
}
