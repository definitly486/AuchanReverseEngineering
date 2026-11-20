package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Fa implements InterfaceC0331ia {
    public final C0201d9 a = new C0201d9();

    public final C0693w9[] a(byte[] bArr) {
        int i = 0;
        if (bArr == null) {
            return new C0693w9[0];
        }
        Map<String, byte[]> model = this.a.toModel(bArr);
        C0693w9[] c0693w9Arr = new C0693w9[model.size()];
        for (Object obj : model.entrySet()) {
            int i2 = i + 1;
            if (i < 0) {
                CollectionsKt.throwIndexOverflow();
            }
            Map.Entry entry = (Map.Entry) obj;
            C0693w9 c0693w9 = new C0693w9();
            c0693w9.a = ((String) entry.getKey()).getBytes(Charsets.UTF_8);
            c0693w9.b = (byte[]) entry.getValue();
            c0693w9Arr[i] = c0693w9;
            i = i2;
        }
        return c0693w9Arr;
    }
}
