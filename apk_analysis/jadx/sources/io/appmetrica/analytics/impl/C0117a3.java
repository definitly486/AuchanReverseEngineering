package io.appmetrica.analytics.impl;

import android.content.Intent;
import io.appmetrica.analytics.coreapi.internal.backport.BiConsumer;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0117a3 implements BiConsumer {
    public final /* synthetic */ C0143b3 a;

    public C0117a3(C0143b3 c0143b3) {
        this.a = c0143b3;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.backport.BiConsumer
    public final void consume(Object obj, Object obj2) {
        Intent intent = (Intent) obj2;
        synchronized (this.a) {
            try {
                C0143b3 c0143b3 = this.a;
                c0143b3.b = intent;
                ArrayList arrayList = c0143b3.a;
                int size = arrayList.size();
                int i = 0;
                while (i < size) {
                    Object obj3 = arrayList.get(i);
                    i++;
                    ((Consumer) obj3).consume(intent);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
