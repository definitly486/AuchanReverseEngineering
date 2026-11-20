package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import java.nio.charset.Charset;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.df, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0207df implements Converter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0352j6[] fromModel(Map<String, String> map) {
        int size = map.size();
        C0352j6[] c0352j6Arr = new C0352j6[size];
        int i = 0;
        for (int i2 = 0; i2 < size; i2++) {
            c0352j6Arr[i2] = new C0352j6();
        }
        for (Map.Entry<String, String> entry : map.entrySet()) {
            C0352j6 c0352j6 = c0352j6Arr[i];
            String key = entry.getKey();
            Charset charset = Charsets.UTF_8;
            c0352j6.a = key.getBytes(charset);
            c0352j6Arr[i].b = entry.getValue().getBytes(charset);
            i++;
        }
        return c0352j6Arr;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    public final Map<String, String> a(C0352j6[] c0352j6Arr) {
        throw new UnsupportedOperationException();
    }
}
