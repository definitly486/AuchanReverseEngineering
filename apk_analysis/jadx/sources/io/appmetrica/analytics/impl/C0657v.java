package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Collection;
import org.json.JSONArray;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.v, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0657v implements InterfaceC0709x {
    public final String a = "yandex";

    public final String a() {
        try {
            return new JSONArray((Collection) CollectionsKt.plus((Collection) CollectionsKt.listOf(this.a), (Iterable) C0584s4.l().m().d)).toString();
        } catch (Throwable unused) {
            return null;
        }
    }
}
